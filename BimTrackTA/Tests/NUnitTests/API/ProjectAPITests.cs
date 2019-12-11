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
            ProjectAPI projectApi = new ProjectAPI();
            List<Project> listProject =  projectApi.GetHubProjectList(hubId);
        }    
        
        [Test]
        public void Test_CreateHubProject()
        {
            int hubId = __GetHubRandom();
            
            // Go on with the retrieval of the project list / use templateId 0 for success
            ProjectAPI projectApi = new ProjectAPI();
            projectApi.CreateHubProject(hubId, 99, "AutoNewPrj");
        }


        

        

        
        
        
    }
}