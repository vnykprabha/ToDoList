using System;
using System.Collections.Generic;
using System.Text;
using OnlineToDoList.DTO.DTO;

namespace OnlineToDoList.Business.Interface
{
    public interface IToDoListService
    {
        string GetAllToDoItems();
        string AddToDoItem(ToDoItem item);
        string EditToDoItem(ToDoItem item);
        string DeleteToDoItem(int id);
    }
}
