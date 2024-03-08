using RestSharpServices;
using System.Net;
using System.Reflection.Emit;
using System.Text.Json;
using RestSharp;
using RestSharp.Authenticators;
using NUnit.Framework.Internal;
using RestSharpServices.Models;
using System;

namespace TestGitHubApi
{
    public class TestGitHubApi
    {
        private GitHubApiClient _client;
        private static string _repo;
        private static int _lastCreatedIssueNumber;
        private static int _lastCreatedCommentId;

        [SetUp]
        public void Setup()
        {

            _client = new GitHubApiClient("https://api.github.com/repos/testnakov/", "s-toshev", "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");

            _repo = "test-nakov-repo";

        }


        [Test, Order (1)]
        public void Test_GetAllIssuesFromARepo()
        {

            //Act
            var issues = _client.GetAllIssues(_repo);


            //Assert

            Assert.That(issues, Has.Count.GreaterThan(1), "There should be more than one issue.");

            foreach(var issue in issues)
            {
                Assert.Greater(issue.Id, 0, "Issue Id should be greater than 0.");
                Assert.That(issue.Number, Is.GreaterThan(0), "Issue Number should be greater than 0");
                Assert.That(issue.Title, Is.Not.Empty, "Issue Title should not be empty");
            }

        }

    



        [Test, Order (2)]
        public void Test_GetIssueByValidNumber()
        {
            //Arrange
            int issueNumber = 1;

            //Act
            var issue = _client.GetIssueByNumber(_repo, issueNumber);

            //Assert
            Assert.That(issue, Is.Not.Null);
            Assert.AreEqual(issue.Number, issueNumber);
            Assert.Greater(issue.Id, 0, "Issue Id should be greater than 0.");
            Assert.That(issue.Number, Is.GreaterThan(0), "Issue Number should be greater than 0");
            Assert.That(issue.Title, Is.Not.Empty, "Issue Title should not be empty");


        }

        [Test, Order (3)]
        public void Test_GetAllLabelsForIssue()
        {
            //Arrange
            int issueNumber = 6;


            //Act
            var issueLabels = _client.GetAllLabelsForIssue(_repo, issueNumber);

            //Assert
            Assert.That(issueLabels.Count, Is.GreaterThan(0));

            foreach(var label in issueLabels)
            {
                Assert.That(label.Id, Is.GreaterThan(0));
                Assert.That(label.Name, Is.Not.Empty);

                Console.WriteLine($"Label: {label.Id} - Name: {label.Name}");
            }

            //issueLabels.ForEach(x => Assert.That(x.Id, Is.GreaterThan(0)));
            //issueLabels.ForEach(x => Assert.That(x.Name, Is.Not.Empty));

        }

        [Test, Order (4)]
        public void Test_GetAllCommentsForIssue()
        {
            //Arrange
            int issueNumber = 1;


            //Act
            var issueComments = _client.GetAllCommentsForIssue(_repo, issueNumber);

            //Assert

            Assert.That(issueComments.Count, Is.GreaterThan(0));

            foreach (var comment in issueComments)
            {
                Assert.That(comment.Id, Is.GreaterThan(0));
                Assert.That(comment.Body, Is.Not.Empty);

                Console.WriteLine($"Comment Id: {comment.Id} - Comment Body: {comment.Body}");
            }
        }
        //Arrange


        //Act


        //Assert


        [Test, Order(5)]
        public void Test_CreateGitHubIssue()
        {
            
        }

        [Test, Order (6)]
        public void Test_CreateCommentOnGitHubIssue()
        {
           

         }

        [Test, Order (7)]
        public void Test_GetCommentById()
        {
            
        }


        [Test, Order (8)]
        public void Test_EditCommentOnGitHubIssue()
        {
           
        }

        [Test, Order (9)]
        public void Test_DeleteCommentOnGitHubIssue()
        {
           
        }


    }
}

