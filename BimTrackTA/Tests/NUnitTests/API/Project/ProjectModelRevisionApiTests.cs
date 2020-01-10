using System.Collections.Generic;
using BimTrackTA.Common.WebDriver;
using BimTrackTA.API;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class ProjectModelRevisionApiTests : GeneralTestBase
    {
        // We need to create the project model first
        [Test]
        public void Setup_CreateProjectModel()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            
            string modelName = "ModelForRevisionTest.ifc";
            string pathToModel = "../../../Tests/NUnitTests/API/TestResources/Model.ifc";
            
            ProjectModelApi projectModelApi = new ProjectModelApi();
            projectModelApi.CreateProjectModel(hubId, projectId, modelName, pathToModel);
        }
        
        [Test]
        public void Test_GetProjectModelRevisions()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int modelId = __GetProjectModelRandom(hubId, projectId, "ModelForRevisionTest.ifc");
            
            ProjectModelRevisionApi projectModelRevisionApi = new ProjectModelRevisionApi();
            List<Revision> revisions = projectModelRevisionApi.GetProjectModelRevisionList(hubId, projectId, modelId);
        }

        [Test]
        public void Test_CreateProjectModelRevision()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int modelId = __GetProjectModelRandom(hubId, projectId, "ModelForRevisionTest.ifc");

            string fileName = "Revision.ifc";
            string pathToRevision = "../../../Tests/NUnitTests/API/TestResources/Model.ifc";
            
            ProjectModelRevisionApi projectModelRevisionApi = new ProjectModelRevisionApi();
            projectModelRevisionApi.CreateProjectModelRevision(hubId, projectId, modelId, fileName, pathToRevision);
        }   
        
        [Test]
        public void Test_GetProjectModelRevision()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int modelId = __GetProjectModelRandom(hubId, projectId, "ModelForRevisionTest.ifc");
            int revisionId = __GetProjectModelRevisionRandom(hubId, projectId, modelId, "Revision.ifc");

            ProjectModelRevisionApi projectModelRevisionApi = new ProjectModelRevisionApi();
            Revision revision = projectModelRevisionApi.GetProjectModelRevision(hubId, projectId, modelId, revisionId);
        }

        [Test]
        public void Test_DeleteProjectModelRevision()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int modelId = __GetProjectModelRandom(hubId, projectId, "ModelForRevisionTest.ifc");
            int revisionId = __GetProjectModelRevisionRandom(hubId, projectId, modelId, "Revision.ifc");
            
            ProjectModelRevisionApi projectModelRevisionApi = new ProjectModelRevisionApi();
            projectModelRevisionApi.DeleteProjectModelRevision(hubId, projectId, modelId, revisionId);
        }
                
        // Delete the project used to create the revision at the end
        [Test]
        public void End_DeleteProjectModel()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int modelId = __GetProjectModelRandom(hubId, projectId, "ModelForRevisionTest.ifc");
            
            ProjectModelApi projectModelApi = new ProjectModelApi();
            projectModelApi.DeleteProjectModel(hubId, projectId, modelId);
        }
    }
}