﻿using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using eth.Common.JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace eth.Telegram.BotApi.Internal
{
    internal class HttpApiClient : IDisposable
    {
        private readonly string _token;
        private readonly HttpClient _client;

        public TimeSpan Timeout { get { return _client.Timeout; } set { _client.Timeout = value; } }

        public HttpApiClient([NotNull] Uri baseUri, [NotNull] string token)
        {
            Debug.Assert(baseUri != null);
            Debug.Assert(!string.IsNullOrEmpty(token));
            
            _token = token;

            _client = new HttpClient
            {
                BaseAddress = baseUri,
                Timeout = TimeSpan.FromSeconds(3)
            };

            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Connection.Add("Keep-Alive");
        }

        public async Task<T> CallAsync<T>(ApiMethod method, [CanBeNull] object args = null)
        {
            var content = new StringContent(JsonConvert.SerializeObject(args, new StringEnumConverter { AllowIntegerValues = false }), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"/bot{_token}/{method}", content).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
                throw new TelegramBotApiException
                {
                    HttpStatusCode = response.StatusCode,
                    HttpStatusMessage = response.ReasonPhrase
                };

            var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var responseDeserialized = JsonConvert.DeserializeObject<ApiResponse<T>>(responseString, new StringEnumConverter { AllowIntegerValues = false });

            if (!responseDeserialized.IsOk)
                throw new TelegramBotApiException
                {
                    TelegramDescription = responseDeserialized.Description,
                    TelegramErrorCode = responseDeserialized.ErrorCode
                };
            
            return responseDeserialized.Result;
        }

        //todo: call with multipartformdata file attached

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
