using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class ArticleTests
{
    private Article _article;

    [SetUp]
    public void SetUp()
    {
        this._article = new Article();
    }
        
    [Test]
    public void Test_AddArticles_ReturnsArticleWithCorrectData()
    {
        // Arrange
        string[] articleData =
        {
            "Article Content Author",
            "Article2 Content2 Author2",
            "Article3 Content3 Author3"
        };

        // Act
        Article result = this._article.AddArticles(articleData);

        // Assert
        Assert.That(result.ArticleList, Has.Count.EqualTo(3));
        Assert.That(result.ArticleList[0].Title, Is.EqualTo("Article"));
        Assert.That(result.ArticleList[1].Content, Is.EqualTo("Content2"));
        Assert.That(result.ArticleList[2].Author, Is.EqualTo("Author3"));
    }

    [Test]
    public void Test_GetArticleList_SortsArticlesByTitle()
    {
        // Arrange
        Article inputArticle = new Article()
        {
            ArticleList = new()
            {
                new Article()
                {
                    Author = "Sanya",
                    Content = "Some Content",
                    Title = "Title1"
                },
                new Article()
                {
                    Author = "Deni",
                    Content = "Content 2",
                    Title = "Title2"
                }
            }
        };
        string expected = $"Title1 - Some Content: Sanya{Environment.NewLine}Title2 - Content 2: Deni";

        // Act
        string result = this._article.GetArticleList(inputArticle, "title");

        // Assert
        Assert.That(result, Is.EqualTo(expected));

    }

    [Test]
    public void Test_GetArticleList_ReturnsEmptyString_WhenInvalidPrintCriteria()
    {

        // Arrange
        Article inputArticle = new Article()
        {
            ArticleList = new()
            {
                new Article()
                {
                    Author = "Sanya",
                    Content = "Some Content",
                    Title = "Title1"
                },
                new Article()
                {
                    Author = "Deni",
                    Content = "Content 2",
                    Title = "Title2"
                }
            }
        };
       

        // Act
        string result = this._article.GetArticleList(inputArticle, "not-criteria");

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_GetArticleList_ReturnsEmptyString_WhenArticleHasNoArticlesInList()
    {

        // Arrange
        Article inputArticle = new Article()
        {
            ArticleList = new()
            
        };

        // Act
        string result = this._article.GetArticleList(inputArticle, "title");

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_GetArticleList_SortsArticlesByContent()
    {
        // Arrange
        Article inputArticle = new Article()
        {
            ArticleList = new()
            {
                new Article()
                {
                    Author = "Sanya",
                    Content = "Some Content",
                    Title = "Title1"
                },
                new Article()
                {
                    Author = "Deni",
                    Content = "Content 2",
                    Title = "Title2"
                }
            }
        };
        string expected = $"Title2 - Content 2: Deni{Environment.NewLine}Title1 - Some Content: Sanya";

        // Act
        string result = this._article.GetArticleList(inputArticle, "content");

        // Assert
        Assert.That(result, Is.EqualTo(expected));

    }

    [Test]
    public void Test_GetArticleList_SortsArticlesByAuthor()
    {
        // Arrange
        Article inputArticle = new Article()
        {
            ArticleList = new()
            {
                new Article()
                {
                    Author = "Sanya",
                    Content = "Some Content",
                    Title = "Title1"
                },
                new Article()
                {
                    Author = "Deni",
                    Content = "Content 2",
                    Title = "Title2"
                }
            }
        };
        string expected = $"Title2 - Content 2: Deni{Environment.NewLine}Title1 - Some Content: Sanya";

        // Act
        string result = this._article.GetArticleList(inputArticle, "author");

        // Assert
        Assert.That(result, Is.EqualTo(expected));

    }
}
