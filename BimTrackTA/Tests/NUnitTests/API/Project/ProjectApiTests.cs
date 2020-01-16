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
        public void Test1_CreateHubProject()
        {
            int hubId = __GetHubRandom();

            Project project = new Project {Name = "AutoNewPrjTest"};

            ProjectApi projectApi = new ProjectApi();
            projectApi.CreateHubProject(hubId, project);
        }
        
        [Test, Order(2)]
        public void Test2_GetHubProjectList()
        {
            int hubId = __GetHubRandom();
            
            ProjectApi projectApi = new ProjectApi();
            projectApi.GetHubProjectList(hubId);
        } 
        
        [Test, Order(3)]
        public void Test3_GetHubProjectDetails()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoNewPrjTest", true);
            
            ProjectApi projectApi = new ProjectApi();
            projectApi.GetHubProjectDetails(hubId, projectId);
        }

        [Test, Order(4)]
        public void Test4_UpdateProjectName()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoNewPrjTest", true);

            Project project = new Project {Name = "AutoUpdatedNewPrjTest"};

            ProjectApi projectApi = new ProjectApi();
            projectApi.UpdateHubProject(hubId, projectId, project);
        }
    }
}