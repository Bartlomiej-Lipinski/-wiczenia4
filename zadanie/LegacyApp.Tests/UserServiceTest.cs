using System;
using JetBrains.Annotations;
using LegacyApp;
using Xunit;

namespace LegacyApp.Tests;

[TestSubject(typeof(UserService))]
public class UserServiceTest
{

    [Fact]
    public void AddUser_Should_Return_False_When_Missing_FirstName()
    {
        // Arrange
        var userService = new UserService();
        var addResult = userService.AddUser("", "Doe", "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 1);
        Assert.False(addResult);
    }
    [Fact]
    public void AddUser_Should_Return_False_When_Missing_LastName()
    {
        // Arrange
        var userService = new UserService();
        var addResult = userService.AddUser("John", "", "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 1);
        Assert.False(addResult);
    }


    [Fact]
    public void AddUser_Should_Return_False_When_Missing_At_Sign_And_Dot_In_Email()
    {
        var userService = new UserService();
        var addResult = userService.AddUser("John", "Doe", "johndoegmailcom", DateTime.Parse("1982-03-21"), 1);
        Assert.False(addResult);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_Younger_Then_21_Years_Old()
    {
        var userService = new UserService();
        var addResult = userService.AddUser("John", "", "johndoe@gmail.com", DateTime.Parse("2020-03-21"), 1);
        Assert.False(addResult);
    }

    [Fact]
    public void AddUser_Should_Throw_Exception_When_User_Does_Not_Exist()
    {
        var userService = new UserService();
        Assert.Throws<ArgumentException> (() =>
        {
            userService.AddUser("John", "Doe", "johndoe@gmail.com", DateTime.Parse("1982-03-21"),0);
        });
    }
    
    [Fact]
    public void AddUser_Should_Return_True_When_Very_Important_Client()
    {
        var userService = new UserService();
        var addResult = userService.AddUser("John", "Malewski", "malewski@gmail.pl", DateTime.Parse("1982-03-21"), 2);
        Assert.True(addResult);
    }
    [Fact]
    public void AddUser_Should_Return_True_When_Important_Client()
    {
        var userService = new UserService();
        var addResult = userService.AddUser("John", "Smith", "smith@gmail.pl", DateTime.Parse("1982-03-21"), 3);
        Assert.True(addResult);
    }

    [Fact]
    public void AddUser_Should_Return_True_When_Normal_Client()
    {
        var userService = new UserService();
        var addResult = userService.AddUser("John", "Kwiatkowski", "kwiatkowski@wp.pl", DateTime.Parse("1982-03-21"), 5);
        Assert.True(addResult);
    }
    [Fact]
    public void AddUser_Should_Throw_Exception_When_User_No_Credit_Limit_Exists_For_User()
    {
        var userService = new UserService();
        Assert.Throws<ArgumentException> (() =>
        {
            userService.AddUser("John", "Nowak", "Nowak@gmail.pl", DateTime.Parse("1982-03-21"), 3);
        });
    }

    [Fact]
    public void AddUser_Should_Return_False_When_User_Credit_Limit_Less_Than_500()
    {
        var userService = new UserService();
        var addResult = userService.AddUser("John", "Kowalski", "kowalski@wp.pl", DateTime.Parse("1982-03-21"), 1);
        Assert.False(addResult);
    }
}