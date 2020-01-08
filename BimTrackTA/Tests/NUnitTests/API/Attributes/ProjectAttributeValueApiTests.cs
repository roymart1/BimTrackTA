using System.Collections.Generic;
using BimTrackTA.API;
using BimTrackTA.Common.WebDriver;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{

    public class ProjectAttributeValueApiTests : GeneralTestBase
    {
        [Test]
        public void Test_GetProjectAttributeValueList()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int attrValId = __GetHubProjectAttributeRandom(hubId, projectId);
            
            ProjectAttributeValuesApi prjAttrValApi = new ProjectAttributeValuesApi();

            List<PredefinedAttributeValue> listAttrVal;
            listAttrVal = prjAttrValApi.GetHubProjectAttributeValueList(hubId, projectId, attrValId);
        }

        [Test]
        public void Test_CreateProjectAttributeValue()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int attrValId = __GetHubProjectAttributeRandom(hubId, projectId);
            
            // Create object AttributValue
            PredefinedAttributeValue prjCst = new PredefinedAttributeValue();
            prjCst.Name = "zenUnknown";
            prjCst.Color = "#550088";
            
            ProjectAttributeValuesApi prjAttrValApi = new ProjectAttributeValuesApi();
            prjAttrValApi.CreateHubProjectAttributeValue(hubId, projectId, attrValId, prjCst);
        }

        [Test]
        public void Test_UpdateProjectAttributeValue()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int attrId = __GetHubProjectAttributeRandom(hubId, projectId);
            int attrValId = __GetHubProjectAttributeValueRandom(hubId, projectId, attrId, "zenUnknown");

            string key = "Name";
            string value = "UpdatedZenUnknown";
            
            ProjectAttributeValuesApi prjAttrValApi = new ProjectAttributeValuesApi();
            prjAttrValApi.UpdateHubProjectAttributeValue(hubId, projectId, attrValId, attrValId, key, value);
        }
        
        [Test]
        public void Test_DeleteProjectAttributeValue()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int attrId = __GetHubProjectAttributeRandom(hubId, projectId);
            int attrValId = __GetHubProjectAttributeValueRandom(hubId, projectId, attrId, "UpdatedZenUnknown");
            
            ProjectAttributeValuesApi prjAttrValApi = new ProjectAttributeValuesApi();
            prjAttrValApi.DeleteHubProjectAttributeValue(hubId, projectId, attrId, attrValId);
        }

        
    }
}