using System.Collections.Generic;
using BimTrackTA.API;
using BimTrackTA.Common.WebDriver;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{

    public class ProjectDisciplineApiTests : GeneralTestBase
    {
        [Test, Order(1)]
        public void Test_CreateProjectDiscipline()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");

            Discipline discipline = new Discipline {Name = "AutoProjectDisciplineTest"};
            ProjectDisciplineApi projectDisciplineApi = new ProjectDisciplineApi();
            projectDisciplineApi.CreateProjectDiscipline(hubId, projectId, discipline);
        }
        
        [Test, Order(2)]
        public void Test_GetProjectDisciplineList()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            
            ProjectDisciplineApi projectDisciplineApi = new ProjectDisciplineApi();
            projectDisciplineApi.GetProjectDisciplines(hubId, projectId);
        }  

        [Test, Order(3)]
        public void Test_UpdateProjectDisciplineCustom()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int disciplineId = __GetProjectDisciplineRandom(hubId, projectId, "AutoProjectDisciplineTest");

            Discipline discipline = new Discipline {Name = "UpdatedProjectDisciplineTest"};
            ProjectDisciplineApi projectDisciplineApi = new ProjectDisciplineApi();
            projectDisciplineApi.UpdateProjectDiscipline(hubId, projectId, disciplineId, discipline);
        }

        [Test, Order(4)]
        public void Test_DeleteProjectDiscipline()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int disciplineId = __GetProjectDisciplineRandom(hubId, projectId, "UpdatedProjectDisciplineTest");
                        
            ProjectDisciplineApi projectDisciplineApi = new ProjectDisciplineApi();
            projectDisciplineApi.DeleteProjectDiscipline(hubId, projectId, disciplineId);
        }
    }
}