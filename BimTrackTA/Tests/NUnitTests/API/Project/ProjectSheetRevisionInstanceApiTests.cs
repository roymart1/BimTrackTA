using System.Collections.Generic;
using BimTrackTA.Common.WebDriver;
using BimTrackTA.API;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class ProjectSheetRevisionInstanceApiTests : GeneralTestBase
    {
        // We need to create the instance and the revision first
        [Test]
        public void Setup_CreateSheetAndRevision()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");

            string sheetName = "AutoSheetForInstanceTest.pdf";
            string revisionName = "AutoSheetRevisionForInstanceTest.pdf";
            string filePath = "../../../Tests/NUnitTests/API/TestResources/Sheet.pdf";
            
            ProjectSheetApi projectSheetApi = new ProjectSheetApi();
            projectSheetApi.CreateProjectSheet(hubId, projectId, sheetName, filePath);

            int sheetId = __GetProjectSheetRandom(hubId, projectId, "AutoSheetForInstanceTest.pdf");
            ProjectSheetRevisionApi projectSheetRevisionApi = new ProjectSheetRevisionApi();
            projectSheetRevisionApi.CreateProjectSheetRevision(hubId, projectId, sheetId, revisionName, filePath);
        }
        
        [Test]
        public void Test_GetProjectSheetRevisionInstances()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int sheetId = __GetProjectSheetRandom(hubId, projectId, "AutoSheetForInstanceTest.pdf");
            int revisionId = __GetProjectSheetRevisionRandom(hubId, projectId, sheetId, "AutoSheetRevisionForInstanceTest.pdf");
            
            ProjectSheetRevisionInstanceApi projectSheetRevisionInstanceApi = new ProjectSheetRevisionInstanceApi();
            List<Instance> instances = projectSheetRevisionInstanceApi
                .GetProjectSheetRevisionInstanceList(hubId, projectId, sheetId, revisionId);
        }

        [Test]
        public void Test_CreateProjectSheetRevisionInstance()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int sheetId = __GetProjectSheetRandom(hubId, projectId, "AutoSheetForInstanceTest.pdf");
            int revisionId = __GetProjectSheetRevisionRandom(hubId, projectId, sheetId, "AutoSheetRevisionForInstanceTest.pdf");
            
            Xyz xyz = new Xyz{X=0,Y=0,Z=0};
            Instance instance = new Instance();
            instance.ViewName = "AutoRevisionInstance";
            instance.Position = xyz;
            instance.Rotation = xyz;
            instance.CropBoxCenter = xyz;
            instance.CropBoxRotation = xyz;
            instance.CropBoxSize = xyz;
            
            ProjectSheetRevisionInstanceApi projectSheetRevisionInstanceApi = new ProjectSheetRevisionInstanceApi();
            projectSheetRevisionInstanceApi
                .CreateProjectSheetRevisionInstance(hubId, projectId, sheetId, revisionId, instance);
        }
        
        [Test]
        public void Test_GetProjectSheetRevisionInstance()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int sheetId = __GetProjectSheetRandom(hubId, projectId, "AutoSheetForInstanceTest.pdf");
            int revisionId = __GetProjectSheetRevisionRandom(hubId, projectId, sheetId, "AutoSheetRevisionForInstanceTest.pdf");
            int instanceId = __GetProjectSheetRevisionInstanceRandom(hubId, projectId, sheetId, revisionId);

            ProjectSheetRevisionInstanceApi projectSheetRevisionInstanceApi = new ProjectSheetRevisionInstanceApi();
            Instance instance = projectSheetRevisionInstanceApi
                .GetProjectSheetRevisionInstance(hubId, projectId, sheetId, revisionId, instanceId);
        }

        [Test]
        public void Test_UpdateProjectSheetRevisionInstance()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int sheetId = __GetProjectSheetRandom(hubId, projectId, "AutoSheetForInstanceTest.pdf");
            int revisionId = __GetProjectSheetRevisionRandom(hubId, projectId, sheetId, "AutoSheetRevisionForInstanceTest.pdf");
            int instanceId = __GetProjectSheetRevisionInstanceRandom(hubId, projectId, sheetId, revisionId);

            Instance instance = new Instance();
            instance.ViewName = "UpdatedRevisionInstance";
            
            ProjectSheetRevisionInstanceApi projectSheetRevisionInstanceApi = new ProjectSheetRevisionInstanceApi();
            projectSheetRevisionInstanceApi.UpdateProjectSheetRevisionInstance(hubId, projectId, sheetId, revisionId,
                instanceId, instance);
        }
        
        [Test]
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
        }
        
        // We need to delete the instance and the revision that were created
        [Test]
        public void End_DeleteSheetAndRevision()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int sheetId = __GetProjectSheetRandom(hubId, projectId, "AutoSheetForInstanceTest.pdf");

            ProjectSheetApi projectSheetApi = new ProjectSheetApi();
            projectSheetApi.DeleteProjectSheet(hubId, projectId, sheetId);
            // I don't need to delete the revision, because deleting the sheet implicitly deletes the revision.
        }
    }
}