using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests
{
    [TestClass]
    public class CreateTodoCommandTests
{
    private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand(Guid.NewGuid(),"","Jarbas",DateTime.Now);

    private readonly CreateTodoCommand _validCommand = new CreateTodoCommand(Guid.NewGuid(),"Ze","Jarbas",DateTime.Now);

    public CreateTodoCommandTests()
    {
        _invalidCommand.Validate();
        _validCommand.Validate();
    }

    [TestMethod]
    public void Invalid_Command()
    {
        Assert.AreEqual(_invalidCommand.IsValid, false);
    }

    [TestMethod]
    public void Valid_Command()
    {
        Assert.AreEqual(_validCommand.IsValid, true);
    }
}
}