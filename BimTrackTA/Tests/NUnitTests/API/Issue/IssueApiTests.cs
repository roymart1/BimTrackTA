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
        public void Test1_CreateIssue()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);

            Issue issue = new Issue
            {
                Title = "AutoNewIssue",
                TypeId = __GetProjectTypeRandom(hubId, projectId),
                PriorityId = __GetProjectPriorityRandom(hubId, projectId),
                StatusId = __GetProjectStatusRandom(hubId, projectId)
            };
            IssueApi issueApi = new IssueApi();
            issueApi.CreateIssue(hubId, projectId, issue);
        }
        
        [Test, Order(2)]
        public void Test2_GetIssueList()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            
            IssueApi issueApi = new IssueApi();
            issueApi.GetIssueList(hubId, projectId);
        }    

        [Test, Order(3)]
        public void Test3_GetIssueDetails()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int issueId = __GetIssueRandom(hubId, projectId, "AutoNewIssue", true);
            
            IssueApi issueApi = new IssueApi();
            issueApi.GetIssue(hubId, projectId, issueId);
        }

        [Test, Order(4)]
        public void Test4_PatchIssues()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int issueId = __GetIssueRandom(hubId, projectId, "AutoNewIssue", true);

            int priorityId = __GetProjectPriorityRandom(hubId, projectId);
            
            MultiUpdate.Operation operation = new MultiUpdate.Operation {value = priorityId, path = "/PriorityId"};
            List<MultiUpdate.Operation> operations = new List<MultiUpdate.Operation> {operation};
            List<int> issueIds = new List<int> {issueId};
            MultiUpdate multiUpdate = new MultiUpdate {Operations = operations, IssueIds = issueIds};

            IssueApi issueApi = new IssueApi();
            issueApi.PatchIssues(hubId, projectId, multiUpdate);
        }

        [Test, Order(5)]
        public void Test5_GetIssueHistory()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int issueId = __GetIssueRandom(hubId, projectId, "AutoNewIssue", true);
            
            IssueApi issueApi = new IssueApi();
            issueApi.GetIssueHistory(hubId, projectId, issueId);
        }
        
        [Test, Order(6)]
        public void Test6_UpdateIssue()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int issueId = __GetIssueRandom(hubId, projectId, "AutoNewIssue", true);

            Issue issue = new Issue
            {
                Title = "UpdatedNewIssue",
                TypeId = __GetProjectTypeRandom(hubId, projectId),
                StatusId = __GetProjectStatusRandom(hubId, projectId),
                PriorityId = __GetProjectPriorityRandom(hubId, projectId)
            };
            IssueApi issueApi = new IssueApi();
            issueApi.UpdateIssue(hubId, projectId, issueId, issue);
        }

        [Test, Order(7)]
        public void Test7_ArchiveAndDeleteIssue()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int issueId = __GetIssueRandom(hubId, projectId, "UpdatedNewIssue", true);
            
            IssueApi issueApi = new IssueApi();
            issueApi.ArchiveIssue(hubId, projectId, issueId);
            
            // Now that it has been archived, delete it
            IssueArchivedApi issueArchivedApi = new IssueArchivedApi();
            issueArchivedApi.DeleteArchivedIssue(hubId, projectId, issueId);
        }
    }
}