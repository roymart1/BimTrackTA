using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{
    public class IssueViewPointApi : ApiBase
    {
        public List<ViewPoint> GetIssueViewPointList(int hubId, int projectId, int issueId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId + "/viewpoints";
            return Perform_Get<List<ViewPoint>>(connStr);
        }

        public bool CreateIssueViewPoint(int hubId, int projectId, int issueId, ViewPoint viewPoint, string imageName, string imagePath)
        {
            string jsonPayload = JsonConvert.SerializeObject(viewPoint);
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId
                             + "/viewpoints";
            IRestResponse response =  Perform_Create_Multipart(connStr, imageName, imagePath,  jsonPayload);
        
            return response.IsSuccessful;
        }

        public ViewPoint GetIssueViewPoint(int hubId, int projectId, int issueId, int viewPointId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId 
                             + "/viewpoints/" + viewPointId;
            return Perform_Get<ViewPoint>(connStr);
        }
        
        public bool DeleteIssueViewPoint(int hubId, int projectId, int issueId, int viewPointId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId 
                             + "/viewpoints/" + viewPointId;
            IRestResponse response = Perform_Delete(connStr);

            return response.IsSuccessful;
        }

        public bool UpdateIssueViewPoint(int hubId, int projectId, int issueId, int viewPointId, ViewPoint viewPoint)
        {
            string jsonPayload = JsonConvert.SerializeObject(viewPoint);
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId 
                             + "/viewpoints/" + viewPointId;
            IRestResponse response = Perform_Update(connStr, jsonPayload);

            return response.IsSuccessful;
        }
    }
}

