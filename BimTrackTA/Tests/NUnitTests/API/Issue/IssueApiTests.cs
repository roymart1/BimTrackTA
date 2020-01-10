using System.Collections.Generic;
using BimTrackTA.Common.WebDriver;
using BimTrackTA.API;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class IssueApiTests : GeneralTestBase
    {
        [Test, Order(1)]
        public void Test_CreateIssue()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            
            Issue issue = new Issue();
            issue.Title = "AutoNewIssue";
            issue.TypeId = __GetProjectTypeRandom(hubId, projectId);
            issue.PriorityId = __GetProjectPriorityRandom(hubId, projectId);
            issue.StatusId = __GetProjectStatusRandom(hubId, projectId);
            
            IssueApi issueApi = new IssueApi();
            issueApi.CreateIssue(hubId, projectId, issue);
        }
        
        [Test, Order(2)]
        public void Test_GetIssueList()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            
            IssueApi issueApi = new IssueApi();
            List<Issue> listIssue =  issueApi.GetIssueList(hubId, projectId);
        }    

        [Test, Order(3)]
        public void Test_GetIssueDetails()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int issueId = __GetIssueRandom(hubId, projectId);
            
            IssueApi issueApi = new IssueApi();
            Issue issue = issueApi.GetIssue(hubId, projectId, issueId);
        }

        [Test, Order(4)]
        public void Test_PatchIssues()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int issueId = __GetIssueRandom(hubId, projectId, "AutoNewIssue");

            int priorityId = __GetProjectPriorityRandom(hubId, projectId);
            Operation operation = new Operation();
            operation.path = "/PriorityId";
            operation.value = priorityId;
            
            List<Operation> operations = new List<Operation>();
            operations.Add(operation);
            
            List<int> issueIds = new List<int>();
            issueIds.Add(issueId);
            
            MultiUpdate multiUpdate = new MultiUpdate();
            multiUpdate.Operations = operations;
            multiUpdate.IssueIds = issueIds;
            
            IssueApi issueApi = new IssueApi();
            issueApi.PatchIssues(hubId, projectId, multiUpdate);
        }
        
        [Test, Order(5)]
        public void Test_UpdateIssue()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int issueId = __GetIssueRandom(hubId, projectId, "AutoNewIssue");
            
            // TODO: Issue can't be found and it doesn't appear to be on my side (doesn't work with API too)...
            // Hypothesis: I need to have a real type, priority and status id for it to work appropriately.
            Issue issue = new Issue();
            issue.Title = "UpdatedNewIssue";
            issue.TypeId = __GetProjectTypeRandom(hubId, projectId);
            issue.PriorityId = __GetProjectPriorityRandom(hubId, projectId);
            issue.StatusId = __GetProjectStatusRandom(hubId, projectId);
            
            IssueApi issueApi = new IssueApi();
            issueApi.UpdateIssue(hubId, projectId, issueId, issue);
        }

        [Test, Order(6)]
        public void Test_GetIssueHistory()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int issueId = __GetIssueRandom(hubId, projectId, "AutoNewIssue");
            
            IssueApi issueApi = new IssueApi();
            issueApi.GetIssueHistory(hubId, projectId, issueId);
        }

        [Test, Order(7)]
        public void Test_ArchiveAndDeleteIssue()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int issueId = __GetIssueRandom(hubId, projectId, "AutoNewIssue");
            
            IssueApi issueApi = new IssueApi();
            issueApi.ArchiveIssue(hubId, projectId, issueId);
            
            // Now that it has been archived, delete it
            IssueArchivedApi issueArchivedApi = new IssueArchivedApi();
            issueArchivedApi.DeleteArchivedIssue(hubId, projectId, issueId);
        }
    }
}