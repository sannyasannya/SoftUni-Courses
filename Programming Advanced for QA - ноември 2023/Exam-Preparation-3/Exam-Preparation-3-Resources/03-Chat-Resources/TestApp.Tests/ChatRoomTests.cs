using System;

using NUnit.Framework;

using TestApp.Chat;

namespace TestApp.Tests;

[TestFixture]
public class ChatRoomTests
{
    private ChatRoom _chatRoom = null!;
    
    [SetUp]
    public void Setup()
    {
        this._chatRoom = new();
    }
    
    [Test]
    public void Test_SendMessage_MessageSentToChatRoom()
    {
        // Arrange
        string sender = "Sanya";
        string message = "Hello";

        // Act
        this._chatRoom.SendMessage(sender, message);
        string result = this._chatRoom.DisplayChat();

        // Assert        
        Assert.That(result, Does.Contain("Sanya: Hello - Sent at "));
    }

    [Test]
    public void Test_DisplayChat_NoMessages_ReturnsEmptyString()
    {

        // Arrange       

        // Act        
        string result = this._chatRoom.DisplayChat();

        // Assert 
        Assert.That(result, Does.Contain("Chat Room Messages:"));
    }

    [Test]
    public void Test_DisplayChat_WithMessages_ReturnsFormattedChat()
    {
        // Arrange
        string sender = "Sanya";
        string sender2 = "Deni";
        string message = "Hello";
        string message2 = "Hi";

        // Act
        this._chatRoom.SendMessage(sender, message);
        this._chatRoom.SendMessage(sender2, message2);
        string result = this._chatRoom.DisplayChat();

        // Assert
        Assert.That(result, Does.Contain("Chat Room Messages:"));
        Assert.That(result, Does.Contain($"Sanya: Hello - Sent at "));
        Assert.That(result, Does.Contain($"Deni: Hi - Sent at "));
        
    }
}
