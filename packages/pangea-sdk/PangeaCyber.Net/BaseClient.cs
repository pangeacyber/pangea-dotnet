using System.Text;


using PangeaCyber.Net.Exceptions;
using Newtonsoft.Json;

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
        private readonly bool SupportMultiConfig;

        ///
        protected readonly HttpClient HttpClient;

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
                this.logger = _logger;
                return (TBuilder)this;
            }
        }

        ///
        protected BaseClient(ClientBuilder builder, string serviceName, bool SupportMultiConfig)
        {
            this.config = builder.config;
            // Set default logger
            this.logger = builder.logger ?? this.GetDefaultLogger();
            this.serviceName = serviceName;
            this.SupportMultiConfig = SupportMultiConfig;
            this.HttpClient = new HttpClient();
            this.HttpClient.BaseAddress = config.GetServiceUrl(serviceName, String.Empty);

            this.userAgent = "pangea-csharp/" + Config.Version;
            if (config.CustomUserAgent != default)
            {
                this.userAgent += " " + config.CustomUserAgent;
            }

            this.HttpClient.DefaultRequestHeaders.Add("User-Agent", this.userAgent);
            this.HttpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + config.Token);

            if (config.ConnectionTimeout != default(TimeSpan))
            {
                this.HttpClient.Timeout = config.ConnectionTimeout;
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
                return await this.HttpClient.PostAsync(path, content);
            }
            catch (Exception e)
            {
                this.logger.Error(
                    $"{{\"service\": \"{serviceName}\", \"action\": \"post\", \"path\": \"{path}\", \"message\": \"failed to send request\", \"exception\": \"{e.ToString()}\"}}"
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
        public async Task<Response<TResult>> DoPost<TResult>(string path, BaseRequest request, FileStream? fileStream = null)
        {
            if (this.SupportMultiConfig && this.config.ConfigID != default && request.ConfigID == default)
            {
                request.ConfigID = this.config.ConfigID;
            }

            string requestStr = SerializeRequest(request);
            this.logger.Debug(
                $"{{\"service\": \"{serviceName}\", \"action\": \"post\", \"path\": \"{path}\", \"request\": {requestStr}}}"
            );

            HttpResponseMessage res = default!;

            if (fileStream == null)
            {
                res = await DoPost(path, new StringContent(requestStr, Encoding.UTF8, "application/json"));
            }
            else
            {
                using (var formData = new MultipartFormDataContent())
                {
                    formData.Add(new StringContent(requestStr, null, "application/json"), "request");
                    var fileContent = new StreamContent(fileStream);
                    formData.Add(fileContent, "upload", "file.exe");
                    res = await DoPost(path, formData);
                }
            }

            if (res.StatusCode == System.Net.HttpStatusCode.Accepted && this.config.QueuedRetryEnabled)
            {
                res = await this.HandleQueued(res);
            }

            return await CheckResponse<TResult>(res);
        }

        private async Task<Response<TResult>> DoPollResult<TResult>(string requestID)
        {
            string path = PollResultPath(requestID);
            HttpResponseMessage res = await DoGet(path);
            return await CheckResponse<TResult>(res);
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
        protected async Task<HttpResponseMessage> DoGet(String path)
        {
            this.logger.Debug(
                $"{{\"service\": \"{serviceName}\", \"action\": \"get\", \"path\": \"{path}\"}}"
            );

            HttpResponseMessage res = default!;
            try
            {
                res = await this.HttpClient.GetAsync(path);
            }
            catch (Exception e)
            {
                this.logger.Error(
                    $"{{\"service\": \"{serviceName}\", \"action\": \"get\", \"path\": \"{path}\", \"message\": \"failed to send request\", \"exception\": \"{e.ToString()}\"}}"
                );
                throw new PangeaException("Failed to send get request", e);
            }
            return res;
        }

        private long GetDelay(int retryCounter, long startSecSinceEpoch)
        {
            long delay = retryCounter * retryCounter;
            long now = DateTimeOffset.Now.ToUnixTimeSeconds();

            if (now + delay >= startSecSinceEpoch + this.config.PollResultTimeoutSecs)
            {
                delay = startSecSinceEpoch + this.config.PollResultTimeoutSecs - now;
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
                !this.config.QueuedRetryEnabled ||
                this.config.PollResultTimeoutSecs <= 1)
            {
                return response;
            }

            int retryCounter = 1;
            long start = DateTimeOffset.Now.ToUnixTimeSeconds();
            long delay;

            var jsonSettings = GetJsonSerializerSettings();
            string body = await response.Content.ReadAsStringAsync();
            ResponseHeader header = default!;

            try
            {
                header = JsonConvert.DeserializeObject<ResponseHeader>(body, jsonSettings) ?? default!;
            }
            catch (Exception e)
            {
                throw new PangeaException("Failed to parse response header", e);
            }

            this.logger.Info(
                $"{{\"service\": \"{serviceName}\", \"action\": \"HandleQueued\", \"step\": \"start\", \"response\": {body} }}"
            );

            string requestId = header.RequestId;
            string path = PollResultPath(requestId);

            while (response.StatusCode == System.Net.HttpStatusCode.Accepted && !ReachedTimeout(start))
            {
                this.logger.Debug(
                    $"{{\"service\": \"{serviceName}\", \"action\": \"HandleQueued\", \"step\": \"{retryCounter}\"}}"
                );

                delay = GetDelay(retryCounter, start);
                await Task.Delay(TimeSpan.FromSeconds(5));
                response = await DoGet(path);
                retryCounter++;
            }

            this.logger.Debug(
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
            var jsonSettings = GetJsonSerializerSettings();
            string body = await res.Content.ReadAsStringAsync();
            ResponseHeader header = default!;

            this.logger.Debug(
                $"{{\"service\": \"{serviceName}\", \"action\": \"checkResponse\", \"response\": {body} }}"
            );

            try
            {
                header = JsonConvert.DeserializeObject<ResponseHeader>(body, jsonSettings) ?? default!;
            }
            catch (Exception e)
            {
                this.logger.Error(
                    $"{{\"service\": \"{serviceName}\", \"action\": \"CheckResponse\", \"message\": \"failed to parse response header\", \"exception\": \"{e.ToString()}\"}}"
                );
                throw new PangeaException("Failed to parse response header", e);
            }

            if (header != null && header.IsOK)
            {
                Response<TResult> resultResponse = default!;

                try
                {
                    resultResponse = JsonConvert.DeserializeObject<Response<TResult>>(body, jsonSettings) ?? default!;
                }
                catch (Exception e)
                {
                    this.logger.Error(
                        $"{{\"service\": \"{serviceName}\", \"action\": \"CheckResponse\", \"message\": \"failed to parse response result\", \"exception\": \"{e.ToString()}\"}}"
                    );
                    throw new ParseResultFailed("Failed to parse response result", e, header, body);
                }

                resultResponse.HttpResponse = res;
                return resultResponse;
            }

            // Process Errors
            string summary = header?.Summary ?? default!;
            string status = header?.Status ?? default!;
            Response<PangeaErrors> response = default!;

            try
            {
                response = JsonConvert.DeserializeObject<Response<PangeaErrors>>(body, jsonSettings) ?? default!;
            }
            catch (Exception e)
            {
                this.logger.Error(
                    $"{{\"service\": \"{serviceName}\", \"action\": \"CheckResponse\", \"message\": \"failed to parse response errors\", \"exception\": \"{e.ToString()}\"}}"
                );
                throw new ParseResultFailed("Failed to parse response errors", e, header ?? default!, body);
            }
            response.HttpResponse = res;

            if (header != null)
            {
                if (header.Status.Equals(ResponseStatus.ValidationError.ToString()))
                {
                    throw new Exceptions.ValidationException(summary, response);
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
                    throw new UnauthorizedException(this.serviceName, response);
                }
                else if (header.Status.Equals(ResponseStatus.ServiceNotEnabled.ToString()))
                {
                    throw new ServiceNotEnabledException(this.serviceName, response);
                }
                else if (header.Status.Equals(ResponseStatus.ProviderError.ToString()))
                {
                    throw new ProviderErrorException(summary, response);
                }
                else if (header.Status.Equals(ResponseStatus.MissingConfigIDScope.ToString()) || header.Status.Equals(ResponseStatus.MissingConfigID.ToString()))
                {
                    throw new MissingConfigID(this.serviceName, response);
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
                    throw new AcceptedRequestException($"Summary: \"{summary}\". request_id: \"{response.RequestId}\".", response);
                }
            }
            throw new PangeaAPIException(String.Format("{0}: {1}", status, summary), response);
        }

    }
}
