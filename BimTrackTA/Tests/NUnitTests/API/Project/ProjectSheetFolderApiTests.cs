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
        public void Test_UpdateProjectSheetFolder()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int folderId = __GetProjectSheetFolderRandom(hubId, projectId);

            string key = "Name";
            string newName = "UpdatedSheetFolderTest";

            ProjectSheetFolderApi projectSheetFolderApi = new ProjectSheetFolderApi();
            projectSheetFolderApi.UpdateProjectSheetFolder(hubId, projectId, folderId, key, newName);
        }
        
        [Test]
        public void Test_CreateProjectSheetFolder()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            string name = "AutoSheetFolderTest"; 
            ProjectSheetFolderApi projectSheetFolderApi = new ProjectSheetFolderApi();
            projectSheetFolderApi.CreateProjectSheetFolder(hubId, projectId, name);
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