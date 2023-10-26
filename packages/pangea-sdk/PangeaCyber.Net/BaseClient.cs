using System.Text;


using PangeaCyber.Net.Exceptions;
using Newtonsoft.Json;
using System.Security.Authentication;
using System.Security.AccessControl;

namespace PangeaCyber.Net
{
    /// <kind>class</kind>
    /// <summary>
    /// Client
    /// </summary>
    public abstract class BaseClient<TBuilder> where TBuilder : BaseClient<TBuilder>.ClientBuilder
    {
        ///
        private readonly Config config;

        ///
        private readonly string serviceName;

        ///
        public string ConfigID { get; protected set; } = "";

        ///
        private readonly HttpClient PangeaHttpClient;

        ///
        private readonly HttpClient GeneralHttpClient;


        ///
        private readonly string userAgent;

        ///
        private NLog.Logger logger { get; }

        ///
        public class ClientBuilder
        {
            ///
            public Config config { get; }

            ///
            public NLog.Logger? logger { get; private set; } = null;

            ///
            public ClientBuilder(Config config)
            {
                this.config = config;
            }

            ///
            public ClientBuilder WithLogger(NLog.Logger _logger)
            {
                logger = _logger;
                return (TBuilder)this;
            }
        }

        ///
        protected BaseClient(ClientBuilder builder, string serviceName)
        {
            this.serviceName = serviceName;
            config = builder.config;
            logger = builder.logger ?? GetDefaultLogger();  // Set default logger
            userAgent = "pangea-csharp/" + Config.Version;
            if (config.CustomUserAgent != default)
            {
                userAgent += " " + config.CustomUserAgent;
            }

            PangeaHttpClient = new HttpClient();
            GeneralHttpClient = new HttpClient();
            PangeaHttpClient.BaseAddress = config.GetServiceUrl(serviceName, string.Empty);
            PangeaHttpClient.DefaultRequestHeaders.Add("User-Agent", userAgent);
            PangeaHttpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + config.Token);
            if (config.ConnectionTimeout != default)
            {
                PangeaHttpClient.Timeout = config.ConnectionTimeout;
                GeneralHttpClient.Timeout = config.ConnectionTimeout;
            }
        }

        private NLog.Logger GetDefaultLogger()
        {
            NLog.Logger logger = NLog.LogManager.GetLogger("Pangea");
            return logger;
        }

        private async Task<HttpResponseMessage> DoPost(string path, HttpContent content)
        {
            try
            {
                return await PangeaHttpClient.PostAsync(path, content);
            }
            catch (Exception e)
            {
                logger.Error(
                    $"{{\"service\": \"{serviceName}\", \"action\": \"post\", \"path\": \"{path}\", \"message\": \"failed to send request\", \"exception\": \"{e}\"}}"
                );
                throw new PangeaException("Failed to send request", e);
            }
        }

        private string SerializeRequest(BaseRequest request)
        {
            try
            {
                var jsonSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DateParseHandling = DateParseHandling.None, DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK" };
                return JsonConvert.SerializeObject(request, Formatting.Indented, jsonSettings);
            }
            catch (Exception e)
            {
                throw new PangeaException("Failed to write request", e);
            }
        }

        ///
        private async Task<HttpResponseMessage> SimplePost(string path, BaseRequest request, FileStream? fileStream = null)
        {
            if (!string.IsNullOrEmpty(ConfigID) && string.IsNullOrEmpty(request.ConfigID))
            {
                request.ConfigID = ConfigID;
            }

            string requestStr = SerializeRequest(request);
            logger.Debug(
                $"{{\"service\": \"{serviceName}\", \"action\": \"post\", \"path\": \"{path}\", \"request\": {requestStr}}}"
            );

            HttpResponseMessage res;

            if (fileStream == null)
            {
                res = await DoPost(path, new StringContent(requestStr, Encoding.UTF8, "application/json"));
            }
            else
            {
                if (request.TransferMethod == TransferMethod.Direct)
                {
                    res = await DoPostPresignedURL(path, request, fileStream);
                }
                else
                {
                    using var formData = new MultipartFormDataContent
                    {
                        { new StringContent(requestStr, null, "application/json"), "request" }
                    };
                    var fileContent = new StreamContent(fileStream);
                    formData.Add(fileContent, "upload", "file.exe");
                    res = await DoPost(path, formData);
                }
            }

            return res;
        }

