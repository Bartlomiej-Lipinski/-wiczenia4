using System;
using JetBrains.Annotations;
using LegacyApp;
using Xunit;

namespace LegacyApp.Tests;

[TestSubject(typeof(UserService))]
public class UserServiceTest
{

    [Fact]
    public void Testing_Name()
    {
        // Arrange
        var userService = new UserService();
        var addResult = userService.AddUser("", "Doe", "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 1);
        Assert.False(addResult);
    }
    [Fact]
    public void Testing_Surrname()
    {
        // Arrange
        var userService = new UserService();
        var addResult = userService.AddUser("John", "", "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 1);
        Assert.False(addResult);
    }
    [Fact]
    public void Testing_Mail()
    {
        // Arrange
        var userService = new UserService();
        var addResult = userService.AddUser("John", "Doe", "johndoegmailcom", DateTime.Parse("1982-03-21"), 1);
        Assert.False(addResult);
    }
}