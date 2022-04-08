using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OnlineToDoList.DataAccess.DBContext;
using OnlineToDoList.Entities.Entities;
using OnlineToDoList.BusinessService.Interface;
using OnlineToDoList.BusinessService.BusinessService;
using OnlineToDoList.Repository.Interface;
using OnlineToDoList.Repository.OnlineToDoListRepository;

namespace OnlineTODoList
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IToDoListService, ToDoListService>();
            services.AddTransient<IDBContextRepository, OnlineToDoListRepository>();
            services.AddDbContext<ToDoListDBContext>(options => options.UseInMemoryDatabase(Configuration.GetConnectionString("ToDoListDB")));
            services.AddControllers();
            services.AddSwaggerGen(c => c.SwaggerDoc("v2", new OpenApiInfo { Title = "ToDoListAPI", Version = "v2" }));
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v2/swagger.json", "To Do List"));

            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<ToDoListDBContext>();
            AddSeedData(context);
        }

        public static void AddSeedData(ToDoListDBContext dbContext)
        {
            ToDoItem itemOne = new ToDoItem { Id = 1, Title = "Excercise", Description = "Morning Excercise", CreatedDate = DateTime.Now };
            ToDoItem itemTwo = new ToDoItem { Id = 2, Title = "Drop Children", Description = "Drop children to school", CreatedDate = DateTime.Now };

            dbContext.Add(itemOne);
            dbContext.Add(itemTwo);
            dbContext.SaveChanges();
        }
    }
}
