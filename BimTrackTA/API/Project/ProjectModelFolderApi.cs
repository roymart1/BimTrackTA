using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{
    public class ProjectModelFolderApi : ApiBase
    {
        public List<Folder> GetProjectModelFolderList(int hubId, int projectId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/models/folders";
            return Perform_Get<List<Folder>>(connStr);
        }

        public bool CreateProjectModelFolder(int hubId, int projectId, Folder folder)
        {
            string jsonPayload = JsonConvert.SerializeObject(folder);
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/models/folders";
            IRestResponse response =  Perform_Create(connStr, jsonPayload);
            
            return response.IsSuccessful;
        }
        
        public bool DeleteProjectModelFolder(int hubId, int projectId, int projectModelFolderId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/models/folders/" + projectModelFolderId;
            IRestResponse response =  Perform_Delete(connStr);
            
            return response.IsSuccessful;
        }
        
        public bool UpdateProjectModelFolder(int hubId, int projectId, int projectModelFolderId, string key, object value)
        {
            string jsonToSend = Create_UpdateJsonString(key, value);
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/models/folders/" + projectModelFolderId;
            IRestResponse response = Perform_Update(connStr, jsonToSend);

            return response.IsSuccessful;
        }
    }
}