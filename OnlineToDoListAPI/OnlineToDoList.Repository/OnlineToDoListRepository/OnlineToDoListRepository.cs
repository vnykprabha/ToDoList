using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OnlineToDoList.Repository.Interface;
using OnlineToDoList.DataAccess.DBContext;
using System.Linq;
using OnlineToDoList.Entities.Entities;
using OnlineToDoList.Common.Enums;
using Microsoft.Extensions.Options;
using OnlineToDoList.Common.Extensions;
using Microsoft.EntityFrameworkCore.InMemory;

namespace OnlineToDoList.Repository.OnlineToDoListRepository
{
    public class OnlineToDoListRepository : IDBContextRepository
    {
        public ToDoListDBContext _dbContext { get; set; }
        public OnlineToDoListRepository(ToDoListDBContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public List<T> GetAll<T>(T entity) where T : class
        {
            List<T> result = new List<T>();
            try
            {
                DbSet<T> DbSet = _dbContext.Set<T>();
                IQueryable<T> data = DbSet.AsNoTracking();
                if(data != null)
                {
                    result = result.ToList();
                }               
            }
            catch(Exception ex)
            {
                
            }

            return result;
        }

        public Response Insert<T>(T entity) where T : class
        {
            Response obj = new Response();
            try
            {
                _dbContext.Set<T>().Add(entity);                
                _dbContext.SaveChanges();

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

        public Response Update<T>(T entity) where T : class
        {
            Response obj = new Response();
            try
            {
                _dbContext.Set<T>().Update(entity);
                _dbContext.SaveChanges();

                obj.Result = true;
                obj.Message = OnlinToDoListEnum.Result.Success.ToDescriptionString();
            }
            catch (Exception ex)
            {
                obj.Result = false;
                obj.Message = OnlinToDoListEnum.Result.Failed.ToDescriptionString();
            }

            return obj;
        }

        public Response Delete<T>(T entity) where T : class
        {
            Response obj = new Response();
            try
            {
                _dbContext.Remove(entity);
                _dbContext.SaveChanges();

                obj.Result = true;
                obj.Message = OnlinToDoListEnum.Result.Success.ToDescriptionString();
            }
            catch (Exception ex)
            {
                obj.Result = false;
                obj.Message = OnlinToDoListEnum.Result.Failed.ToDescriptionString();
            }

            return obj;
        }
    }
}
