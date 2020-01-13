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
            // Required fields for Folder object are: 
            //     - Name (string)
            //
            // Since you need a project id, that means that you need to have created a project in that hub first.
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
        
        public bool UpdateProjectModelFolder(int hubId, int projectId, int projectModelFolderId, Folder folder)
        {
            string jsonPayload = JsonConvert.SerializeObject(folder);
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/models/folders/" + projectModelFolderId;
            IRestResponse response = Perform_Update(connStr, jsonPayload);

            return response.IsSuccessful;
        }
    }
}