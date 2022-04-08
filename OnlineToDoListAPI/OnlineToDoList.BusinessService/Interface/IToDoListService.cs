using OnlineToDoList.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineToDoList.BusinessService.Interface
{
    public interface IToDoListService
    {
        public List<ToDoItem> GetAllToDoItems();        
        public Response AddToDoItem(ToDoItem item);
        public Response EditToDoItem(ToDoItem item);
        public Response DeleteToDoItem(int ID);
    }
}
