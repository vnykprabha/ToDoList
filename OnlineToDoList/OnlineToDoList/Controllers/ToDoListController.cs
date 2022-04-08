using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineToDoList.Business.Interface;

namespace OnlineToDoList.Controllers
{
    public class ToDoListController : Controller
    {
        public IToDoListService _service;

        public ToDoListController(IToDoListService service)
        {
            this._service = service;
        }
        public IActionResult ToDoList()
        {
            return View();
        }

        public string GetToDoList()
        {
           return  _service.GetAllToDoItems();
        }
    }
}
