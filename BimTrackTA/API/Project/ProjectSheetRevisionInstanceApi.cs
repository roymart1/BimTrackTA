using System.Collections.Generic;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{
    public class ProjectSheetRevisionInstanceApi : ApiBase
    {
        public List<Instance> GetProjectSheetRevisionInstanceList(int hubId, int projectId, int sheetId, int revisionId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/sheets/" + sheetId 
                             + "/revisions/" + revisionId + "/instances";
            return Perform_Get<List<Instance>>(connStr);
        }

        public bool CreateProjectSheetRevisionInstance(int hubId, int projectId, int sheetId, int revisionId, 
            string name)
        {
            string jsonToSend = "{'ViewName': '" + name + "'}";
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/sheets/" + sheetId 
                             + "/revisions/" + revisionId  + "/instances";
            IRestResponse response =  Perform_Create(connStr, jsonToSend);
            
            return response.IsSuccessful;
        }
        
        public bool DeleteProjectSheetRevisionInstance(int hubId, int projectId, int sheetId, int revisionId, 
            int instanceId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/sheets/" + sheetId  
                             + "/revisions/" + revisionId + "/instances/" + instanceId;
            IRestResponse response =  Perform_Delete(connStr);
            
            return response.IsSuccessful;
        }

        public Instance GetProjectSheetRevisionInstance(int hubId, int projectId, int sheetId, int revisionId, 
            int instanceId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/sheets/" + sheetId 
                             + "/revisions/" + revisionId + "/instances/" + instanceId;
            return Perform_Get<Instance>(connStr);
        }

        public bool UpdateProjectSheetRevisionInstance(int hubId, int projectId, int sheetId, int revisionId,
            int instanceId, string key, object value)
        {
            string jsonToSend = Create_UpdateJsonString(key, value);
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/sheets/" + sheetId 
                             + "/revisions/" + revisionId + "/instances/" + instanceId;
            IRestResponse response =  Perform_Update(connStr, jsonToSend);

            return response.IsSuccessful;
        }
    }
}