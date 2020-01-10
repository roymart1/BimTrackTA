using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{
    public class ProjectModelRevisionApi : ApiBase
    {
        public List<Revision> GetProjectModelRevisionList(int hubId, int projectId, int modelId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/models/" + modelId + "/revisions";
            return Perform_Get<List<Revision>>(connStr);
        }

        public bool CreateProjectModelRevision(int hubId, int projectId, int modelId, string revisionName, string filePath)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/models/" + modelId + "/revisions";
            IRestResponse response =  Perform_Create_Multipart(connStr, revisionName, filePath);
            
            return response.IsSuccessful;
        }
        
        public bool DeleteProjectModelRevision(int hubId, int projectId, int modelId, int revisionId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/models/" + modelId  
                             + "/revisions/" + revisionId;
            IRestResponse response =  Perform_Delete(connStr);
            
            return response.IsSuccessful;
        }

        public Revision GetProjectModelRevision(int hubId, int projectId, int modelId, int revisionId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/models/" + modelId 
                             + "/revisions/" + revisionId;
            return Perform_Get<Revision>(connStr);
        }
    }
}