        ///
        public async Task<Response<TResult>> DoPost<TResult>(string path, BaseRequest request, FileStream? fileStream = null)
        {
            var res = await SimplePost(path, request, fileStream);
            res = await HandleQueued(res);
            return await CheckResponse<TResult>(res);
        }

        private async Task<Response<TResult>> DoPollResult<TResult>(string requestID)
        {
            string path = PollResultPath(requestID);
            HttpResponseMessage res = await DoGet(path);
            return await CheckResponse<TResult>(res);
        }

        private async Task<HttpResponseMessage> DoPostPresignedURL(string path, BaseRequest request, FileStream fileStream)
        {
            AcceptedRequestException acceptedRequestException;
            var resPangea = await SimplePost(path, request);
            try
            {
                await CheckResponse<Dictionary<string, object>>(resPangea);
                throw new PresignedURLException("This should return 202", null, await resPangea.Content.ReadAsStringAsync());
            }
            catch (AcceptedRequestException e)
            {
                acceptedRequestException = e;
            }

            var acceptedResult = await PollPresignedURL(acceptedRequestException);

            logger.Debug(
                $"{{\"service\": \"{serviceName}\", \"action\": \"post\", \"url\": \"{acceptedResult.AcceptedStatus.UploadURL}\"}}"
            );

            // Create PresignedURL post
            using var formData = new MultipartFormDataContent();
            foreach (var pair in acceptedResult.AcceptedStatus.UploadDetails)
            {
                formData.Add(new StringContent(pair.Value, null, "application/json"), pair.Key);
            }
            var fileContent = new StreamContent(fileStream);
            formData.Add(fileContent, "file", "file.exe");

            try
            {
                var resPSurl = await GeneralHttpClient.PostAsync(acceptedResult.AcceptedStatus.UploadURL, formData);
                if (resPSurl.StatusCode < System.Net.HttpStatusCode.OK || resPSurl.StatusCode >= System.Net.HttpStatusCode.Ambiguous)
                {
                    throw new PresignedURLException("Failed post to presigned URL", null, await resPSurl.Content.ReadAsStringAsync());
                }
            }
            catch (Exception e)
            {
                throw new PresignedURLException("Failed post to presigned URL", e, null);
            }

            return resPangea;
        }

        private async Task<AcceptedResult> PollPresignedURL(AcceptedRequestException ae)
        {
            if (ae.AcceptedResult.AcceptedStatus.UploadURL != null)
            {
                return ae.AcceptedResult;
            }

            logger.Info(
                $"{{\"service\": \"{serviceName}\", \"action\": \"PollPresignedURL\", \"step\": \"start\"}}"
            );

            int retryCounter = 1;
            long start = DateTimeOffset.Now.ToUnixTimeSeconds(), delay;
            string requestId = ae.RequestID;
            string path = PollResultPath(requestId);
            AcceptedRequestException aeLoop = ae;

            while (aeLoop.AcceptedResult.AcceptedStatus.UploadURL == null && !ReachedTimeout(start))
            {
                logger.Debug(
                    $"{{\"service\": \"{serviceName}\", \"action\": \"PollPresignedURL\", \"step\": \"{retryCounter}\"}}"
                );

                delay = GetDelay(retryCounter, start);
                await Task.Delay(TimeSpan.FromSeconds(delay));
                var response = await DoGet(path);
                try
                {
                    await CheckResponse<Dictionary<string, object>>(response);
                    throw new PresignedURLException("This should return 202", null, await response.Content.ReadAsStringAsync());
                }
                catch (AcceptedRequestException e)
                {
                    aeLoop = e;
                }
                retryCounter++;
            }

            logger.Debug(
                $"{{\"service\": \"{serviceName}\", \"action\": \"PollPresignedURL\", \"step\": \"exit\"}}"
            );

            if (ReachedTimeout(start))
            {
                throw aeLoop;
            }

            return aeLoop.AcceptedResult;
        }

