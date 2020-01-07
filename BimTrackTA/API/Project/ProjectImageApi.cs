using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{
    public class ProjectImageApi : ApiBase
    {
        public bool UpdateProjectImage(int hubId, int projectId, string key, object value)
        {
            string jsonToSend = Create_UpdateJsonString(key, value);
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/image";
            IRestResponse response = Perform_Create(connStr, jsonToSend);

            return response.IsSuccessful;
        }
    }
}