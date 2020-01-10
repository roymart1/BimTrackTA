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
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            
            IssueApi issueApi = new IssueApi();
            List<Issue> listIssue =  issueApi.GetIssueList(hubId, projectId);
        }    
        
        [Test]
        public void Test_CreateIssue()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            
            Issue issue = new Issue();
            issue.Title = "AutoNewIssue";
            
            IssueApi issueApi = new IssueApi();
            issueApi.CreateIssue(hubId, projectId, issue);
        }

        [Test]
        public void Test_GetIssueDetails()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int issueId = __GetIssueRandom(hubId, projectId);
            
            IssueApi issueApi = new IssueApi();
            Issue issue = issueApi.GetIssue(hubId, projectId, issueId);
        }

        [Test]
        public void Test_PatchIssues()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            string path = "/ZoneId";
            int value = 1234; 
            
            IssueApi issueApi = new IssueApi();
            issueApi.PatchIssues(hubId, projectId, path, value);
        }
        
        [Test]
        public void Test_UpdateIssue()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int issueId = __GetIssueRandom(hubId, projectId, "AutoNewIssue");
            
            // TODO: Issue can't be found and it doesn't appear to be on my side (doesn't work with API too)...
            // Hypothesis: I need to have a real type, priority and status id for it to work appropriately.
            Issue issue = new Issue();
            issue.Title = "UpdatedNewIssue";
            issue.TypeId = 1;
            issue.PriorityId = 1;
            issue.StatusId = 1;
            
            IssueApi issueApi = new IssueApi();
            issueApi.UpdateIssue(hubId, projectId, issueId, issue);
        }

        [Test]
        public void Test_GetIssueHistory()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int issueId = __GetIssueRandom(hubId, projectId, "AutoNewIssue");
            
            IssueApi issueApi = new IssueApi();
            issueApi.GetIssueHistory(hubId, projectId, issueId);
        }

        [Test]
        public void Test_ArchiveIssue()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int issueId = __GetIssueRandom(hubId, projectId, "AutoNewIssue");
            
            IssueApi issueApi = new IssueApi();
            issueApi.ArchiveIssue(hubId, projectId, issueId);
        }
    }
}