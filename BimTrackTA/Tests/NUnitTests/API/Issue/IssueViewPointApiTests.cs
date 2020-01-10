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
            Issue issue = new Issue();
            issue.Title = "IssueViewPointTest";
            issue.TypeId = __GetProjectTypeRandom(hubId, projectId);
            issue.PriorityId = __GetProjectPriorityRandom(hubId, projectId);
            issue.StatusId = __GetProjectStatusRandom(hubId, projectId);
            IssueApi issueApi = new IssueApi();
            issueApi.CreateIssue(hubId, projectId, issue);
            
            // Now that the issue is created, we can give it a viewpoint
            int issueId = __GetIssueRandom(hubId, projectId, "IssueViewPointTest");
            
            ViewPoint viewPoint = new ViewPoint();
            viewPoint.ViewType = "TwoD";
            string path = "../../../Tests/NUnitTests/API/TestResources/ViewPoint.txt";
            string fileName = "ViewPoint";
            
            IssueViewPointApi issueViewPoint = new IssueViewPointApi();
            issueViewPoint.CreateIssueViewPoint(hubId, projectId, issueId, fileName, path, viewPoint);
        }

        [Test, Order(2)]
        public void Test_GetIssueViewPointList()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int issueId = __GetIssueRandom(hubId, projectId, "IssueViewPointTest");
            
            IssueViewPointApi issueViewPoint = new IssueViewPointApi();
            List<ViewPoint> listViewPoint =  issueViewPoint.GetIssueViewPointList(hubId, projectId, issueId);
        }
        
        [Test, Order(3)]
        public void Test_GetIssueViewPoint()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int issueId = __GetIssueRandom(hubId, projectId, "IssueViewPointTest");
            int issueViewPointId = __GetIssueViewPointRandom(hubId, projectId, issueId, "ViewPoint");
            
            IssueViewPointApi issueViewPoint = new IssueViewPointApi();
            ViewPoint viewPoint =  issueViewPoint.GetIssueViewPoint(hubId, projectId, issueId, issueViewPointId);
        }

        [Test, Order(4)]
        public void Test_UpdateIssueViewPoint()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int issueId = __GetIssueRandom(hubId, projectId, "IssueViewPointTest");
            int issueViewPointId = __GetIssueViewPointRandom(hubId, projectId, issueId, "ViewPoint");

            ViewPoint viewPoint = new ViewPoint();
            viewPoint.ViewType = "ThreeD";
         
            IssueViewPointApi issueViewPoint = new IssueViewPointApi();
            issueViewPoint.UpdateIssueViewPoint(hubId, projectId, issueId, issueViewPointId, viewPoint);
        }
        
        [Test, Order(5)]
        public void Test_DeleteIssueViewPoint()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int issueId = __GetIssueRandom(hubId, projectId, "IssueViewPointTest");
            int issueViewPointId = __GetIssueViewPointRandom(hubId, projectId, issueId, "ViewPoint");

            IssueViewPointApi issueViewPoint = new IssueViewPointApi();
            issueViewPoint.DeleteIssueViewPoint(hubId, projectId, issueId, issueViewPointId);
            
            // We now need to delete the temporary issue to clean up the test
            IssueApi issueApi = new IssueApi();
            issueApi.ArchiveIssue(hubId, projectId, issueId);
            IssueArchivedApi issueArchivedApi = new IssueArchivedApi();
            issueArchivedApi.DeleteArchivedIssue(hubId, projectId, issueId);        }
    }
}