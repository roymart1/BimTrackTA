using System.Collections.Generic;
using BimTrackTA.Common.WebDriver;
using BimTrackTA.API;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class IssueViewPointApiTests : GeneralTestBase
    {
        [Test, Order(1)]
        public void Test_CreateIssueViewPoint()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            
            // We need to create an issue for us to be able to create its attachment
            Issue issue = new Issue
            {
                Title = "IssueViewPointTest",
                TypeId = __GetProjectTypeRandom(hubId, projectId),
                PriorityId = __GetProjectPriorityRandom(hubId, projectId),
                StatusId = __GetProjectStatusRandom(hubId, projectId)
            };
            IssueApi issueApi = new IssueApi();
            int issueId = issueApi.CreateIssue(hubId, projectId, issue);
            
            // Now that the issue is created, we can give it a viewpoint
            ViewPoint viewPoint = new ViewPoint {ViewType = "TwoD", Source = "Web", ViewName = "ViewPointTest"};
            string path = "../../../Tests/NUnitTests/API/TestResources/Colors.jpg";
            string fileName = "ViewPoint";

            IssueViewPointApi issueViewPoint = new IssueViewPointApi();
            issueViewPoint.CreateIssueViewPoint(hubId, projectId, issueId, viewPoint, fileName, path);
        }

        [Test, Order(2)]
        public void Test_GetIssueViewPointList()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int issueId = __GetIssueRandom(hubId, projectId, "IssueViewPointTest");
            
            IssueViewPointApi issueViewPoint = new IssueViewPointApi();
            issueViewPoint.GetIssueViewPointList(hubId, projectId, issueId);
        }
        
        [Test, Order(3)]
        public void Test_GetIssueViewPoint()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int issueId = __GetIssueRandom(hubId, projectId, "IssueViewPointTest");
            int issueViewPointId = __GetIssueViewPointRandom(hubId, projectId, issueId);
            
            IssueViewPointApi issueViewPoint = new IssueViewPointApi();
            issueViewPoint.GetIssueViewPoint(hubId, projectId, issueId, issueViewPointId);
        }

        [Test, Order(4)]
        public void Test_UpdateIssueViewPoint()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int issueId = __GetIssueRandom(hubId, projectId, "IssueViewPointTest");
            int issueViewPointId = __GetIssueViewPointRandom(hubId, projectId, issueId);

            ViewPoint viewPoint = new ViewPoint {ViewType = "ThreeD"};
            string path = "../../../Tests/NUnitTests/API/TestResources/Colors.jpg";
            string fileName = "ViewPointForComment.jpg";
            
            IssueViewPointApi issueViewPoint = new IssueViewPointApi();
            issueViewPoint.UpdateIssueViewPoint(hubId, projectId, issueId, issueViewPointId, 
                viewPoint, fileName, path);
        }
        
        [Test, Order(5)]
        public void Test_DeleteIssueViewPoint()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int issueId = __GetIssueRandom(hubId, projectId, "IssueViewPointTest");
            int issueViewPointId = __GetIssueViewPointRandom(hubId, projectId, issueId);

            IssueViewPointApi issueViewPoint = new IssueViewPointApi();
            issueViewPoint.DeleteIssueViewPoint(hubId, projectId, issueId, issueViewPointId);
            
            // We now need to delete the temporary issue to clean up the test
            IssueApi issueApi = new IssueApi();
            issueApi.ArchiveIssue(hubId, projectId, issueId);
            IssueArchivedApi issueArchivedApi = new IssueArchivedApi();
            issueArchivedApi.DeleteArchivedIssue(hubId, projectId, issueId);        }
    }
}