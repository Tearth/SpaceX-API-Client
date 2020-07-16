﻿using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Oddity.Events;
using Oddity.Exceptions;
using Oddity.Models.Query;

namespace Oddity.Builders
{
    /// <summary>
    /// Represents an abstract base class for all builders.
    /// </summary>
    /// <typeparam name="TReturn">Type which will be returned after successful API request.</typeparam>
    public abstract class BuilderBase<TReturn>
    {
        protected readonly HttpClient HttpClient;
        protected readonly BuilderDelegates BuilderDelegates;

        private JsonSerializerSettings _serializationSettings;

        protected BuilderBase(HttpClient httpClient, BuilderDelegates builderDelegates)
        {
            HttpClient = httpClient;
            BuilderDelegates = builderDelegates;

            _serializationSettings = new JsonSerializerSettings
            {
                Error = JsonDeserializationError,
#if DEBUG
                CheckAdditionalContent = true,
                MissingMemberHandling = MissingMemberHandling.Error
#endif
            };
        }

        /// <summary>
        /// Performs a request to the API and returns deserialized JSON.
        /// </summary>
        /// <returns>The all capsules information or null/empty list if object is not available.</returns>
        /// <exception cref="ApiUnavailableException">Thrown when SpaceX API is unavailable.</exception>
        public abstract TReturn Execute();

        public abstract bool Execute(TReturn model);

        /// <summary>
        /// Performs an async request to the API and returns deserialized JSON.
        /// </summary>
        /// <returns>The all capsules information or null/empty list if object is not available.</returns>
        /// <exception cref="ApiUnavailableException">Thrown when SpaceX API is unavailable.</exception>
        /// <exception cref="ApiBadRequestException">Thrown when SpaceX API received an invalid request.</exception>
        public abstract Task<TReturn> ExecuteAsync();

        public abstract Task<bool> ExecuteAsync(TReturn model);

        protected async Task<string> GetResponseFromEndpoint(string link, string postBody = null)
        {
            BuilderDelegates.RequestSend(new RequestSendEventArgs(link, postBody));

            HttpResponseMessage response;
            if (postBody == null)
            {
                response = await HttpClient.GetAsync(link).ConfigureAwait(false);
            }
            else
            {
                var httpContent = new StringContent(postBody, Encoding.UTF8, "application/json");
                response = await HttpClient.PostAsync(link, httpContent).ConfigureAwait(false);
            }

            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var eventArgs = new ResponseReceiveEventArgs(content, response.StatusCode, response.ReasonPhrase);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    if (content == "Not Found")
                    {
                        return null;
                    }

                    throw new ApiBadRequestException(content);
                }

                throw new ApiUnavailableException($"Status code: {(int)response.StatusCode}");
            }

            BuilderDelegates.ResponseReceived(eventArgs);

            return content;
        }

        protected string SerializeJson(object model)
        {
            return JsonConvert.SerializeObject(model);
        }

        protected TReturn DeserializeJson(string content)
        {
            return JsonConvert.DeserializeObject<TReturn>(content, _serializationSettings);
        }

        protected void DeserializeJson(string content, TReturn model)
        {
            JsonConvert.PopulateObject(content, model, _serializationSettings);
        }

        private void JsonDeserializationError(object sender, ErrorEventArgs errorEventArgs)
        {
            BuilderDelegates.DeserializationError(errorEventArgs);
        }
    }
}
