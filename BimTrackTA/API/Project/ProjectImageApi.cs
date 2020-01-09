using Newtonsoft.Json;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{
    public class ProjectImageApi : ApiBase
    {
        public bool UpdateProjectImage(int hubId, int projectId, BimImage image)
        {
            string jsonPayload = JsonConvert.SerializeObject(image);
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/image";
            IRestResponse response = Perform_Create(connStr, jsonPayload);

            return response.IsSuccessful;
        }
    }
}