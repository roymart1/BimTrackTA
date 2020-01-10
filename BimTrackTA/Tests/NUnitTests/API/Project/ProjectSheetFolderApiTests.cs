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
        public void Test_CreateProjectSheetFolder()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            
            // Before creating a folder, we need to create a sheet
            string sheetName = "AutoSheetForFolderTest.pdf";
            string sheetPath = "../../../Tests/NUnitTests/API/TestResources/Sheet.pdf";
            ProjectSheetApi projectSheetApi = new ProjectSheetApi();
            projectSheetApi.CreateProjectSheet(hubId, projectId, sheetName, sheetPath);
            
            // Now we can create a folder and give it to it
            Folder folder = new Folder();
            folder.Name = "AutoSheetFolderTest";
            
            ProjectSheetFolderApi projectSheetFolderApi = new ProjectSheetFolderApi();
            projectSheetFolderApi.CreateProjectSheetFolder(hubId, projectId, folder);
        }
        
        [Test, Order(2)]
        public void Test_GetProjectSheetFolders()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            
            ProjectSheetFolderApi projectSheetFolderApi = new ProjectSheetFolderApi();
            List<Folder> folders = projectSheetFolderApi.GetProjectSheetFolderList(hubId, projectId);
        }
        
        [Test, Order(3)]
        public void Test_UpdateProjectSheetFolder()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int folderId = __GetProjectSheetFolderRandom(hubId, projectId, "AutoSheetFolderTest");

            Folder folder = new Folder();
            folder.Name = "UpdatedSheetFolderTest";

            ProjectSheetFolderApi projectSheetFolderApi = new ProjectSheetFolderApi();
            projectSheetFolderApi.UpdateProjectSheetFolder(hubId, projectId, folderId, folder);
        }

        [Test, Order(4)]
        public void Test_DeleteProjectSheetFolder()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int folderId = __GetProjectSheetFolderRandom(hubId, projectId, "UpdatedSheetFolderTest");
            
            ProjectSheetFolderApi projectSheetFolderApi = new ProjectSheetFolderApi();
            projectSheetFolderApi.DeleteProjectSheetFolder(hubId, projectId, folderId);
            
            // Delete the sheet we created for the folder to clean up the test
            int sheetId = __GetProjectSheetRandom(hubId, projectId, "AutoSheetFolderTest.pdf");
            ProjectSheetApi projectSheetApi = new ProjectSheetApi();
            projectSheetApi.DeleteProjectSheet(hubId, projectId, sheetId);
        }
    }
}