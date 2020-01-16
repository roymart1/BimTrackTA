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
            int projectId = projectApi.CreateHubProject(hubId, project);

            // Make an assertion
            Project remoteProject = projectApi.GetHubProjectDetails(hubId, projectId);
            Assert.True(remoteProject.Name == project.Name, "Invalid project name after creation.");
        }
        
        [Test, Order(2)]
        public void Test2_GetHubProjectList()
        {
            int hubId = __GetHubRandom();
            
            ProjectApi projectApi = new ProjectApi();
            List<Project> projects = projectApi.GetHubProjectList(hubId);
            
            // Make an assertion
            Assert.True(projects.Count > 0, "No project in the hub.");
        } 
        
        [Test, Order(3)]
        public void Test3_GetHubProjectDetails()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoNewPrjTest", true);
            
            ProjectApi projectApi = new ProjectApi();
            Project project = projectApi.GetHubProjectDetails(hubId, projectId);
            
            // Make an assertion
            Assert.True(project.Name == "AutoNewPrjTest", "The project name is invalid. Expected 'AutoNewPrjTest', got '" + project.Name + "'.");
        }

        [Test, Order(4)]
        public void Test4_UpdateProjectName()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoNewPrjTest", true);

            Project project = new Project {Name = "AutoUpdatedNewPrjTest"};

            ProjectApi projectApi = new ProjectApi();
            projectApi.UpdateHubProject(hubId, projectId, project);

            // Make an assertion
            Project updatedRemoteProject = projectApi.GetHubProjectDetails(hubId, projectId);
            Assert.True(updatedRemoteProject.Name == project.Name, "Invalid project name after update.");

        }
    }
}