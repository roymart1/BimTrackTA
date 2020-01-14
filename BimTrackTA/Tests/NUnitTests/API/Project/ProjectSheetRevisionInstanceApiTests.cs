using System.Collections.Generic;
using BimTrackTA.Common.WebDriver;
using BimTrackTA.API;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class ProjectSheetRevisionInstanceApiTests : GeneralTestBase
    {
        [Test, Order(1)]
        public void Test_CreateProjectSheetRevisionInstance()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            
            // We need to create the sheet to create the revision to create its instance
            string sheetName = "AutoSheetForInstanceTest.pdf";
            string revisionName = "AutoSheetRevisionForInstanceTest.pdf";
            string filePath = "../../../Tests/NUnitTests/API/TestResources/Sheet.pdf";   
            
            ProjectSheetApi projectSheetApi = new ProjectSheetApi();
            int sheetId = projectSheetApi.CreateProjectSheet(hubId, projectId, sheetName, filePath);
            
            // Now that the sheet is created, we can create the revision
            ProjectSheetRevisionApi projectSheetRevisionApi = new ProjectSheetRevisionApi();
            int revisionId = projectSheetRevisionApi.CreateProjectSheetRevision(hubId, projectId, sheetId, revisionName, filePath);
            
            // We can finally create the instance for the newly created revision
            Xyz xyz = new Xyz{ X = 0, Y = 0, Z = 0};
            Instance instance = new Instance
            {
                ViewName = "AutoRevisionInstance",
                Position = xyz,
                Rotation = xyz,
                CropBoxCenter = xyz,
                CropBoxRotation = xyz,
                CropBoxSize = xyz
            };

            ProjectSheetRevisionInstanceApi projectSheetRevisionInstanceApi = new ProjectSheetRevisionInstanceApi();
            projectSheetRevisionInstanceApi
                .CreateProjectSheetRevisionInstance(hubId, projectId, sheetId, revisionId, instance);
        }
        
        [Test, Order(2)]
        public void Test_GetProjectSheetRevisionInstances()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int sheetId = __GetProjectSheetRandom(hubId, projectId, "AutoSheetForInstanceTest.pdf");
            int revisionId = __GetProjectSheetRevisionRandom(hubId, projectId, sheetId, "AutoSheetRevisionForInstanceTest.pdf");
            
            ProjectSheetRevisionInstanceApi projectSheetRevisionInstanceApi = new ProjectSheetRevisionInstanceApi();
            projectSheetRevisionInstanceApi.GetProjectSheetRevisionInstanceList(hubId, projectId, sheetId, revisionId);
        }
        
        [Test, Order(3)]
        public void Test_GetProjectSheetRevisionInstance()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int sheetId = __GetProjectSheetRandom(hubId, projectId, "AutoSheetForInstanceTest.pdf");
            int revisionId = __GetProjectSheetRevisionRandom(hubId, projectId, sheetId, "AutoSheetRevisionForInstanceTest.pdf");
            int instanceId = __GetProjectSheetRevisionInstanceRandom(hubId, projectId, sheetId, revisionId);

            ProjectSheetRevisionInstanceApi projectSheetRevisionInstanceApi = new ProjectSheetRevisionInstanceApi();
            projectSheetRevisionInstanceApi.GetProjectSheetRevisionInstance(hubId, projectId, sheetId, revisionId, instanceId);
        }

        [Test, Order(4)]
        public void Test_UpdateProjectSheetRevisionInstance()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int sheetId = __GetProjectSheetRandom(hubId, projectId, "AutoSheetForInstanceTest.pdf");
            int revisionId = __GetProjectSheetRevisionRandom(hubId, projectId, sheetId, "AutoSheetRevisionForInstanceTest.pdf");
            int instanceId = __GetProjectSheetRevisionInstanceRandom(hubId, projectId, sheetId, revisionId);

            Instance instance = new Instance {ViewName = "UpdatedRevisionInstance"};

            ProjectSheetRevisionInstanceApi projectSheetRevisionInstanceApi = new ProjectSheetRevisionInstanceApi();
            projectSheetRevisionInstanceApi.UpdateProjectSheetRevisionInstance(hubId, projectId, sheetId, revisionId,
                instanceId, instance);
        }
        
        [Test, Order(5)]
        public void Test_DeleteProjectSheetRevisionInstance()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int sheetId = __GetProjectSheetRandom(hubId, projectId, "AutoSheetForInstanceTest.pdf");
            int revisionId = __GetProjectSheetRevisionRandom(hubId, projectId, sheetId, "AutoSheetRevisionForInstanceTest.pdf");
            int instanceId = __GetProjectSheetRevisionInstanceRandom(hubId, projectId, sheetId, revisionId);
            
            ProjectSheetRevisionInstanceApi projectSheetRevisionInstanceApi = new ProjectSheetRevisionInstanceApi();
            projectSheetRevisionInstanceApi
                .DeleteProjectSheetRevisionInstance(hubId, projectId, sheetId, revisionId, instanceId);
            
            // Delete the sheet that we created
            ProjectSheetApi projectSheetApi = new ProjectSheetApi();
            projectSheetApi.DeleteProjectSheet(hubId, projectId, sheetId);
            // I don't need to delete the revision, because deleting the sheet implicitly deletes the revision.
        }
    }
}