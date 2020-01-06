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
    public class ProjectModelAPITests : GeneralTestBase
    {
        [Test]
        public void Test_GetProjectModels()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            
            // Go on with the retrieval of the project list 
            ProjectModelApi projectModelApi = new ProjectModelApi();
            List<Model> models = projectModelApi.GetProjectModelList(hubId, projectId);
        }

        [Test]
        public void Test_CreateProjectModel()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            string name = "AutoModelTest";
            ProjectModelApi projectModelApi = new ProjectModelApi();
            projectModelApi.CreateProjectModel(hubId, projectId, name);
        }

        [Test]
        public void Test_DeleteProjectModel()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int modelId = __GetProjectModelRandom(hubId, projectId);
            
            ProjectModelApi projectModelApi = new ProjectModelApi();
            projectModelApi.DeleteProjectModel(hubId, projectId, modelId);
        }

        [Test]
        public void Test_GetProjectModel()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int modelId = __GetProjectModelRandom(hubId, projectId);
            
            ProjectModelApi projectModelApi = new ProjectModelApi();
            Model model = projectModelApi.GetProjectModel(hubId, projectId, modelId);
        }

        [Test]
        public void Test_UpdateProjectModel()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int modelId = __GetProjectModelRandom(hubId, projectId);
            string key = "FolderId";
            int value = 1;
            
            ProjectModelApi projectModelApi = new ProjectModelApi();
            projectModelApi.UpdateProjectModel(hubId, projectId, modelId, key, value);
        }
    }
}