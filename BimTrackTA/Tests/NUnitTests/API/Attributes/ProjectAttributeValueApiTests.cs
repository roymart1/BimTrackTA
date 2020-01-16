using System;
using System.Collections.Generic;
using BimTrackTA.API;
using BimTrackTA.Common.WebDriver;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{

    public class ProjectAttributeValueApiTests : GeneralTestBase
    {
        [Test, Order(1)]
        public void Test1_CreateProjectAttributeValue()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            
            // We need to create the project attribute before we can give it a value...
            var prjAttr = new ProjectAttribute {Name = "ZenPredef", Type = "Predefined"};
            ProjectAttributeApi projectAttributeApi = new ProjectAttributeApi(); 
            int attrValId = projectAttributeApi.CreateHubProjectAttribute(hubId, projectId, prjAttr);

            AttributeValue prjCst = new AttributeValue {Name = "zenUnknown", Color = "#550088"};
            ProjectAttributeValuesApi prjAttrValApi = new ProjectAttributeValuesApi();
            prjAttrValApi.CreateProjectAttributeValue(hubId, projectId, attrValId, prjCst);
        }
        
        [Test, Order(2)]
        public void Test2_GetProjectAttributeValueList()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int attrValId = __GetHubProjectAttributeRandom(hubId, projectId, "ZenPredef", true);
            
            ProjectAttributeValuesApi prjAttrValApi = new ProjectAttributeValuesApi();
            List<AttributeValue> listAttrVal;
            prjAttrValApi.GetProjectAttributeValues(hubId, projectId, attrValId);
        }

        [Test, Order(3)]
        public void Test3_UpdateProjectAttributeValue()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int attrId = __GetHubProjectAttributeRandom(hubId, projectId, "ZenPredef", true);
            int attrValId = __GetHubProjectAttributeValueRandom(hubId, projectId, attrId, "zenUnknown", true);

            AttributeValue attributeValue = new AttributeValue
            {
                Name = "UpdatedZenUnknown", Color = "#FF0000"
            };

            ProjectAttributeValuesApi prjAttrValApi = new ProjectAttributeValuesApi();
            prjAttrValApi
                .UpdateProjectAttributeValue(hubId, projectId, attrId, attrValId, attributeValue);
        }
        
        [Test, Order(4)]
        public void Test4_DeleteProjectAttributeValue()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int attrId = __GetHubProjectAttributeRandom(hubId, projectId, "ZenPredef", true);
            int attrValId = __GetHubProjectAttributeValueRandom(hubId, projectId, attrId, "UpdatedZenUnknown", true);
            
            ProjectAttributeValuesApi prjAttrValApi = new ProjectAttributeValuesApi();
            prjAttrValApi.DeleteProjectAttributeValue(hubId, projectId, attrId, attrValId);
            
            // Delete the attribute created in the first test
            ProjectAttributeApi projectAttributeApi = new ProjectAttributeApi();
            projectAttributeApi.DeleteHubProjectAttribute(hubId, projectId, attrId);
        }
    }
}