using System.Collections.Generic;
using BimTrackTA.Common.WebDriver;
using BimTrackTA.API;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class ProjectApiTests : GeneralTestBase
    {
        [Test, Order(1)]
        public void Test_CreateHubProject()
        {
            int hubId = __GetHubRandom();
            
            ProjectApi projectApi = new ProjectApi();
            projectApi.CreateHubProject(hubId, "AutoNewPrjTest");
        }
        
        [Test, Order(2)]
        public void Test_GetHubProjectList()
        {
            int hubId = __GetHubRandom();
            
            ProjectApi projectApi = new ProjectApi();
            List<Project> listProject =  projectApi.GetHubProjectList(hubId);
        } 
        
        [Test, Order(3)]
        public void Test_GetHubProjectDetails()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoNewPrjTest");
            
            ProjectApi projectApi = new ProjectApi();
            Project project = projectApi.GetHubProjectDetails(hubId, projectId);
        }

        [Test, Order(4)]
        public void Test_UpdateProjectName()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoNewPrjTest");
            string key = "Name";
            string value = "AutoUpdatedNewPrjTest";
            
            ProjectApi projectApi = new ProjectApi();
            projectApi.UpdateHubProject(hubId, projectId, key, value);
        }
    }
}