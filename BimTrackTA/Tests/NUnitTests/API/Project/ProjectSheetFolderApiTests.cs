using System.Collections.Generic;
using BimTrackTA.Common.WebDriver;
using BimTrackTA.API;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class ProjectSheetFolderApiTests : GeneralTestBase
    {
        [Test]
        public void Test_GetProjectSheetFolders()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            
            ProjectSheetFolderApi projectSheetFolderApi = new ProjectSheetFolderApi();
            List<Folder> folders = projectSheetFolderApi.GetProjectSheetFolderList(hubId, projectId);
        }

        [Test]
        public void Test_CreateProjectSheetFolder()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            
            Folder folder = new Folder();
            folder.Name = "AutoSheetFolderTest";
            
            ProjectSheetFolderApi projectSheetFolderApi = new ProjectSheetFolderApi();
            projectSheetFolderApi.CreateProjectSheetFolder(hubId, projectId, folder);
        }
        
        [Test]
        public void Test_UpdateProjectSheetFolder()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int folderId = __GetProjectSheetFolderRandom(hubId, projectId, "AutoSheetFolderTest");

            Folder folder = new Folder();
            folder.Name = "UpdatedSheetFolderTest";

            ProjectSheetFolderApi projectSheetFolderApi = new ProjectSheetFolderApi();
            projectSheetFolderApi.UpdateProjectSheetFolder(hubId, projectId, folderId, folder);
        }

        [Test]
        public void Test_DeleteProjectSheetFolder()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int folderId = __GetProjectSheetFolderRandom(hubId, projectId);
            
            ProjectSheetFolderApi projectSheetFolderApi = new ProjectSheetFolderApi();
            projectSheetFolderApi.DeleteProjectSheetFolder(hubId, projectId, folderId);
        }

    }
}