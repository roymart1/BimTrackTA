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
            int projectId = __GetProjectRandom(hubId);
            int issueId = __GetIssueRandom(hubId, projectId);
            int viewPointId = __GetIssueViewPointRandom(hubId, projectId, issueId);
            
            IssueViewPointCommentApi issueViewPointComment = new IssueViewPointCommentApi();
            List<Issue.Comment> listComment =  issueViewPointComment
                .GetIssueViewPointCommentList(hubId, projectId, issueId, viewPointId);
        }    
        
        [Test]
        public void Test_CreateIssueViewPointComment()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int issueId = __GetIssueRandom(hubId, projectId);
            int viewPointId = __GetIssueViewPointRandom(hubId, projectId, issueId);

            IssueViewPointCommentApi issueViewPointComment = new IssueViewPointCommentApi();
            issueViewPointComment
                .CreateIssueViewPointComment(hubId, projectId, issueId, viewPointId, "AutoIssueComment");
        }

        [Test]
        public void Test_DeleteIssueViewPointComment()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int issueId = __GetIssueRandom(hubId, projectId);
            int viewPointId = __GetIssueViewPointRandom(hubId, projectId, issueId);
            int viewPointCommentId = __GetIssueViewPointCommentRandom(hubId, projectId, issueId, viewPointId);
            
            IssueViewPointCommentApi issueViewPointComment = new IssueViewPointCommentApi();
            issueViewPointComment.DeleteIssueViewPointComment(hubId, projectId, issueId, viewPointId, viewPointCommentId);
        }
    }
}