        ///
        public async Task<Response<TResult>> PollResult<TResult>(string requestID)
        {
            return await DoPollResult<TResult>(requestID);
        }

        ///
        public async Task<Response<Dictionary<string, object>>> PollResult(string requestID)
        {
            return await DoPollResult<Dictionary<string, object>>(requestID);
        }

        ///
        public async Task<Response<TResult>> Get<TResult>(string path)
        {
            HttpResponseMessage res = await DoGet(path);
            return await CheckResponse<TResult>(res);
        }

        ///
        protected async Task<HttpResponseMessage> DoGet(string path)
        {
            logger.Debug(
                $"{{\"service\": \"{serviceName}\", \"action\": \"get\", \"path\": \"{path}\"}}"
            );

            HttpResponseMessage res;
            try
            {
                res = await PangeaHttpClient.GetAsync(path);
            }
            catch (Exception e)
            {
                logger.Error(
                    $"{{\"service\": \"{serviceName}\", \"action\": \"get\", \"path\": \"{path}\", \"message\": \"failed to send request\", \"exception\": \"{e}\"}}"
                );
                throw new PangeaException("Failed to send get request", e);
            }
            return res;
        }

        private long GetDelay(int retryCounter, long startSecSinceEpoch)
        {
            long delay = retryCounter * retryCounter;
            long now = DateTimeOffset.Now.ToUnixTimeSeconds();

            if (now + delay >= startSecSinceEpoch + config.PollResultTimeoutSecs)
            {
                delay = startSecSinceEpoch + config.PollResultTimeoutSecs - now;
            }
            return delay;
        }

        private bool ReachedTimeout(long startSecSinceEpoch)
        {
            long now = DateTimeOffset.Now.ToUnixTimeSeconds();
            return now >= startSecSinceEpoch + this.config.PollResultTimeoutSecs;
        }

        private string PollResultPath(string requestId)
        {
            return $"/request/{requestId}";
        }

        private async Task<HttpResponseMessage> HandleQueued(HttpResponseMessage response)
        {
            if (response.StatusCode != System.Net.HttpStatusCode.Accepted ||
                !config.QueuedRetryEnabled ||
                config.PollResultTimeoutSecs <= 1)
            {
                return response;
            }

            int retryCounter = 1;
            long start = DateTimeOffset.Now.ToUnixTimeSeconds();
            long delay;

            var jsonSettings = GetJsonSerializerSettings();
            string body = await response.Content.ReadAsStringAsync();
            ResponseHeader header;

            try
            {
                header = JsonConvert.DeserializeObject<ResponseHeader>(body, jsonSettings) ?? default!;
            }
            catch (Exception e)
            {
                throw new PangeaException("Failed to parse response header", e);
            }

            logger.Info(
                $"{{\"service\": \"{serviceName}\", \"action\": \"HandleQueued\", \"step\": \"start\", \"response\": {body} }}"
            );

            string requestId = header.RequestId;
            string path = PollResultPath(requestId);

            while (response.StatusCode == System.Net.HttpStatusCode.Accepted && !ReachedTimeout(start))
            {
                logger.Debug(
                    $"{{\"service\": \"{serviceName}\", \"action\": \"HandleQueued\", \"step\": \"{retryCounter}\"}}"
                );

                delay = GetDelay(retryCounter, start);
                await Task.Delay(TimeSpan.FromSeconds(delay));
                response = await DoGet(path);
                retryCounter++;
            }

            logger.Debug(
                $"{{\"service\": \"{serviceName}\", \"action\": \"HandleQueued\", \"step\": \"exit\"}}"
            );

            return response;
        }

        private JsonSerializerSettings GetJsonSerializerSettings()
        {
            return new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DateParseHandling = DateParseHandling.None, DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK" };
        }

