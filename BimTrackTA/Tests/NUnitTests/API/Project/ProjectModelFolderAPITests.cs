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
    public class ProjectModelFolderAPITests : GeneralTestBase
    {
        [Test]
        public void Test_GetProjectModelFolders()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            
            // Go on with the retrieval of the project list 
            ProjectModelFolderApi projectModelFolderApi = new ProjectModelFolderApi();
            List<Folder> folders = projectModelFolderApi.GetProjectModelFolderList(hubId, projectId);
        }

        [Test]
        public void Test_CreateProjectModelFolder()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            string name = "AutoModelFolderTest"; 
            ProjectModelFolderApi projectModelFolderApi = new ProjectModelFolderApi();
            projectModelFolderApi.CreateProjectModelFolder(hubId, projectId, name);
        }

        [Test]
        public void Test_DeleteProjectModelFolder()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int folderId = __GetProjectModelFolderRandom(hubId, projectId);
            
            ProjectModelFolderApi projectModelFolderApi = new ProjectModelFolderApi();
            projectModelFolderApi.DeleteProjectModelFolder(hubId, projectId, folderId);
        }
        
        [Test]
        public void Test_UpdateProjectModelFolder()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int folderId = __GetProjectModelFolderRandom(hubId, projectId);

            string key = "Name";
            string newName = "UpdatedModelFolderTest";

            ProjectModelFolderApi projectModelFolderApi = new ProjectModelFolderApi();
            projectModelFolderApi.UpdateProjectModelFolder(hubId, projectId, folderId, key, newName);
        }
    }
}