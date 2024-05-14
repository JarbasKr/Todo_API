using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;


namespace Todo.Domain.Tests.HandlerTests
{
    [TestClass]
    public class CreateTodoHandlerTests
    {
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand(Guid.NewGuid(),"","Jarbas",DateTime.Now);
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand(Guid.NewGuid(),"Ze","Jarbas",DateTime.Now);
        private readonly TodoHandler _handler = new TodoHandler (new FakeTodoRepository());
        private GenericCommandResult _result = new GenericCommandResult();

        public CreateTodoHandlerTests()
        {
        }


        public void Invalid_Command()
        {
            _result = (GenericCommandResult)_handler.Handle(_invalidCommand);
            Assert.AreEqual(_result.Success, false);
        }

        [TestMethod]
        public void Valid_Command()
        {
            _result = (GenericCommandResult)_handler.Handle(_validCommand);
            Assert.AreEqual(_result.Success, true);
        }
}
}
