using System.Collections.Generic;
using BimTrackTA.API;
using BimTrackTA.Common.WebDriver;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{

    public class ProjectDisciplineApiTests : GeneralTestBase
    {
        [Test]
        public void Test_GetProjectDisciplineList()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            
            ProjectDisciplineApi projectDisciplineApi = new ProjectDisciplineApi();

            List<Discipline> listPrjDisciplines = projectDisciplineApi.GetHubProjectDisciplineList(hubId, projectId);
        }    
        
        [Test]
        public void Test_CreateProjectDiscipline()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            string name = "AutoProjectDisciplineTest";

            ProjectDisciplineApi projectDisciplineApi = new ProjectDisciplineApi();
            projectDisciplineApi.CreateHubProjectDiscipline(hubId, projectId, name);
        }

        [Test]
        public void Test_UpdateProjectDisciplineCustom()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int disciplineId = __GetProjectDisciplineRandom(hubId, projectId, "AutoProjectDisciplineTest");

            string key = "Name";
            string value = "UpdatedProjectDisciplineTest";
            
            ProjectDisciplineApi projectDisciplineApi = new ProjectDisciplineApi();
            projectDisciplineApi.UpdateHubProjectDiscipline(hubId, projectId, disciplineId, key, value);
        }

        [Test]
        public void Test_DeleteProjectDiscipline()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int disciplineId = __GetProjectDisciplineRandom(hubId, projectId, "UpdatedProjectDisciplineTest");
                        
            ProjectDisciplineApi projectDisciplineApi = new ProjectDisciplineApi();
            projectDisciplineApi.DeleteHubProjectDiscipline(hubId, projectId, disciplineId);
        }

    }
}