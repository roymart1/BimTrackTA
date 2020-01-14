using System.Collections.Generic;
using BimTrackTA.Common.WebDriver;
using BimTrackTA.API;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class IssueCommentApiTests : GeneralTestBase
    {
        [Test, Order(1)]
        public void Test_CreateIssueComment()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            
            // We need to create an issue for us to be able to create its attachment
            Issue issue = new Issue
            {
                Title = "IssueCommentTest",
                TypeId = __GetProjectTypeRandom(hubId, projectId),
                PriorityId = __GetProjectPriorityRandom(hubId, projectId),
                StatusId = __GetProjectStatusRandom(hubId, projectId)
            };
            IssueApi issueApi = new IssueApi();
            int issueId = issueApi.CreateIssue(hubId, projectId, issue);
            
            // Now that the issue is created, we can create a comment for it
            BimComment bimComment = new BimComment {Comment = "AutoIssueComment"};

            IssueCommentApi issueComment = new IssueCommentApi();
            issueComment.CreateIssueComment(hubId, projectId, issueId, bimComment);
        }
        
        [Test, Order(2)]
        public void Test_GetIssueCommentList()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int issueId = __GetIssueRandom(hubId, projectId, "IssueCommentTest");
            
            IssueCommentApi issueComment = new IssueCommentApi();
            issueComment.GetIssueCommentList(hubId, projectId, issueId);
        }    

        [Test, Order(3)]
        public void Test_DeleteIssueComment()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int issueId = __GetIssueRandom(hubId, projectId, "IssueCommentTest");
            int commentId = __GetIssueCommentRandom(hubId, projectId, issueId, "AutoIssueComment");

            IssueCommentApi issueComment = new IssueCommentApi();
            issueComment.DeleteIssueComment(hubId, projectId, issueId, commentId);
            
            // We now need to delete the temporary issue to clean up the test
            IssueApi issueApi = new IssueApi();
            issueApi.ArchiveIssue(hubId, projectId, issueId);
            IssueArchivedApi issueArchivedApi = new IssueArchivedApi();
            issueArchivedApi.DeleteArchivedIssue(hubId, projectId, issueId);        }
    }
}