using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineToDoList.BusinessService.Interface;
using OnlineToDoList.Entities.Entities;
using OnlineToDoList.Repository.Interface;
using OnlineToDoList.Common.Enums;
using OnlineToDoList.Common.Extensions;
using Microsoft.EntityFrameworkCore;

namespace OnlineToDoList.BusinessService.BusinessService
{
    public class ToDoListService : IToDoListService
    {
        public IDBContextRepository _toDoListRepository { get; set; }
        public ToDoListService(IDBContextRepository toDoListRepository)
        {
            this._toDoListRepository = toDoListRepository;
        }
        public List<ToDoItem> GetAllToDoItems()
        {
           return _toDoListRepository._dbContext.ToDoItems.ToList();
        }
        public Response AddToDoItem(ToDoItem item)
        {
            Response obj = new Response();
            item.CreatedDate = DateTime.Now;            
            try
            {
                _toDoListRepository._dbContext.Add(item);
                _toDoListRepository._dbContext.SaveChanges();

                obj.Result = true;
                obj.Message = OnlinToDoListEnum.Result.Success.ToDescriptionString();
            }
            catch(Exception ex)
            {
                obj.Result = false;
                obj.Message = OnlinToDoListEnum.Result.Failed.ToDescriptionString();
            }

            return obj;
        }
        public Response EditToDoItem(ToDoItem item)
        {
            Response obj = new Response();

            var toDoItem = _toDoListRepository._dbContext.ToDoItems.AsNoTracking().Where(_i => _i.Id == item.Id).FirstOrDefault();
            if (toDoItem == null)
            {
                obj.Result = false;
                obj.Message = OnlinToDoListEnum.Result.Failed.ToDescriptionString();
            }
            else
            {
                try
                {
                    item.ModifiedDate = DateTime.Now;
                    _toDoListRepository._dbContext.Update(item);
                    _toDoListRepository._dbContext.SaveChanges();

                    obj.Result = true;
                    obj.Message = OnlinToDoListEnum.Result.Success.ToDescriptionString();
                }
                catch (Exception ex)
                {
                    obj.Result = false;
                    obj.Message = OnlinToDoListEnum.Result.Failed.ToDescriptionString();
                }               
            }

            return obj;
        }

        public Response DeleteToDoItem(int ID)
        {
            Response obj = new Response();

            var toDoItem = _toDoListRepository._dbContext.ToDoItems.AsNoTracking().Where(_i => _i.Id == ID).FirstOrDefault();
            if (toDoItem == null)
            {
                obj.Result = true;
                obj.Message = OnlinToDoListEnum.Result.Failed.ToDescriptionString();
            }
            else
            {
                try
                {
                    _toDoListRepository._dbContext.Remove(toDoItem);
                    _toDoListRepository._dbContext.SaveChanges();

                    obj.Result = true;
                    obj.Message = OnlinToDoListEnum.Result.Success.ToDescriptionString();
                }
                catch (Exception ex)
                {
                    obj.Result = true;
                    obj.Message = OnlinToDoListEnum.Result.Failed.ToDescriptionString();
                }                              
            }

            return obj;
        }
    }
}
