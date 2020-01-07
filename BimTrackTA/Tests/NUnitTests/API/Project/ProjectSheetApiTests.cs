using System.Collections.Generic;
using BimTrackTA.Common.WebDriver;
using BimTrackTA.API;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class ProjectSheetApiTests : GeneralTestBase
    {
        [Test]
        public void Test_GetProjectSheets()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            
            ProjectSheetApi projectSheetApi = new ProjectSheetApi();
            List<Project.Sheet> sheets = projectSheetApi.GetProjectSheetList(hubId, projectId);
        }

        [Test]
        public void Test_CreateProjectSheet()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            string name = "AutoSheetTest";
            ProjectSheetApi projectSheetApi = new ProjectSheetApi();
            projectSheetApi.CreateProjectSheet(hubId, projectId, name);
        }

        [Test]
        public void Test_GetProjectModel()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int sheetId = __GetProjectSheetRandom(hubId, projectId);
            
            ProjectSheetApi projectSheetApi = new ProjectSheetApi();
            Project.Sheet sheet = projectSheetApi.GetProjectSheet(hubId, projectId, sheetId);
        }
        
        [Test]
        public void Test_DeleteProjectSheet()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int sheetId = __GetProjectSheetRandom(hubId, projectId);
            
            ProjectSheetApi projectSheetApi = new ProjectSheetApi();
            projectSheetApi.DeleteProjectSheet(hubId, projectId, sheetId);
        }

    }
}