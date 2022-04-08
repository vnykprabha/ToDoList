using System;
using System.Collections.Generic;
using System.Text;
using OnlineToDoList.DataAccess.Interface;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace OnlineToDoList.DataAccess.DataAccess 
{
    public class DataAccess : IDataAccess
    {
        public HttpResponseMessage ProcessGet(string url)
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                Credentials = CredentialCache.DefaultCredentials,
                UseDefaultCredentials = true
            };
            using (var client = new HttpClient(handler))
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                return response;
            }
        }

        public HttpResponseMessage ProcessPost<T>(string url, T entity) where T : class
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                Credentials = CredentialCache.DefaultCredentials,
                UseDefaultCredentials = true
            };
            using (var client = new HttpClient(handler))
            {
                string body = JsonConvert.SerializeObject(entity);
                HttpContent content = new StringContent(body, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(url, content).Result;
                return response;
            }
        }

        public HttpResponseMessage ProcessPut<T>(string url, T entity) where T : class
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                Credentials = CredentialCache.DefaultCredentials,
                UseDefaultCredentials = true
            };
            using (var client = new HttpClient(handler))
            {
                string body = JsonConvert.SerializeObject(entity);
                HttpContent content = new StringContent(body, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync(url, content).Result;
                return response;
            }
        }

        public HttpResponseMessage ProcessDelete(string url)
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                Credentials = CredentialCache.DefaultCredentials,
                UseDefaultCredentials = true
            };
            using (var client = new HttpClient(handler))
            {
                HttpResponseMessage response = client.DeleteAsync(url).Result;
                return response;
            }
        }
    }
}
