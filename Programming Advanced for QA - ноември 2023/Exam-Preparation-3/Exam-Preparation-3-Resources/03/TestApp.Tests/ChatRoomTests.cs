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
        string sender = "Angel";
        string message = "Hello";

        // Act
        this._chatRoom.SendMessage(sender, message);
        string result = this._chatRoom.DisplayChat();

        // Assert
        Assert.That(result, Does.Contain("Chat Room Messages:"));
        Assert.That(result, Does.Contain($"Angel: Hello - Sent at "));
    }

    [Test]
    public void Test_DisplayChat_NoMessages_ReturnsEmptyString()
    {
        // Arrange

        // Act
        string result = this._chatRoom.DisplayChat();

        // Assert
        Assert.That(result, Is.EqualTo("Chat Room Messages:"));
    }

    [Test]
    public void Test_DisplayChat_WithMessages_ReturnsFormattedChat()
    {
        // Arrange
        string sender = "Angel";
        string sender2 = "Ani";
        string message = "Hello";
        string message2 = "Hi";

        // Act
        this._chatRoom.SendMessage(sender, message);
        this._chatRoom.SendMessage(sender2, message2);
        string result = this._chatRoom.DisplayChat();

        // Assert
        Assert.That(result, Does.Contain("Chat Room Messages:"));
        Assert.That(result, Does.Contain($"Angel: Hello - Sent at "));
        Assert.That(result, Does.Contain($"Ani: Hi - Sent at "));
    }
}
