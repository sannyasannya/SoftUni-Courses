using RestSharpServices;
using System.Net;
using System.Reflection.Emit;
using System.Text.Json;
using RestSharp;
using RestSharp.Authenticators;
using NUnit.Framework.Internal;
using RestSharpServices.Models;
using System;
using static NUnit.Framework.Constraints.Tolerance;

namespace TestGitHubApi
{
    public class TestGitHubApi
    {
        private GitHubApiClient client;
        private static string repo;
        private static int lastCreatedIssueNumber;
        private static int lastCreatedCommentId;
        

        [SetUp]
        public void Setup()
        {            
            client = new GitHubApiClient("https://api.github.com/repos/testnakov/", "sannyasannya", "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");
            repo = "test-nakov-repo";
        }


        [Test, Order (1)]
        public void Test_GetAllIssuesFromARepo()
        {
            // Arrange
            //repo, which is in set up

            // Act
            var issues = client.GetAllIssues(repo);


            // Assert
            Assert.That(issues, Has.Count.GreaterThan(0),
                "There should be more than one issue.");

            foreach (var issue in issues)
            {
                Assert.That(issue.Id, Is.GreaterThan(0),
                    "Issue ID should be greater than 0.");
                Assert.That(issue.Number, Is.GreaterThan(0),
                    "Issue Number should be greater than 0.");
                Assert.That(issue.Title, Is.Not.Empty,
                    "Issue Title should not be empty.");

            }

        }

        [Test, Order (2)]
        public void Test_GetIssueByValidNumber()
        {
            // Arrange
            int issueNumber = 1;

            // Act
            var issue = client.GetIssueByNumber(repo, issueNumber);

            // Assert
            Assert.That(issue, Is.Not.Null,
                "The response shpuld contain issue data.");
            Assert.That(issue.Id, Is.GreaterThan(0),
                    "Issue ID should be greater than 0.");
            Assert.That(issue.Number, Is.EqualTo(issueNumber),
                "Issue Number should be as requested.");
            Assert.That(issue.Title, Is.Not.Empty,
                "Issue Title should not be empty.");

        }
        
        [Test, Order (3)]
        public void Test_GetAllLabelsForIssue()
        {
            // Arrange
            int issueNumber = 6;

            // Act
            var labels = client.GetAllLabelsForIssue(repo, issueNumber);

            // Assert
            Assert.That(labels.Count, Is.GreaterThan(0),
                "There should be labels on the issue.");

            foreach (var label in labels)
            {
                Assert.That(label.Id, Is.GreaterThan(0),
                    "Label ID should be greater than 0.");
                Assert.That(label.Name, Is.Not.Empty,
                    "Label Name should not be empty.");

                Console.WriteLine($"Label: {label.Id} - Name: {label.Name}");
            }
        }

        [Test, Order (4)]
        public void Test_GetAllCommentsForIssue()
        {
            // Arrange
            int issueNumber = 6;

            // Act
            var comments = client.GetAllCommentsForIssue(repo, issueNumber);

            // Assert
            Assert.That(comments.Count, Is.GreaterThan(0),
                "There should be comments on the issue.");

            foreach (var comment in comments)
            {
                Assert.That(comment.Id, Is.GreaterThan(0),
                    "Comment ID should be greater than 0.");
                Assert.That(comment.Body, Is.Not.Empty,
                    "Comment body should not be empty.");

                Console.WriteLine($"Comment: {comment.Id} - Body: {comment.Body}");
            }
        }

        [Test, Order(5)]
        public void Test_CreateGitHubIssue()
        {
            // Arrange
            string title = "New title";
            string body = "New body for GitHub Issue";

            // Act
            var issue = client.CreateIssue(repo, title, body);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(issue.Id, Is.GreaterThan(0),
               "The new issue should have ID");
                Assert.That(issue.Number, Is.GreaterThan(0));
                Assert.That(issue.Body, Is.EqualTo(body));
                Assert.That(issue.Title, Is.Not.Empty);
            });

            Console.WriteLine(issue.Number);
            lastCreatedIssueNumber = issue.Number;
        }

        [Test, Order (6)]
        public void Test_CreateCommentOnGitHubIssue()
        {
            // Arrange
            int issueNumber = lastCreatedIssueNumber;
            string body = "New body for GitHub Issue";

            // Act
            var comment = client.CreateCommentOnGitHubIssue(repo, issueNumber, body);

            // Assert
            Assert.That(comment.Body, Is.EqualTo(body));
            Console.WriteLine(comment.Id);
            lastCreatedCommentId = comment.Id;

        }

        [Test, Order (7)]
        public void Test_GetCommentById()
        {
            // Arrange
            int commentId = lastCreatedCommentId;

            // Act
            var comment = client.GetCommentById(repo, commentId);

            // Assert
            Assert.That(comment, Is.Not.Null);
            Assert.That(comment.Id, Is.EqualTo(commentId));
            
        }


        [Test, Order (8)]
        public void Test_EditCommentOnGitHubIssue()
        {
            // Arrange
            int commentId = lastCreatedCommentId;
            string newBody = "This is an edited comment on GitHub Issue.";

            // Act
            var updatedComment = client.EditCommentOnGitHubIssue(repo, commentId, newBody);

            // Assert
            Assert.That(updatedComment, Is.Not.Null);
            Assert.That(updatedComment.Id, Is.EqualTo(commentId));
            Assert.That(updatedComment.Body, Is.EqualTo(newBody));

            Console.WriteLine(updatedComment.Body);

        }

        [Test, Order (9)]
        public void Test_DeleteCommentOnGitHubIssue()
        {
            // Arrange
            int commentId = lastCreatedCommentId;
            
            // Act
            bool result = client.DeleteCommentOnGitHubIssue(repo, commentId);

            // Assert
            Assert.That(result, Is.True);

        }


    }
}

