using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OnlineToDoList.Entities.Entities;

namespace OnlineToDoList.DataAccess.DBContext
{
    public class ToDoListDBContext : DbContext
    {
        public ToDoListDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
