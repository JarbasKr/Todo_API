using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.EntityTests
{
    [TestClass]
    public class TodoItemTests

    {
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand(Guid.NewGuid(),"","Jarbas",DateTime.Now);
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand(Guid.NewGuid(),"Ze","Jarbas",DateTime.Now);
        private readonly TodoHandler _handler = new TodoHandler (new FakeTodoRepository());
        private GenericCommandResult _result = new GenericCommandResult();
        private readonly TodoItem _validTodo = new TodoItem (Guid.NewGuid(), "", DateTime.Now, "Jarbas");

        [TestMethod]
        public void TodoItem_Should_Not_Be_Completed()
        {
            Assert.AreEqual(_validTodo.Done, false);
        }
    }
}