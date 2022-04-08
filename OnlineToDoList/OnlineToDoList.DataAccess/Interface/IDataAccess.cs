using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;

namespace OnlineToDoList.DataAccess.Interface
{
    public interface IDataAccess
    {
        HttpResponseMessage ProcessGet(string url);
        HttpResponseMessage ProcessPost<T>(string url, T entity) where T : class;
        HttpResponseMessage ProcessPut<T>(string url, T entity) where T : class;
        HttpResponseMessage ProcessDelete(string url);
    }
}
