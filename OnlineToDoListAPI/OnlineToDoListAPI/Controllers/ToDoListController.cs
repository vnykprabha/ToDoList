using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineToDoList.BusinessService.Interface;
using OnlineToDoList.Entities.Entities;

namespace OnlineTODoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        public IToDoListService _toDoListBusinessService;

        public ToDoListController(IToDoListService toDoListBusinessService)
        {
            this._toDoListBusinessService = toDoListBusinessService;
        }
      
        [HttpGet]
        public List<ToDoItem> GetAllToDoItems()
        {
            return _toDoListBusinessService.GetAllToDoItems();
        }               

        [HttpPost]
        public Response AddToDoItem(ToDoItem item)
        {
            return _toDoListBusinessService.AddToDoItem(item);
        }

        [HttpPut]
        public Response EditToDoItem(ToDoItem item)
        {
            return _toDoListBusinessService.EditToDoItem(item);
        }

        [HttpDelete("{id}")]
        public Response DeleteToDoItem(int id)
        {
            return _toDoListBusinessService.DeleteToDoItem(id);           
        }
    }
}
