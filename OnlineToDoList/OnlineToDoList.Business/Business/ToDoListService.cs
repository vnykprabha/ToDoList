using System;
using System.Collections.Generic;
using System.Text;
using OnlineToDoList.Business.Interface;
using OnlineToDoList.DTO.DTO;
using OnlineToDoList.DataAccess.Interface;
using System.Net.Http;
using OnlineToDoList.Common.Helpers;
using Newtonsoft.Json;

namespace OnlineToDoList.Business.Business
{
    public class ToDoListService
    {
        public IDataAccess _dataAccessService;
        public ToDoListService(IDataAccess dataAccessService)
        {
            this._dataAccessService = dataAccessService;
        }

        public string GetAllToDoItems()
        {
            string url = "";
            List<ToDoItem> listToDoItem = null;
            HttpResponseMessage resMessage = _dataAccessService.ProcessGet(url);
            if (resMessage.IsSuccessStatusCode)
            {
                ResponseResultExtractor extractor = new ResponseResultExtractor();
                listToDoItem = extractor.Extract<List<ToDoItem>>(resMessage);
            }

            return JsonConvert.SerializeObject(listToDoItem);
        }
    }
}
