using System;
using System.Collections.Generic;
using BimTrackTA.API;
using BimTrackTA.Common.WebDriver;
using NUnit.Framework;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{

    public class HubUserApiTests : GeneralTestBase
    {
        [Test, Order(1)]
        public void Test_CreateHubUsers()
        {
            int hubId = __GetHubRandom();
        
            // Go on with the retrieval of the project list 
            HubUserApi hubUserApi = new HubUserApi();
            bool bRet = hubUserApi.CreateHubUser(hubId, 
                "bimoneauto+zxz" + new Random().Next(99999) + "@gmail.com", 
                HubUserApi.UserType.Admin);
        }
        
        [Test, Order(2)]
        public void Test_GetHubUsers()
        {
            int hubId = __GetHubRandom();
        
            HubUserApi hubUserApi = new HubUserApi();
            List<HubUser> prjUsers = hubUserApi.GetHubUsers(hubId);
        }

        [Test, Order(3)]
        public void Test_UpdateHubUsers()
        {
            int hubId = __GetHubRandom();
            int hubUserId = __GetHubUserRandom(hubId, "bimoneauto+zxz89674@gmail.com");
            
            HubUserApi hubUserApi = new HubUserApi();
            hubUserApi.UpdateUser(hubId, hubUserId, HubUserApi.UserType.Guest, false);
        }
        
        [Test, Order(4)]
        public void Test_DeleteHubUsers()
        {
            int hubId = __GetHubRandom();
            int hubUserId = __GetHubUserRandom(hubId, "bimoneauto+zxz89674@gmail.com");         
        
            HubUserApi hubUserApi = new HubUserApi();
            bool bRet = hubUserApi.DeleteHubUser(hubId, hubUserId);
        }
    }
}