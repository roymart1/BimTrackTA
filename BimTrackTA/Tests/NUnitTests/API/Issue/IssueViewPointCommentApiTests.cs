using System.Collections.Generic;
using BimTrackTA.Common.WebDriver;
using BimTrackTA.API;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class IssueViewPointCommentApiTests : GeneralTestBase
    {
        [Test, Order(1)]
        public void Test_CreateIssueViewPointComment()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            
            // To be able to create a comment for the viewpoint, we first need to create the issue and the viewpoint
            Issue issue = new Issue
            {
                Title = "IssueViewPointCommentTest",
                TypeId = __GetProjectTypeRandom(hubId, projectId),
                PriorityId = __GetProjectPriorityRandom(hubId, projectId),
                StatusId = __GetProjectStatusRandom(hubId, projectId)
            };
            IssueApi issueApi = new IssueApi();
            issueApi.CreateIssue(hubId, projectId, issue);
            
            // Now that we have created the issue, we can give it a viewpoint
            int issueId = __GetIssueRandom(hubId, projectId, "IssueViewPointCommentTest");
            ViewPoint viewPoint = new ViewPoint {ViewType = "TwoD", Source = "Web", ViewName = "ViewPointCommentTest"};
            string path = "../../../Tests/NUnitTests/API/TestResources/Colors.jpg";
            string fileName = "Colors.jpg";
            
            IssueViewPointApi issueViewPoint = new IssueViewPointApi();
            issueViewPoint.CreateIssueViewPoint(hubId, projectId, issueId, viewPoint, fileName, path);
            
            // Finally, we can give it a comment.
            int viewPointId = __GetIssueViewPointRandom(hubId, projectId, issueId);

            BimComment comment = new BimComment {Comment = "AutoIssueComment"};

            IssueViewPointCommentApi issueViewPointComment = new IssueViewPointCommentApi();
            issueViewPointComment
                .CreateIssueViewPointComment(hubId, projectId, issueId, viewPointId, comment);
        }
        
        [Test, Order(2)]
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

        [Test, Order(3)]
        public void Test_DeleteIssueViewPointComment()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int issueId = __GetIssueRandom(hubId, projectId);
            int viewPointId = __GetIssueViewPointRandom(hubId, projectId, issueId);
            int viewPointCommentId = __GetIssueViewPointCommentRandom(hubId, projectId, issueId, viewPointId);
            
            IssueViewPointCommentApi issueViewPointComment = new IssueViewPointCommentApi();
            issueViewPointComment.DeleteIssueViewPointComment(hubId, projectId, issueId, viewPointId, viewPointCommentId);
            
            // We now need to delete the temporary issue to clean up the test
            IssueApi issueApi = new IssueApi();
            issueApi.ArchiveIssue(hubId, projectId, issueId);
            IssueArchivedApi issueArchivedApi = new IssueArchivedApi();
            issueArchivedApi.DeleteArchivedIssue(hubId, projectId, issueId);
        }
    }
}