using System.Collections.Generic;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{
    public class HubApi : ApiBase
    {
        public List<Hub> GetHubList()
        {
            string connStr = API_VERSION + HUB_ROUTE;
            return Perform_Get<List<Hub>>(connStr);
        }

        public Hub GetHub(int hubId)
        {
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId;
            return Perform_Get<Hub>(connStr);
        }
    }
}

