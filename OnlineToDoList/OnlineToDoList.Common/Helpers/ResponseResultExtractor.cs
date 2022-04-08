using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;

namespace OnlineToDoList.Common.Helpers
{
    public class ResponseResultExtractor
    {
        public T Extract<T>(HttpResponseMessage response)
        {
            return response.Content.ReadAsAsync<T>().Result;
        }
    }
}
