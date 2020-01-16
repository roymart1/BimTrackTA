using System.Collections.Generic;
using BimTrackTA.Common.WebDriver;
using BimTrackTA.API;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class ProjectSheetRevisionApiTests : GeneralTestBase
    {
        [Test, Order(1)]
        public void Test1_CreateProjectSheetRevision()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            
            // We need to create the sheet before creating its revision
            string sheetName = "AutoSheetForRevisionTest.pdf";
            string sheetPath = "../../../Tests/NUnitTests/API/TestResources/Sheet.pdf";
            ProjectSheetApi projectSheetApi = new ProjectSheetApi();
            int sheetId = projectSheetApi.CreateProjectSheet(hubId, projectId, sheetName, sheetPath);  
            
            // Now we can bind it to our revision using its ID
            string revisionName = "AutoRevisionTest.pdf";
            string revisionPath = "../../../Tests/NUnitTests/API/TestResources/Sheet.pdf";
            
            ProjectSheetRevisionApi projectSheetRevisionApi = new ProjectSheetRevisionApi();
            projectSheetRevisionApi.CreateProjectSheetRevision(hubId, projectId, sheetId, revisionName, revisionPath);
        }
        
        [Test, Order(2)]
        public void Test2_GetProjectSheetRevisions()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int sheetId = __GetProjectSheetRandom(hubId, projectId, "AutoSheetForRevisionTest", true);
            
            ProjectSheetRevisionApi projectSheetRevisionApi = new ProjectSheetRevisionApi();
            projectSheetRevisionApi.GetProjectSheetRevisionList(hubId, projectId, sheetId);
        }

        [Test, Order(3)]
        public void Test3_GetProjectSheetRevision()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int sheetId = __GetProjectSheetRandom(hubId, projectId, "AutoSheetForRevisionTest", true);
            int revisionId = __GetProjectSheetRevisionRandom(hubId, projectId, sheetId, "AutoRevisionTest.pdf", true);

            ProjectSheetRevisionApi projectSheetRevisionApi = new ProjectSheetRevisionApi();
            projectSheetRevisionApi.GetProjectSheetRevision(hubId, projectId, sheetId, revisionId);
        }
        
        [Test, Order(4)]
        public void Test4_DeleteProjectSheetRevision()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int sheetId = __GetProjectSheetRandom(hubId, projectId, "AutoSheetForRevisionTest", true);
            int revisionId = __GetProjectSheetRevisionRandom(hubId, projectId, sheetId, "AutoRevisionTest.pdf", true);
            
            ProjectSheetRevisionApi projectSheetRevisionApi = new ProjectSheetRevisionApi();
            projectSheetRevisionApi.DeleteProjectSheetRevision(hubId, projectId, sheetId, revisionId);
            
            // Now we can delete the sheet that we created for the revision to clean up the test
            ProjectSheetApi projectSheetApi = new ProjectSheetApi();
            projectSheetApi.DeleteProjectSheet(hubId, projectId, sheetId);
        }
    }
}