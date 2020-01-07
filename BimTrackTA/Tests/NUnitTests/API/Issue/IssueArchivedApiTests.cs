using System.Collections.Generic;
using BimTrackTA.Common.WebDriver;
using BimTrackTA.API;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class IssueArchivedApiTests : GeneralTestBase
    {
        [Test]
        public void Test_GetIssueArchivedList()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            
            // Go on with the retrieval of the project list 
            IssueArchivedApi issueArchivedApi = new IssueArchivedApi();
            List<Issue> listIssue =  issueArchivedApi.GetIssueArchivedList(hubId, projectId);
        }    
        
        [Test]
        public void Test_GetIssueArchived()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int issueArchivedId = __GetArchivedIssueRandom(hubId, projectId);
            
            // Go on with the retrieval of the project list 
            IssueArchivedApi issueArchivedApi = new IssueArchivedApi();
            Issue issue =  issueArchivedApi.GetIssueArchived(hubId, projectId, issueArchivedId);
        }
        
        [Test]
        public void Test_RestoreArchivedIssue()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int issueArchivedId = __GetArchivedIssueRandom(hubId, projectId);
            
            IssueArchivedApi issueArchivedApi = new IssueArchivedApi();
            issueArchivedApi.RestoreArchivedIssue(hubId, projectId, issueArchivedId);
        }

        [Test]
        // TODO: Make sure that this makes sense (is it executed in order, does it matter, etc.)
        // I need to re-archive the issue for me to be able to delete it
        public void Test_ArchiveIssue()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int issueId = __GetIssueRandom(hubId, projectId);
            
            IssueApi issueApi = new IssueApi();
            issueApi.ArchiveIssue(hubId, projectId, issueId);
        }
        
        [Test]
        public void Test_DeleteArchivedIssue()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int issueArchivedId = __GetArchivedIssueRandom(hubId, projectId);
            
            IssueArchivedApi issueArchivedApi = new IssueArchivedApi();
            issueArchivedApi.DeleteArchivedIssue(hubId, projectId, issueArchivedId);
        }
    }
}