using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotApi
{
    /// <summary>
    /// Provides a base class for sending HTTP requests and receiving HTTP responses from
    /// the Riot APIs.
    /// </summary>
    public abstract class WebRequester
    {
        /// <summary>
        /// Shared HTTP client for all Requesters.
        /// </summary>
        private static readonly HttpClient HttpClient = new HttpClient();

        

        public string Key { get; private set; }
        public RetryPolicy RetryPolicy { get; set; }

        /// <summary>
        /// Constructs a new instance of the <see cref="WebRequester"/> class.
        /// </summary>
        /// <param name="key">The API key.</param>
        protected WebRequester(string key)
        {
            Key = key;
            
        }

        /// <summary>
        /// Sends an API request asynchronously and returns the serialized response object as
        /// a <see cref="JObject"/>.
        /// </summary>
        /// <param name="region">The API region.</param>
        /// <param name="relativeUri">The relative URI.</param>
        /// <param name="parameters">An optional collection of parameters.</param>
        /// <returns>The response object.</returns>
        public virtual Task<JObject> GetAsync(string region, string relativeUri,
            IEnumerable<KeyValuePair<string, string>> parameters = null)
        {
            return GetAsync(region, GetRequestUri(region, relativeUri, parameters), CancellationToken.None);
        }

        /// <summary>
        /// Sends an API request asynchronously and returns the serialized response object.
        /// </summary>
        /// <typeparam name="TResult">The type of the response object.</typeparam>
        /// <param name="region">The API region.</param>
        /// <param name="relativeUri">The relative URI.</param>
        /// <param name="parameters">An optional collection of parameters.</param>
        /// <returns>The response object.</returns>
        public virtual Task<TResult> GetAsync<TResult>(string region, string relativeUri,
            IEnumerable<KeyValuePair<string, string>> parameters = null)
        {
            return GetAsync<TResult>(region, GetRequestUri(region, relativeUri, parameters), CancellationToken.None);
        }

        /// <summary>
        /// Sends an API request asynchronously to the global endpoint and returns the
        /// serialized response object as a <see cref="JObject"/>.
        /// </summary>
        /// <remarks>
        /// Regardless of the value provided in the <paramref name="region"/> parameter,
        /// the request always targets the global API endpoint. The region parameter is
        /// still used for determining locality of the response data.
        /// 
        /// Requests to the global API endpoint do not count against the rate limit.
        /// </remarks>
        /// <param name="region">The API region.</param>
        /// <param name="relativeUri">The relative URI.</param>
        /// <param name="parameters">An optional collection of parameters.</param>
        /// <returns>The response object.</returns>
        public virtual Task<JObject> GetStaticAsync(string region, string relativeUri,
            IEnumerable<KeyValuePair<string, string>> parameters = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sends an API request asynchronously to the global endpoint and returns the
        /// serialized response object.
        /// </summary>
        /// <remarks>
        /// Regardless of the value provided in the <paramref name="region"/> parameter,
        /// the request always targets the global API endpoint. The region parameter is
        /// still used for determining locality of the response data.
        /// 
        /// Requests to the global API endpoint do not count against the rate limit.
        /// </remarks>
        /// <typeparam name="TResult">The type of the response object.</typeparam>
        /// <param name="region">The API region.</param>
        /// <param name="relativeUri">The relative URI.</param>
        /// <param name="parameters">An optional collection of parameters.</param>
        /// <returns>The response object.</returns>
        public virtual Task<TResult> GetStaticAsync<TResult>(string region, string relativeUri,
            IEnumerable<KeyValuePair<string, string>> parameters = null)
        {
            throw new NotImplementedException();
        }

        protected virtual async Task<JObject> DeserializeResponseAsync(HttpResponseMessage response)
        {
            if ((int) response.StatusCode == 404)
            {
                return null;
            }
            return JObject.Parse(await response.Content.ReadAsStringAsync());
        }

        protected virtual async Task<TResult> DeserializeResponseAsync<TResult>(HttpResponseMessage response)
        {
            if ((int) response.StatusCode == 404)
            {
                return default(TResult);
            }
            return JsonConvert.DeserializeObject<TResult>(await response.Content.ReadAsStringAsync());
        }

        protected virtual async Task<JObject> GetAsync(string region, string uri, CancellationToken cancellationToken)
        {
            var response = await SendRequestInternalAsync(region, uri, cancellationToken);
            return await DeserializeResponseAsync(response);
        }

        protected virtual async Task<TResult> GetAsync<TResult>(string region, string uri, CancellationToken cancellationToken)
        {
            var response = await SendRequestInternalAsync(region, uri, cancellationToken);
            return await DeserializeResponseAsync<TResult>(response);
        }

        protected virtual string GetQueryString(IEnumerable<KeyValuePair<string, string>> keyValuePairs)
        {
            if (keyValuePairs == null) return "";

            var pairs = from kv in keyValuePairs
                        let key = Uri.EscapeDataString(kv.Key)
                        let value = Uri.EscapeDataString(kv.Value)
                        select $"{key}={value}";

            return string.Join("&", pairs);
        }

        protected virtual string GetRequestUri(string region, string relativeUri,
            IEnumerable<KeyValuePair<string, string>> parameters)
        {
            var queryString = GetQueryString(parameters);

            if (!string.IsNullOrEmpty(queryString))
            {
                queryString += "&";
            }
            queryString += "api_key=" + Key;
            return string.Format("https://{0}.api.pvp.net/api/lol/{0}/{1}?{2}", region.ToLowerInvariant(), relativeUri,
                queryString);
        }

        protected virtual HttpRequestMessage ResolveRequestMessage(string uri)
        {
            return new HttpRequestMessage(HttpMethod.Get, uri);
        }

        protected virtual Task<HttpResponseMessage> ResolveResponseMessage(string region, HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            return HttpClient.SendAsync(request, cancellationToken);
        }

        protected virtual async Task<HttpResponseMessage> SendRequestInternalAsync(string region, string uri,
            CancellationToken cancellationToken)
        {
            int attempts = RetryPolicy?.MaximumAttempts ?? 1;

            if (attempts == 0)
            {
                throw new InvalidOperationException("Unable to process request because MaximumAttempts is equal to 0.");
            }

            while (attempts-- > 0)
            {
                var request = ResolveRequestMessage(uri);
                var response = await ResolveResponseMessage(region, request, cancellationToken);

                if ((int) response.StatusCode == 200 || (int) response.StatusCode == 404)
                {
                    // 200 indicates the request was successful and the response
                    // contains a valid entity.
                    // 404 indicates the request was successful but the response
                    // does not contain a valid entity. this could be caused by
                    // requesting an entity that does not exist.
                    return response;
                }

                if ((int) response.StatusCode >= 500)
                {
                    // 500-503 indicate a problem occurred on Riot's servers.
                    // this frequently indicates high server load and the server
                    // is temporarily rejecting requests.
                    // SOP is to retry the request after a short interval.
                    if (attempts > 0)
                    {
                        var interval = RetryPolicy?.Interval ?? TimeSpan.FromSeconds(1);
                        await Task.Delay(interval, cancellationToken);
                        continue;
                    }
                }

                throw new RiotHttpException((int) response.StatusCode);
            }
            // inaccessible code.
            throw new InvalidOperationException();
        }
    }
}