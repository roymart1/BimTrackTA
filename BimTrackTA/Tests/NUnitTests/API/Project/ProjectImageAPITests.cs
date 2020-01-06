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
    public class ProjectImageAPITests : GeneralTestBase
    {
        
        [Test]
        public void Test_UpdateImage()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            string key = "Name";
            string newName = "AutoImageTest";
            
            // Go on with the retrieval of the project list 
            ProjectImageApi projectImageApi = new ProjectImageApi();
            projectImageApi.UpdateProjectImage(hubId, projectId, key, newName);
        }
    }
}