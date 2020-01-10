using System.Collections.Generic;
using BimTrackTA.Common.WebDriver;
using BimTrackTA.API;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class ProjectModelFolderApiTests : GeneralTestBase
    {
        [Test, Order(1)]
        public void Test_CreateProjectModelFolder()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            
            // We need to create the model first
            string modelName = "ModelForFolderTest.ifc";
            string pathToModel = "../../../Tests/NUnitTests/API/TestResources/Model.ifc";
            
            ProjectModelApi projectModelApi = new ProjectModelApi();
            projectModelApi.CreateProjectModel(hubId, projectId, modelName, pathToModel);
            
            // Now, we can give it a folder
            Folder folder = new Folder();
            folder.Name = "AutoModelFolderTest";
            
            ProjectModelFolderApi projectModelFolderApi = new ProjectModelFolderApi();
            projectModelFolderApi.CreateProjectModelFolder(hubId, projectId, folder);
        }
        
        [Test, Order(2)]
        public void Test_GetProjectModelFolders()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            
            ProjectModelFolderApi projectModelFolderApi = new ProjectModelFolderApi();
            List<Folder> folders = projectModelFolderApi.GetProjectModelFolderList(hubId, projectId);
        }

        [Test, Order(3)]
        public void Test_UpdateProjectModelFolder()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int folderId = __GetProjectModelFolderRandom(hubId, projectId, "AutoModelFolderTest");

            string key = "Name";
            string newName = "UpdatedModelFolderTest";

            ProjectModelFolderApi projectModelFolderApi = new ProjectModelFolderApi();
            projectModelFolderApi.UpdateProjectModelFolder(hubId, projectId, folderId, key, newName);
        }
        
        [Test, Order(4)]
        public void Test_DeleteProjectModelFolder()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int folderId = __GetProjectModelFolderRandom(hubId, projectId, "AutoModelFolderTest");
            
            ProjectModelFolderApi projectModelFolderApi = new ProjectModelFolderApi();
            projectModelFolderApi.DeleteProjectModelFolder(hubId, projectId, folderId);
            
            // Delete the model that we created on the first test to clean up the tests
            int modelId = __GetProjectModelRandom(hubId, projectId, "ModelForFolderTest.ifc");
            ProjectModelApi projectModelApi = new ProjectModelApi();
            projectModelApi.DeleteProjectModel(hubId, projectId, modelId);
        }
    }
}