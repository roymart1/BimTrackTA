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
        public void Test1_CreateProjectModelFolder()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            
            Folder folder = new Folder {Name = "AutoModelFolderTest"};

            ProjectModelFolderApi projectModelFolderApi = new ProjectModelFolderApi();
            projectModelFolderApi.CreateProjectModelFolder(hubId, projectId, folder);
        }
        
        [Test, Order(2)]
        public void Test2_GetProjectModelFolders()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            
            ProjectModelFolderApi projectModelFolderApi = new ProjectModelFolderApi();
            projectModelFolderApi.GetProjectModelFolderList(hubId, projectId);
        }

        [Test, Order(3)]
        public void Test3_UpdateProjectModelFolder()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int folderId = __GetProjectModelFolderRandom(hubId, projectId, "AutoModelFolderTest", true);

            Folder folder = new Folder {Name = "UpdatedModelFolderTest"};

            ProjectModelFolderApi projectModelFolderApi = new ProjectModelFolderApi();
            projectModelFolderApi.UpdateProjectModelFolder(hubId, projectId, folderId, folder);
        }
        
        [Test, Order(4)]
        public void Test4_DeleteProjectModelFolder()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int folderId = __GetProjectModelFolderRandom(hubId, projectId, "UpdatedModelFolderTest", true);
            
            ProjectModelFolderApi projectModelFolderApi = new ProjectModelFolderApi();
            projectModelFolderApi.DeleteProjectModelFolder(hubId, projectId, folderId);
        }
    }
}