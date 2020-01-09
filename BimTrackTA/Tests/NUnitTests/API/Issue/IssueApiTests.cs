using System.Collections.Generic;
using BimTrackTA.Common.WebDriver;
using BimTrackTA.API;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class IssueApiTests : GeneralTestBase
    {
        [Test]
        public void Test_GetIssueList()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            
            IssueApi issueApi = new IssueApi();
            List<Issue> listIssue =  issueApi.GetIssueList(hubId, projectId);
        }    
        
        [Test]
        public void Test_CreateIssue()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            
            Issue issue = new Issue();
            issue.Title = "AutoNewIssue";
            
            IssueApi issueApi = new IssueApi();
            issueApi.CreateIssue(hubId, projectId, issue);
        }

        [Test]
        public void Test_GetIssueDetails()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int issueId = __GetIssueRandom(hubId, projectId);
            
            IssueApi issueApi = new IssueApi();
            Issue issue = issueApi.GetIssue(hubId, projectId, issueId);
        }

        [Test]
        public void Test_PatchIssues()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            string path = "/ZoneId";
            int value = 1234; 
            
            IssueApi issueApi = new IssueApi();
            issueApi.PatchIssues(hubId, projectId, path, value);
        }
        
        [Test]
        public void Test_UpdateIssue()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int issueId = __GetIssueRandom(hubId, projectId);
            
            Issue issue = new Issue();
            issue.Title = "UpdatedNewIssue";
            issue.Type = new BimType {Name = "Issue"};
            
            // TODO: See what are the required parameters.
            IssueApi issueApi = new IssueApi();
            issueApi.UpdateIssue(hubId, projectId, issueId, issue);
        }

        [Test]
        public void Test_GetIssueHistory()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int issueId = __GetIssueRandom(hubId, projectId);
            
            IssueApi issueApi = new IssueApi();
        }

        [Test]
        public void Test_ArchiveIssue()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int issueId = __GetIssueRandom(hubId, projectId);
            
            IssueApi issueApi = new IssueApi();
            issueApi.ArchiveIssue(hubId, projectId, issueId);
        }
    }
}