        ///
        public async Task<Response<TResult>> CheckResponse<TResult>(HttpResponseMessage res)
        {
            string body = await res.Content.ReadAsStringAsync();
            ResponseHeader header;

            logger.Debug(
                $"{{\"service\": \"{serviceName}\", \"action\": \"checkResponse\", \"response\": {body} }}"
            );

            try
            {
                header = JsonConvert.DeserializeObject<ResponseHeader>(body, GetJsonSerializerSettings()) ?? default!;
            }
            catch (Exception e)
            {
                logger.Error(
                    $"{{\"service\": \"{serviceName}\", \"action\": \"CheckResponse\", \"message\": \"failed to parse response header\", \"exception\": \"{e}\"}}"
                );
                throw new PangeaException("Failed to parse response header", e);
            }

            if (header != null && header.IsOK)
            {
                Response<TResult> resultResponse;

                try
                {
                    resultResponse = JsonConvert.DeserializeObject<Response<TResult>>(body, GetJsonSerializerSettings()) ?? default!;
                }
                catch (Exception e)
                {
                    logger.Error(
                        $"{{\"service\": \"{serviceName}\", \"action\": \"CheckResponse\", \"message\": \"failed to parse response result\", \"exception\": \"{e}\"}}"
                    );
                    throw new ParseResultFailed("Failed to parse response result", e, header, body);
                }

                resultResponse.HttpResponse = res;
                return resultResponse;
            }

            // Process Errors
            string summary = header?.Summary ?? default!;
            string status = header?.Status ?? default!;
            Response<PangeaErrors> response;

            try
            {
                response = JsonConvert.DeserializeObject<Response<PangeaErrors>>(body, GetJsonSerializerSettings()) ?? default!;
            }
            catch (Exception e)
            {
                logger.Error(
                    $"{{\"service\": \"{serviceName}\", \"action\": \"CheckResponse\", \"message\": \"failed to parse response errors\", \"exception\": \"{e}\"}}"
                );
                throw new ParseResultFailed("Failed to parse response errors", e, header ?? default!, body);
            }
            response.HttpResponse = res;

            if (header != null)
            {
                if (header.Status.Equals(ResponseStatus.ValidationError.ToString()))
                {
                    throw new ValidationException(summary, response);
                }
                else if (header.Status.Equals(ResponseStatus.TooManyRequests.ToString()))
                {
                    throw new RateLimitException(summary, response);
                }
                else if (header.Status.Equals(ResponseStatus.NoCredit.ToString()))
                {
                    throw new NoCreditException(summary, response);
                }
                else if (header.Status.Equals(ResponseStatus.Unauthorized.ToString()))
                {
                    throw new UnauthorizedException(serviceName, response);
                }
                else if (header.Status.Equals(ResponseStatus.ServiceNotEnabled.ToString()))
                {
                    throw new ServiceNotEnabledException(serviceName, response);
                }
                else if (header.Status.Equals(ResponseStatus.ProviderError.ToString()))
                {
                    throw new ProviderErrorException(summary, response);
                }
                else if (header.Status.Equals(ResponseStatus.MissingConfigIDScope.ToString()) || header.Status.Equals(ResponseStatus.MissingConfigID.ToString()))
                {
                    throw new MissingConfigID(serviceName, response);
                }
                else if (header.Status.Equals(ResponseStatus.ServiceNotAvailable.ToString()))
                {
                    throw new ServiceNotAvailableException(summary, response);
                }
                else if (header.Status.Equals(ResponseStatus.IPNotFound.ToString()))
                {
                    throw new EmbargoIPNotFoundException(summary, response);
                }
                else if (header.Status.Equals(ResponseStatus.Accepted.ToString()))
                {
                    throw await AcceptedRequestException.Create($"Summary: \"{summary}\". request_id: \"{response.RequestId}\".", response);
                }
            }
            throw new PangeaAPIException(String.Format("{0}: {1}", status, summary), response);
        }

    }
}
