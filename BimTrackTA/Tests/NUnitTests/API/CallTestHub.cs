using System;
using System.Collections.Generic;
using BimTrackTA.API;
using BimTrackTA.Common.WebDriver;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;
using SeleniumTest.Common;
using SeleniumTest.Common.Exceptions;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class CallTestHub : GeneralTestBase
    {
        
        [Test]
        public void CallTest()
        {
            HubAPI hubApiApi = new HubAPI();
            List<Hub> listHub = hubApiApi.GetHubList();
            if (listHub.Count == 0) 
            { 
                throw new BTException("API Test: No hubs were found");
            }

            Hub hubObj = hubApiApi.GetHub(listHub[0].Id);
            List<ProjectTemplate> listTmpl = hubApiApi.GetHubProjectTemplates(listHub[0].Id);
            
            
            Console.Out.WriteLine("------------------------------------------");
        }    
    }
}