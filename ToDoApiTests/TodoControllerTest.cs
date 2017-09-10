using System;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using ToDoApi.Controllers;
using ToDoApi.Models;
using Xunit;

namespace ToDoApiTests
{
    public class TodoControllerTest
    {
		[Fact]
		public void GetAll_ReturnsAllToDoItems()
        {
            var options = new DbContextOptionsBuilder<ToDoContext>()
				.UseInMemoryDatabase(databaseName: "ControllerTest")
				.Options;

            var context = new ToDoContext(options);
			var controller = new ToDoController(context);

			var items = controller.GetAll();

            Assert.NotEmpty(items);
            Assert.Equal(context.ToDoItems, items);
		}

		[Fact]
		public void GetById_ReturnsNotFound_ForInvalidId()
		{
			var options = new DbContextOptionsBuilder<ToDoContext>()
				.UseInMemoryDatabase(databaseName: "ControllerTest")
				.Options;

			var context = new ToDoContext(options);
			var controller = new ToDoController(context);

            var result = controller.GetById(123);

			Assert.IsType<NotFoundResult>(result);
		}

		[Fact]
		public void GetById_ReturnsToDoItem_ForTheGivenId()
		{
			var options = new DbContextOptionsBuilder<ToDoContext>()
				.UseInMemoryDatabase(databaseName: "ControllerTest")
				.Options;

			var context = new ToDoContext(options);
            ToDoItem new_item = new ToDoItem { Name = "New_Item" };

            context.ToDoItems.Add(new_item);

			var controller = new ToDoController(context);

            var result = controller.GetById(new_item.Id);

            var okResult = Assert.IsType<ObjectResult>(result);
            var returnItem = Assert.IsType<ToDoItem>(okResult.Value);

            Assert.Equal("New_Item", returnItem.Name);
		}
    }
}
