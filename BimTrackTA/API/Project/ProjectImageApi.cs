using Newtonsoft.Json;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{
    public class ProjectImageApi : ApiBase
    {
        public bool UpdateProjectImage(int hubId, int projectId, string fileName, string filePath)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/image";
            IRestResponse response = Perform_Create_Multipart(connStr, fileName, filePath);

            return response.IsSuccessful;
        }
    }
}