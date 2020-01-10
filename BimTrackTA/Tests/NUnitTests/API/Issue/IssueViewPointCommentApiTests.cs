using System.Collections.Generic;
using BimTrackTA.Common.WebDriver;
using BimTrackTA.API;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class IssueViewPointCommentApiTests : GeneralTestBase
    {
        [Test]
        public void Test_GetIssueViewPointCommentList()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int issueId = __GetIssueRandom(hubId, projectId);
            int viewPointId = __GetIssueViewPointRandom(hubId, projectId, issueId);
            
            IssueViewPointCommentApi issueViewPointComment = new IssueViewPointCommentApi();
            List<BimComment> listComment =  issueViewPointComment
                .GetIssueViewPointCommentList(hubId, projectId, issueId, viewPointId);
        }    
        
        [Test]
        public void Test_CreateIssueViewPointComment()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int issueId = __GetIssueRandom(hubId, projectId);
            int viewPointId = __GetIssueViewPointRandom(hubId, projectId, issueId);

            BimComment comment = new BimComment();
            comment.Comment = "AutoIssueComment";
            IssueViewPointCommentApi issueViewPointComment = new IssueViewPointCommentApi();
            issueViewPointComment
                .CreateIssueViewPointComment(hubId, projectId, issueId, viewPointId, comment);
        }

        [Test]
        public void Test_DeleteIssueViewPointComment()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int issueId = __GetIssueRandom(hubId, projectId);
            int viewPointId = __GetIssueViewPointRandom(hubId, projectId, issueId);
            int viewPointCommentId = __GetIssueViewPointCommentRandom(hubId, projectId, issueId, viewPointId);
            
            IssueViewPointCommentApi issueViewPointComment = new IssueViewPointCommentApi();
            issueViewPointComment.DeleteIssueViewPointComment(hubId, projectId, issueId, viewPointId, viewPointCommentId);
        }
    }
}