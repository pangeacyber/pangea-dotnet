﻿using System.Text;


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
        public class ClientBuilder {
            ///
            public Config config {get; }

            ///
            public ClientBuilder(Config config){
                this.config = config;
            }
        }

        ///
        protected BaseClient(ClientBuilder builder, string serviceName, bool SupportMultiConfig)
        {
            this.config = builder.config;
            this.serviceName = serviceName;
            this.SupportMultiConfig = SupportMultiConfig;
            this.HttpClient = new HttpClient();
            this.HttpClient.BaseAddress = config.GetServiceUrl(serviceName, String.Empty);

            this.userAgent = "pangea-csharp/" + Config.Version;
            if(config.CustomUserAgent != default){
                this.userAgent += " " + config.CustomUserAgent;
            }

            this.HttpClient.DefaultRequestHeaders.Add("User-Agent", this.userAgent);
            this.HttpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + config.Token);

            if (config.ConnectionTimeout != default(TimeSpan))
            {
                this.HttpClient.Timeout = config.ConnectionTimeout;
            }
        }

        ///
        public async Task<Response<TResult>> DoPost<TResult>(string path, BaseRequest request)
        {
            if(this.SupportMultiConfig && this.config.ConfigID != default && request.ConfigID == default) {
                request.ConfigID = this.config.ConfigID;
            }

            string requestStr;
            StringContent requestJson;
            String requestStr;
            try
            {
                var jsonSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DateParseHandling = DateParseHandling.None, DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK" };
                requestStr = JsonConvert.SerializeObject(request, Formatting.Indented, jsonSettings);
                requestJson = new StringContent(requestStr, Encoding.UTF8, "application/json");
            }
            catch (Exception e)
            {
                throw new PangeaException("Failed to write request", e);
            }

            HttpResponseMessage res = default!;
            try
            {
                res = await this.HttpClient.PostAsync(path, requestJson);
            }
            catch (Exception e)
            {
                throw new PangeaException("Failed to send request", e);
            }

            return await CheckResponse<TResult>(res);
        }

        ///
        public async Task<Response<TResult>> CheckResponse<TResult>(HttpResponseMessage res)
        {
            var jsonSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DateParseHandling = DateParseHandling.None, DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK" };
            string body = await res.Content.ReadAsStringAsync();

            ResponseHeader header = default!;

            try
            {
                header = JsonConvert.DeserializeObject<ResponseHeader>(body, jsonSettings) ?? default!;
            }
            catch (Exception e)
            {
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
            }
            throw new PangeaAPIException(String.Format("{0}: {1}", status, summary), response);
        }

    }
}