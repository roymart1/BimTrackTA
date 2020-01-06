
using System;
using System.Collections.Generic;
using BimTrackTA.API;
using BimTrackTA.Common.WebDriver;
using NUnit.Framework;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{

    public class HubUserAPITests : GeneralTestBase
    {
        [Test]
        public void Test_GetHubUsers()
        {
            int hubId = __GetHubRandom();
        
            // Go on with the retrieval of the project list 
            HubUserApi hubUserApi = new HubUserApi();
            List<HubUser> prjUsers = hubUserApi.GetHubUsers(hubId);
        }
        
        [Test]
        public void Test_CreateHubUsers()
        {
            int hubId = __GetHubRandom();
        
            // Go on with the retrieval of the project list 
            HubUserApi hubUserApi = new HubUserApi();
            bool bRet = hubUserApi.CreateHubUser(hubId, 
                "bimoneauto+zxz" + new Random().Next(99999) + "@gmail.com", 
                HubUserApi.UserType.Admin);
        }
        
        [Test]
        public void Test_DeleteHubUsers()
        {
            int hubId = __GetHubRandom();
            int hubUserId = __GetHubUserRandom(hubId, "bimoneauto+zxz89674@gmail.com");         
        
            // Go on with the retrieval of the project list 
            HubUserApi hubUserApi = new HubUserApi();
            bool bRet = hubUserApi.DeleteHubUser(hubId, hubUserId);
        }

        [Test]
        public void Test_UpdateHubUsers()
        {
            int hubId = __GetHubRandom();
            int hubUserId = __GetHubUserRandom(hubId, "bimoneauto+zxz89674@gmail.com");
            
            HubUserApi hubUserApi = new HubUserApi();
            bool bRet = hubUserApi.UpdateUser(hubId, hubUserId, HubUserApi.UserType.Guest, false);
        }
    }
}