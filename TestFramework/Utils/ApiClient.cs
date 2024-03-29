﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace TestFramework.Utils
{
    public class ApiClient
    {
        HttpClient _client;

        public ApiClient(string host)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(host);
        }

        public HttpResponseMessage Post(string requestUri, string jsonObject)
        {
            var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
            var result = _client.PostAsync(requestUri, content).GetAwaiter().GetResult();
            return result;
        }

        public HttpResponseMessage Get(string requestUri, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("token", token);
            var result = _client.GetAsync(requestUri).GetAwaiter().GetResult();
            return result;
        }

        public string PostWithToken(string requestUri, string token, string jsonObject)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
            var response = _client.PostAsync(requestUri, content).Result;
            var contents = response.Content.ReadAsStringAsync().Result;
            return contents;
        }
    }
}