using System;
using System.Collections.Generic;
using System.Text;
using OnlineToDoList.Repository.Interface;
using Moq;
using Xunit;
using OnlineToDoList.Entities.Entities;
using OnlineTODoList.Controllers;
using OnlineToDoList.BusinessService.Interface;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OnlineToDoList.Common.Extensions;
using OnlineToDoList.Common.Enums;

namespace OnlineToDoList.UnitTest
{
    public class ToDoListTests
    {
        [Fact]
        public void TestGetAllToDoItemsSuccess()
        {
            // Arrange
            var mockRepo = new Mock<IToDoListService>();
            mockRepo.Setup(repo => repo.GetAllToDoItems()).Returns(GetSampleToDoItem());
            var controller = new ToDoListController(mockRepo.Object);

            // Act
            var result = controller.GetAllToDoItems();

            // Assert
            var model = Assert.IsAssignableFrom<IEnumerable<ToDoItem>>(result);
            Assert.Equal(3, model.Count());
        }

        [Fact]
        public void TestAddToDoItemSuccess()
        {
            // Arrange

            ToDoItem item = new ToDoItem()
            {
                Id = 99,
                Title = "Client Meeting",
                Description = "Client Meeting at office",
                CreatedDate = DateTime.Now,
                ModifiedDate = null
            };

            Response res = new Response()
            {               
                Result = true,
                Message = OnlinToDoListEnum.Result.Success.ToDescriptionString()               
            };

            var mockRepo = new Mock<IToDoListService>();
            mockRepo.Setup(repo => repo.AddToDoItem(It.IsAny<ToDoItem>())).Returns(res).Verifiable();
            var controller = new ToDoListController(mockRepo.Object);

            // Act
            var result = controller.AddToDoItem(item);

            // Assert
            mockRepo.Verify();
            var toDolist = Assert.IsType<Response>(result);            
            Assert.True(toDolist.Result);
            Assert.Equal(OnlinToDoListEnum.Result.Success.ToDescriptionString(), toDolist.Message);           
        }


        [Fact]
        public void TestEditToDoItemSuccess()
        {
            // Arrange

            ToDoItem item = new ToDoItem()
            {
                Id = 53,
                Title = "Evening Coffee",
                Description = "Coffee with friends",
                CreatedDate = DateTime.Now,
                ModifiedDate = null
            };

            Response res = new Response()
            {               
                Result = true,
                Message = OnlinToDoListEnum.Result.Success.ToDescriptionString()
            };

            var mockRepo = new Mock<IToDoListService>();
            mockRepo.Setup(repo => repo.EditToDoItem(It.IsAny<ToDoItem>())).Returns(res).Verifiable(); 
            var controller = new ToDoListController(mockRepo.Object);

            // Act
            var result = controller.EditToDoItem(item);

            // Assert
            mockRepo.Verify();
            var toDolist = Assert.IsType<Response>(result);
            Assert.True(toDolist.Result);
            Assert.Equal(OnlinToDoListEnum.Result.Success.ToDescriptionString(), toDolist.Message);
        }

        [Fact]
        public void TestDeleteToDoItemSuccess()
        {
            // Arrange           

            Response res = new Response()
            {               
                Result = true,
                Message = OnlinToDoListEnum.Result.Success.ToDescriptionString()
            };

            var mockRepo = new Mock<IToDoListService>();
            mockRepo.Setup(repo => repo.DeleteToDoItem(It.IsAny<int>())).Returns(res).Verifiable(); 
            var controller = new ToDoListController(mockRepo.Object);

            // Act
            var result = controller.DeleteToDoItem(1);

            // Assert

            mockRepo.Verify();
            var toDolist = Assert.IsType<Response>(result);
            Assert.True(toDolist.Result);
            Assert.Equal(OnlinToDoListEnum.Result.Success.ToDescriptionString(), toDolist.Message);
        }

        private List<ToDoItem> GetSampleToDoItem()
        {
            List<ToDoItem> output = new List<ToDoItem>
            {
                new ToDoItem
                {
                    Id = 25,
                    Title = "Task1",
                    Description = "Description1",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null
                },
                new ToDoItem
                {
                    Id = 26,
                    Title = "Task2",
                    Description = "Description2",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null
                },
                new ToDoItem
                {
                    Id = 27,
                    Title = "Task3",
                    Description = "Description3",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null
                }
            };

            return output;
        }
    }
}
