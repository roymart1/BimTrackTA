using System.Collections.Generic;
using BimTrackTA.Common.WebDriver;
using BimTrackTA.API;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class ProjectModelApiTests : GeneralTestBase
    {
        [Test, Order(1)]
        public void Test1_CreateProjectModel()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            
            string modelName = "AutoModelTest.ifc";
            string pathToModel = "../../../Tests/NUnitTests/API/TestResources/Model.ifc";
            
            ProjectModelApi projectModelApi = new ProjectModelApi();
            projectModelApi.CreateProjectModel(hubId, projectId, modelName, pathToModel);
        }
        
        [Test, Order(2)]
        public void Test2_GetProjectModels()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            
            ProjectModelApi projectModelApi = new ProjectModelApi();
            projectModelApi.GetProjectModelList(hubId, projectId);
        }
        
        [Test, Order(3)]
        public void Test3_GetProjectModel()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int modelId = __GetProjectModelRandom(hubId, projectId, "AutoModelTest.ifc", true);
            
            ProjectModelApi projectModelApi = new ProjectModelApi();
            projectModelApi.GetProjectModel(hubId, projectId, modelId);
        }

        [Test, Order(4)]
        public void Test4_UpdateProjectModel()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int modelId = __GetProjectModelRandom(hubId, projectId, "AutoModelTest.ifc", true);
        
            // We need to create a folder to update the model folder id
            Folder folder = new Folder { Name = "ModelFolderTest"};
            ProjectModelFolderApi projectModelFolderApi = new ProjectModelFolderApi();
            int folderId = projectModelFolderApi.CreateProjectModelFolder(hubId, projectId, folder);

            ProjectModelApi projectModelApi = new ProjectModelApi();
            projectModelApi.UpdateProjectModel(hubId, projectId, modelId, folderId);
        }

        [Test, Order(5)]
        public void Test5_DeleteProjectModel()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int modelId = __GetProjectModelRandom(hubId, projectId, "AutoModelTest.ifc", true);
            
            ProjectModelApi projectModelApi = new ProjectModelApi();
            projectModelApi.DeleteProjectModel(hubId, projectId, modelId);
            
            // Delete the created folder in the update method to clean-up the test
            int folderId = __GetProjectModelFolderRandom(hubId, projectId, "ModelFolderTest", true);
            ProjectModelFolderApi projectModelFolderApi = new ProjectModelFolderApi();
            projectModelFolderApi.DeleteProjectModelFolder(hubId, projectId, folderId);
        }
    }
}