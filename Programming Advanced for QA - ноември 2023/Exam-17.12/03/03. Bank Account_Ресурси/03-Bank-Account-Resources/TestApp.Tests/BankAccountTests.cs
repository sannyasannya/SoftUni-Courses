using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class BankAccountTests    
{
    private BankAccount _bankAccount;
    [SetUp]
    public void SetUp()
    {
        this._bankAccount = new BankAccount(100);
    }

    [Test]
    public void Test_Constructor_InitialBalanceIsSet()
    {
        // Arrange


        // Act
        var result = this._bankAccount.Balance;

        // Assert
        Assert.That(result, Is.EqualTo(100));
    }

    [Test]
    public void Test_Deposit_PositiveAmount_IncreasesBalance()
    {
        // Arrange
        


        // Act
        this._bankAccount.Deposit(100);


        // Assert
        Assert.That(this._bankAccount.Balance, Is.EqualTo(200));
    }

    [Test]
    public void Test_Deposit_NegativeAmount_ThrowsArgumentException()
    {
        // Arrange
               

        // Act & Assert
        Assert.That(() => this._bankAccount.Deposit(-20), Throws.ArgumentException);
    }

    [Test]
    public void Test_Withdraw_ValidAmount_DecreasesBalance()
    {
        // Arrange
        
        

        // Act
        this._bankAccount.Withdraw(10);
        

        // Assert
        Assert.That(this._bankAccount.Balance, Is.EqualTo(90));
       
    }

    [Test]
    public void Test_Withdraw_NegativeAmount_ThrowsArgumentException()
    {
        // Arrange
           

        // Act & Assert
        Assert.That(() => this._bankAccount.Withdraw(-20), Throws.ArgumentException);
    }

    [Test]
    public void Test_Withdraw_AmountGreaterThanBalance_ThrowsArgumentException()
    {
        // Arrange
      

        // Act & Assert
        Assert.That(() => this._bankAccount.Withdraw(300), Throws.ArgumentException);
    }
}
