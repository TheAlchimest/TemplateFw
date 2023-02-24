﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
namespace TemplateFw.Shared.Helpers
{
    public class ApiHelper
    {
        public static T GetFromApi<T>(string uri)
        {
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                var httpClient = new HttpClient(clientHandler)
                {
                    BaseAddress = new Uri(uri)
                };
                HttpResponseMessage response = httpClient.GetAsync(uri).Result;
                string content = string.Empty;

                using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result))
                {
                    content = stream.ReadToEnd();
                    var dto = JsonConvert.DeserializeObject<T>(content);
                    return (T)dto;
                }
            }
            catch (Exception ex)
            {
                // throw new Exception(ex.Message);
                return default(T);
            }
        }
        public static string GetStringFromApi(string uri)
        {
            string content = string.Empty;
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                var httpClient = new HttpClient(clientHandler)
                {
                    BaseAddress = new Uri(uri)
                };
                HttpResponseMessage response = httpClient.GetAsync(uri).Result;

                using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result))
                {
                    content = stream.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                //   throw new Exception(ex.Message);
            }
            return content;
        }
    }
}
