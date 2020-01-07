using System.Collections.Generic;
using BimTrackTA.Common.WebDriver;
using BimTrackTA.API;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class IssueViewPointApiTests : GeneralTestBase
    {
        [Test]
        public void Test_GetIssueViewPointList()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int issueId = __GetIssueRandom(hubId, projectId);
            
            IssueViewPointApi issueViewPoint = new IssueViewPointApi();
            List<Issue.ViewPoint> listViewPoint =  issueViewPoint.GetIssueViewPointList(hubId, projectId, issueId);
        }    
        
        [Test]
        public void Test_CreateIssueViewPoint()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int issueId = __GetIssueRandom(hubId, projectId);
            
            IssueViewPointApi issueViewPoint = new IssueViewPointApi();
            issueViewPoint.CreateIssueViewPoint(hubId, projectId, issueId, "AutoIssueViewPoint");
        }

        [Test]
        public void Test_GetIssueViewPoint()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int issueId = __GetIssueRandom(hubId, projectId);
            int issueViewPointId = __GetIssueViewPointRandom(hubId, projectId, issueId);
            
            IssueViewPointApi issueViewPoint = new IssueViewPointApi();
            Issue.ViewPoint viewPoint =  issueViewPoint.GetIssueViewPoint(hubId, projectId, issueId, issueViewPointId);
        }

        [Test]
        public void Test_UpdateIssueViewPoint()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int issueId = __GetIssueRandom(hubId, projectId);
            int issueViewPointId = __GetIssueViewPointRandom(hubId, projectId, issueId);

            string key = "ViewName";
            string value = "UpdatedIssueViewPoint";
         
            IssueViewPointApi issueViewPoint = new IssueViewPointApi();
            issueViewPoint.UpdateIssueViewPoint(hubId, projectId, issueId, issueViewPointId, key, value);
        }
        
        [Test]
        public void Test_DeleteIssueViewPoint()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int issueId = __GetIssueRandom(hubId, projectId);
            int issueViewPointId = __GetIssueViewPointRandom(hubId, projectId, issueId);

            IssueViewPointApi issueViewPoint = new IssueViewPointApi();
            issueViewPoint.DeleteIssueViewPoint(hubId, projectId, issueId, issueViewPointId);
        }
    }
}