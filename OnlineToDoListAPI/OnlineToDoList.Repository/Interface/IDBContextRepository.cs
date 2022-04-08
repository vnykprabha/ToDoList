using System;
using System.Collections.Generic;
using System.Text;
using OnlineToDoList.DataAccess.DBContext;
using System.Collections.Generic;
using OnlineToDoList.Entities.Entities;

namespace OnlineToDoList.Repository.Interface
{
    public interface IDBContextRepository
    {
        ToDoListDBContext _dbContext { get; set; }

        List<T> GetAll<T>(T entity) where T : class;
        Response Insert<T>(T entity) where T : class;
        Response Update<T>(T entity) where T : class;
        Response Delete<T>(T entity) where T : class;

    }
}
