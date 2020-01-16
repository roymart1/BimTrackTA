using System.Collections.Generic;
using BimTrackTA.Common.WebDriver;
using BimTrackTA.API;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class IssueArchivedApiTests : GeneralTestBase
    {
        [Test, Order(1)]
        public void Test1_CreateAndArchiveIssue()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);

            Issue issue = new Issue
            {
                Title = "AutoNewIssueToArchive",
                TypeId = __GetProjectTypeRandom(hubId, projectId),
                PriorityId = __GetProjectPriorityRandom(hubId, projectId),
                StatusId = __GetProjectStatusRandom(hubId, projectId)
            };
            IssueApi issueApi = new IssueApi();
            int issueId = issueApi.CreateIssue(hubId, projectId, issue);
            
            issueApi.ArchiveIssue(hubId, projectId, issueId);
        }
        
        [Test, Order(2)]
        public void Test2_GetIssueArchivedList()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            
            IssueArchivedApi issueArchivedApi = new IssueArchivedApi();
            issueArchivedApi.GetIssueArchivedList(hubId, projectId);
        }    
        
        [Test, Order(3)]
        public void Test3_GetIssueArchived()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int issueArchivedId = __GetArchivedIssueRandom(hubId, projectId, "AutoNewIssueToArchive", true);
            
            IssueArchivedApi issueArchivedApi = new IssueArchivedApi();
            issueArchivedApi.GetIssueArchived(hubId, projectId, issueArchivedId);
        }
        
        [Test, Order(4)]
        public void Test4_RestoreArchivedIssue()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int issueArchivedId = __GetArchivedIssueRandom(hubId, projectId, "AutoNewIssueToArchive", true);
            int statusId = __GetProjectStatusRandom(hubId, projectId);
            
            IssueArchivedApi issueArchivedApi = new IssueArchivedApi();
            issueArchivedApi.RestoreArchivedIssue(hubId, projectId, issueArchivedId, statusId);
        }

        [Test, Order(5)]
        public void Test5_RearchiveAndDeleteArchivedIssue()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int issueId = __GetIssueRandom(hubId, projectId, "AutoNewIssueToArchive", true);
            
            // Re-archive the issue since we restored it in test #4
            IssueApi issueApi = new IssueApi();
            issueApi.ArchiveIssue(hubId, projectId, issueId);
            
            // Now we can delete it
            int issueArchivedId = __GetArchivedIssueRandom(hubId, projectId);
            IssueArchivedApi issueArchivedApi = new IssueArchivedApi();
            issueArchivedApi.DeleteArchivedIssue(hubId, projectId, issueArchivedId);
        }
    }
}