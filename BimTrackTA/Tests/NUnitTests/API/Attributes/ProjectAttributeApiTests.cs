using BimTrackTA.API;
using BimTrackTA.Common.WebDriver;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{

    public class ProjectAttributeApiTests : GeneralTestBase
    { 
        [Test, Order(1)]
        public void Test1_CreateProjectAttributePredefined()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);


            var prjAttr = new ProjectAttribute {Name = "ZenPredef", Type = "Predefined"};
            prjAttr.AddNewCustomAttributeValue("xzenred", "#FF0000");
            prjAttr.AddNewCustomAttributeValue("xzengreen", "#00FF00");
            prjAttr.AddNewCustomAttributeValue("xzenblue", "#0000FF");
            
            ProjectAttributeApi projectAttributeApi = new ProjectAttributeApi();
            projectAttributeApi.CreateHubProjectAttribute(hubId, projectId, prjAttr);
        }
        
        [Test, Order(2)]
        public void Test2_CreateProjectAttributeCustom()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);

            var prjAttr = new ProjectAttribute {Name = "ZenCustom", Type = "Text"};

            ProjectAttributeApi projectAttributeApi = new ProjectAttributeApi();
            projectAttributeApi.CreateHubProjectAttribute(hubId, projectId, prjAttr);
        }
        [Test, Order(3)]
        public void Test3_GetProjectAttributeDetail()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int projectAttributeId = __GetHubProjectAttributeRandom(hubId, projectId, "ZenCustom", true);

            ProjectAttributeApi projectAttributeApi = new ProjectAttributeApi();
            projectAttributeApi.GetHubProjectAttributeDetail(hubId, projectId, projectAttributeId);
        }    
        
        [Test, Order(4)]
        public void Test4_GetProjectAttributeList()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            
            ProjectAttributeApi projectAttributeApi = new ProjectAttributeApi();
            projectAttributeApi.GetHubProjectAttributeList(hubId, projectId);
        }    

        
        [Test, Order(5)]
        public void Test5_UpdateProjectAttributeCustom()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int attrId = __GetHubProjectAttributeRandom(hubId, projectId, "ZenCustom", true);

            ProjectAttribute projectAttribute = new ProjectAttribute {Name = "UpdatedZenCustom", Type = "Text"};
            
            ProjectAttributeApi projectAttributeApi = new ProjectAttributeApi();
            projectAttributeApi.UpdateHubProjectAttribute(hubId, projectId, attrId, projectAttribute);
        }

        [Test, Order(6)]
        public void Test6_DeleteProjectAttributePredef()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int attrId = __GetHubProjectAttributeRandom(hubId, projectId, "ZenPredef", true);
                        
            ProjectAttributeApi projectAttributeApi = new ProjectAttributeApi();
            projectAttributeApi.DeleteHubProjectAttribute(hubId, projectId, attrId);
        }

        [Test, Order(7)]
        public void Test7_DeleteProjectAttributeCustom()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int attrId = __GetHubProjectAttributeRandom(hubId, projectId, "UpdatedZenCustom", true);
                        
            ProjectAttributeApi projectAttributeApi = new ProjectAttributeApi();
            projectAttributeApi.DeleteHubProjectAttribute(hubId, projectId, attrId);
        }
    }
}