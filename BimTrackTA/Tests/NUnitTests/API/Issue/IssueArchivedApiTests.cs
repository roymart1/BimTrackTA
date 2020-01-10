using System.Collections.Generic;
using BimTrackTA.Common.WebDriver;
using BimTrackTA.API;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class IssueArchivedApiTests : GeneralTestBase
    {
        // Create an issue for us to be able to archive it
        [Test]
        public void CreateIssue()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            
            Issue issue = new Issue();
            issue.Title = "AutoNewIssueToArchive";
            
            IssueApi issueApi = new IssueApi();
            issueApi.CreateIssue(hubId, projectId, issue);
        }
        
        // Archive it
        [Test]
        public void ArchiveIssue()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int issueId = __GetIssueRandom(hubId, projectId, "AutoNewIssueToArchive");
            
            IssueApi issueApi = new IssueApi();
            issueApi.ArchiveIssue(hubId, projectId, issueId);
        }
        
        [Test]
        public void Test_GetIssueArchivedList()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            
            IssueArchivedApi issueArchivedApi = new IssueArchivedApi();
            List<Issue> listIssue =  issueArchivedApi.GetIssueArchivedList(hubId, projectId);
        }    
        
        [Test]
        public void Test_GetIssueArchived()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int issueArchivedId = __GetArchivedIssueRandom(hubId, projectId, "AutoNewIssueToArchive");
            
            IssueArchivedApi issueArchivedApi = new IssueArchivedApi();
            Issue issue =  issueArchivedApi.GetIssueArchived(hubId, projectId, issueArchivedId);
        }
        
        [Test]
        public void Test_RestoreArchivedIssue()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int issueArchivedId = __GetArchivedIssueRandom(hubId, projectId, "AutoNewIssueToArchive");
            
            IssueArchivedApi issueArchivedApi = new IssueArchivedApi();
            issueArchivedApi.RestoreArchivedIssue(hubId, projectId, issueArchivedId);
        }

        [Test]
        public void RearchiveRestoredIssue()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int issueId = __GetIssueRandom(hubId, projectId, "AutoNewIssueToArchive");
            
            IssueApi issueApi = new IssueApi();
            issueApi.ArchiveIssue(hubId, projectId, issueId);
        }

        [Test]
        public void Test_DeleteArchivedIssue()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int issueArchivedId = __GetArchivedIssueRandom(hubId, projectId);
            
            IssueArchivedApi issueArchivedApi = new IssueArchivedApi();
            issueArchivedApi.DeleteArchivedIssue(hubId, projectId, issueArchivedId);
        }
    }
}