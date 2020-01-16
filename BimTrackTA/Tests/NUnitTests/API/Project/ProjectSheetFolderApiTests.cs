using System.Collections.Generic;
using BimTrackTA.Common.WebDriver;
using BimTrackTA.API;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class ProjectSheetFolderApiTests : GeneralTestBase
    {
        [Test, Order(1)]
        public void Test1_CreateProjectSheetFolder()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);

            Folder folder = new Folder {Name = "AutoSheetFolderTest"};

            ProjectSheetFolderApi projectSheetFolderApi = new ProjectSheetFolderApi();
            projectSheetFolderApi.CreateProjectSheetFolder(hubId, projectId, folder);
        }
        
        [Test, Order(2)]
        public void Test2_GetProjectSheetFolders()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            
            ProjectSheetFolderApi projectSheetFolderApi = new ProjectSheetFolderApi();
            projectSheetFolderApi.GetProjectSheetFolderList(hubId, projectId);
        }
        
        [Test, Order(3)]
        public void Test3_UpdateProjectSheetFolder()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int folderId = __GetProjectSheetFolderRandom(hubId, projectId, "AutoSheetFolderTest", true);

            Folder folder = new Folder {Name = "UpdatedSheetFolderTest"};

            ProjectSheetFolderApi projectSheetFolderApi = new ProjectSheetFolderApi();
            projectSheetFolderApi.UpdateProjectSheetFolder(hubId, projectId, folderId, folder);
        }

        [Test, Order(4)]
        public void Test4_DeleteProjectSheetFolder()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int folderId = __GetProjectSheetFolderRandom(hubId, projectId, "UpdatedSheetFolderTest", true);
            
            ProjectSheetFolderApi projectSheetFolderApi = new ProjectSheetFolderApi();
            projectSheetFolderApi.DeleteProjectSheetFolder(hubId, projectId, folderId);
        }
    }
}