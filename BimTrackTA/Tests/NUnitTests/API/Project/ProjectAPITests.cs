using System;
using System.Collections.Generic;
using BimTrackTA.Common.WebDriver;
using BimTrackTA.API;
using NLog;
using NLog.Targets;
using NUnit.Framework;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class ProjectAPITests : GeneralTestBase
    {
        
        [Test]
        public void Test_GetHubProjectList()
        {
            int hubId = __GetHubRandom();
            
            // Go on with the retrieval of the project list 
            ProjectApi projectApi = new ProjectApi();
            List<Project> listProject =  projectApi.GetHubProjectList(hubId);
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