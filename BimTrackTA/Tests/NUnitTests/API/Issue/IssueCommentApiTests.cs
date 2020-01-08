using System.Collections.Generic;
using BimTrackTA.Common.WebDriver;
using BimTrackTA.API;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class IssueCommentApiTests : GeneralTestBase
    {
        [Test]
        public void Test_GetIssueCommentList()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int issueId = __GetIssueRandom(hubId, projectId);
            
            IssueCommentApi issueComment = new IssueCommentApi();
            List<Comment> listComment =  issueComment.GetIssueCommentList(hubId, projectId, issueId);
        }    
        
        [Test]
        public void Test_CreateIssueComment()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int issueId = __GetIssueRandom(hubId, projectId);
            
            IssueCommentApi issueComment = new IssueCommentApi();
            issueComment.CreateIssueComment(hubId, projectId, issueId, "AutoIssueComment");
        }

        [Test]
        public void Test_DeleteIssueComment()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int issueId = __GetIssueRandom(hubId, projectId);
            int commentId = __GetIssueCommentRandom(hubId, projectId, issueId);

            IssueCommentApi issueComment = new IssueCommentApi();
            issueComment.DeleteIssueComment(hubId, projectId, issueId, commentId);
        }
    }
}