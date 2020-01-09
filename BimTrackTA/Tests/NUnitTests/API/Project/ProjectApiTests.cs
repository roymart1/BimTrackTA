using System.Collections.Generic;
using BimTrackTA.Common.WebDriver;
using BimTrackTA.API;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class ProjectApiTests : GeneralTestBase
    {
        
        [Test]
        public void Test_GetHubProjectList()
        {
            int hubId = __GetHubRandom();
            
            ProjectApi projectApi = new ProjectApi();
            List<Project> listProject =  projectApi.GetHubProjectList(hubId);
        }    
        
        [Test]
        public void Test_CreateHubProject()
        {
            int hubId = __GetHubRandom();
            
            ProjectApi projectApi = new ProjectApi();
            projectApi.CreateHubProject(hubId, 98, "AutoNewPrjOther");
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