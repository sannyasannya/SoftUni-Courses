using System;
using Microsoft.VisualBasic;
using NUnit.Framework;

using TestApp.Todo;

namespace TestApp.Tests;

[TestFixture]
public class ToDoListTests
{
    private ToDoList _toDoList = null!;
    
    [SetUp]
    public void SetUp()
    {
        this._toDoList = new();
    }
    
    [Test]
    public void Test_AddTask_TaskAddedToToDoList()
    {
        // Arrange
        string taskName = "my first task";
        DateTime taskDate = DateTime.Today;
        this._toDoList.AddTask(taskName, taskDate);

        // Act
        string result = this._toDoList.DisplayTasks();

        // Assert
        //Assert.That(result, Is.EqualTo($"To-Do List:{Environment.NewLine}[ ] {taskName} - Due: {taskDate.ToString("MM/dd/yyyy")}"));
        Assert.That(result, Does.Contain("[ ] my first task - Due:"));
    }

    [Test]
    public void Test_CompleteTask_TaskMarkedAsCompleted()
    {
        // Arrange
        string taskName = "task to  complete";
        DateTime taskDate = DateTime.Today;
        this._toDoList.AddTask(taskName, taskDate);
        this._toDoList.CompleteTask(taskName);

        // Act
        string result = this._toDoList.DisplayTasks();

        // Assert       
        Assert.That(result, Does.Contain("[✓] task to  complete - Due:"));
    }

    [Test]
    public void Test_CompleteTask_TaskNotFound_ThrowsArgumentException()
    {
        // Arrange
        string taskName = "task to  complete";

        // Act & Assert
        Assert.That(() => this._toDoList.CompleteTask(taskName), Throws.ArgumentException);

    }

    [Test]
    public void Test_DisplayTasks_NoTasks_ReturnsEmptyString()
    {
        // Arrange

        // Act
        string result = this._toDoList.DisplayTasks();

        // Assert
        Assert.That(result, Is.EqualTo("To-Do List:"));
    }

    [Test]
    public void Test_DisplayTasks_WithTasks_ReturnsFormattedToDoList()
    {

        // Arrange
        string taskName = "my first task";
        DateTime taskDate = DateTime.Today;
        this._toDoList.AddTask(taskName, taskDate);
        string taskName2 = "task to  complete";
        DateTime taskDate2 = DateTime.Today;
        this._toDoList.AddTask(taskName2, taskDate2);
        this._toDoList.CompleteTask(taskName2);

        // Act
        string result = this._toDoList.DisplayTasks();

        // Assert        
        Assert.That(result, Does.Contain("[ ] my first task - Due:"));
        Assert.That(result, Does.Contain("[✓] task to  complete - Due:"));
    }
}
