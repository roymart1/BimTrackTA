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
        public void CreateAndArchiveIssue()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            
            Issue issue = new Issue();
            issue.Title = "AutoNewIssueToArchive";
            issue.TypeId = __GetProjectTypeRandom(hubId, projectId);
            issue.PriorityId = __GetProjectPriorityRandom(hubId, projectId);
            issue.StatusId = __GetProjectStatusRandom(hubId, projectId);
            
            IssueApi issueApi = new IssueApi();
            issueApi.CreateIssue(hubId, projectId, issue);
            
            int issueId = __GetIssueRandom(hubId, projectId, "AutoNewIssueToArchive");
            issueApi.ArchiveIssue(hubId, projectId, issueId);
        }
        
        [Test, Order(2)]
        public void Test_GetIssueArchivedList()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            
            IssueArchivedApi issueArchivedApi = new IssueArchivedApi();
            List<Issue> listIssue =  issueArchivedApi.GetIssueArchivedList(hubId, projectId);
        }    
        
        [Test, Order(3)]
        public void Test_GetIssueArchived()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int issueArchivedId = __GetArchivedIssueRandom(hubId, projectId, "AutoNewIssueToArchive");
            
            IssueArchivedApi issueArchivedApi = new IssueArchivedApi();
            Issue issue =  issueArchivedApi.GetIssueArchived(hubId, projectId, issueArchivedId);
        }
        
        [Test, Order(4)]
        public void Test_RestoreArchivedIssue()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int issueArchivedId = __GetArchivedIssueRandom(hubId, projectId, "AutoNewIssueToArchive");
            int statusId = __GetProjectStatusRandom(hubId, projectId);
            
            IssueArchivedApi issueArchivedApi = new IssueArchivedApi();
            issueArchivedApi.RestoreArchivedIssue(hubId, projectId, issueArchivedId, statusId);
        }

        [Test, Order(5)]
        public void Test_RearchiveAndDeleteArchivedIssue()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int issueId = __GetIssueRandom(hubId, projectId, "AutoNewIssueToArchive");
            
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