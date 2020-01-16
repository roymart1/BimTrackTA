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
        // You need to run this whole test suite. Otherwise, the generatedUserId will always change...
        private readonly int _generatedUserId = new Random().Next(99999);

        [Test, Order(1)]
        public void Test1_CreateHubUsers()
        {
            int hubId = __GetHubRandom();
        
            // Go on with the retrieval of the project list 
            HubUserApi hubUserApi = new HubUserApi();
            Console.Write(_generatedUserId);
            hubUserApi.CreateHubUser(hubId,"bimoneauto+zxz" + _generatedUserId + "@gmail.com");
        }
        
        [Test, Order(2)]
        public void Test2_GetHubUsers()
        {
            int hubId = __GetHubRandom();
        
            HubUserApi hubUserApi = new HubUserApi();
            hubUserApi.GetHubUsers(hubId);
        }

        [Test, Order(3)]
        public void Test3_UpdateHubUsers()
        {
            int hubId = __GetHubRandom();
            int hubUserId = __GetHubUserRandom(hubId, "bimoneauto+zxz" + _generatedUserId + "@gmail.com", true);
            
            HubUserApi hubUserApi = new HubUserApi();
            hubUserApi.UpdateUser(hubId, hubUserId, HubUserApi.UserType.Guest, false);
        }
        
        [Test, Order(4)]
        public void Test4_DeleteHubUsers()
        {
            int hubId = __GetHubRandom();
            int hubUserId = __GetHubUserRandom(hubId, "bimoneauto+zxz" + _generatedUserId + "@gmail.com", true);         
        
            HubUserApi hubUserApi = new HubUserApi();
            hubUserApi.DeleteHubUser(hubId, hubUserId);
        }
    }
}