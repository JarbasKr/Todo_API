using System.Reflection.Metadata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.EntityTests
{
    [TestClass]

    public class TodoQueryTests
    {
        private List<TodoItem> _items;

        public TodoQueryTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Test Chore 1", DateTime.Now, "Jarbas"));
            _items.Add(new TodoItem("Test Chore 2", DateTime.Now, "Jarbas"));
            _items.Add(new TodoItem("Test Chore 3", DateTime.Now, "Jarbas"));
            _items.Add(new TodoItem("Test Chore 4", DateTime.Now, "Jarbas"));
            _items.Add(new TodoItem("Test Chore 5", DateTime.Now, "Jarbas"));
            _items.Add(new TodoItem("Test Chore 6", DateTime.Now, "Jarbas"));
            
        }

        [TestMethod]
        public void TodoQuery_Should_Return_User_Jarbas_Chores()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("Jarbas"));
            Assert.AreEqual(2, result.Count());
        }
    }
}