using System.Collections.Generic;
using BimTrackTA.Common.WebDriver;
using BimTrackTA.API;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class ProjectModelApiTests : GeneralTestBase
    {
        [Test]
        public void Test_GetProjectModels()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            
            ProjectModelApi projectModelApi = new ProjectModelApi();
            List<Model> models = projectModelApi.GetProjectModelList(hubId, projectId);
        }

        [Test]
        public void Test_CreateProjectModel()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            
            string modelName = "AutoModelTest.ifc";
            string pathToModel = "../../../Tests/NUnitTests/API/TestResources/Model.ifc";
            
            ProjectModelApi projectModelApi = new ProjectModelApi();
            projectModelApi.CreateProjectModel(hubId, projectId, modelName, pathToModel);
        }
        
        [Test]
        public void Test_GetProjectModel()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int modelId = __GetProjectModelRandom(hubId, projectId);
            
            ProjectModelApi projectModelApi = new ProjectModelApi();
            Model model = projectModelApi.GetProjectModel(hubId, projectId, modelId);
        }

        [Test]
        public void Test_UpdateProjectModel()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int modelId = __GetProjectModelRandom(hubId, projectId);
            
            Project project = new Project();
            project.Name = "UpdatedAutoModelTest";
            
            ProjectModelApi projectModelApi = new ProjectModelApi();
            projectModelApi.UpdateProjectModel(hubId, projectId, modelId, project);
        }

        [Test]
        public void Test_DeleteProjectModel()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int modelId = __GetProjectModelRandom(hubId, projectId);
            
            ProjectModelApi projectModelApi = new ProjectModelApi();
            projectModelApi.DeleteProjectModel(hubId, projectId, modelId);
        }
    }
}