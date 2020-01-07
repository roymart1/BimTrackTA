using System.Collections.Generic;
using BimTrackTA.Common.WebDriver;
using BimTrackTA.API;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class IssueAPITests : GeneralTestBase
    {
        [Test]
        public void Test_GetIssueList()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            
            // Go on with the retrieval of the project list 
            IssueApi issueApi = new IssueApi();
            List<Issue> listProject =  issueApi.GetIssueList(hubId, projectId);
        }    
        
        [Test]
        public void Test_CreateHubProject()
        {
            int hubId = __GetHubRandom();
            
            // Go on with the retrieval of the project list / use templateId 0 for success
            ProjectApi projectApi = new ProjectApi();
            projectApi.CreateHubProject(hubId, 99, "AutoNewPrj");
        }

        [Test]
        public void Test_GetHubProjectDetails()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            
            ProjectApi projectApi = new ProjectApi();
            Project project = projectApi.GetHubProjectDetails(hubId, projectId);
        }

        [Test]
        public void Test_UpdateProjectName()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            string key = "Name";
            string value = "AutoUpdatedNewPrj";
            
            ProjectApi projectApi = new ProjectApi();
            projectApi.UpdateHubProject(hubId, projectId, key, value);
        }
    }
}