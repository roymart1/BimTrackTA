using System.Collections.Generic;
using BimTrackTA.API;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class CallTestHub
    {
        [Test]
        public void CallTest()
        {
            HubAPI hubApiApi = new HubAPI();
            List<Hub> listHub = hubApiApi.GetHubList();
        }    
    }
}