using System.Collections.Generic;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{
    public class ProjectSheetFolderApi : ApiBase
    {
        public List<Folder> GetProjectSheetFolderList(int hubId, int projectId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/sheets/folders";
            return Perform_Get<List<Folder>>(connStr);
        }

        public bool CreateProjectSheetFolder(int hubId, int projectId, string name)
        {
            string jsonToSend = "{'Name': '" + name + "'}";
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/sheets/folders";
            IRestResponse response =  Perform_Create(connStr, jsonToSend);
            
            return response.IsSuccessful;
        }
        
        public bool DeleteProjectSheetFolder(int hubId, int projectId, int projectSheetFolderId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/sheets/folders/" + projectSheetFolderId;
            IRestResponse response =  Perform_Delete(connStr);
            
            return response.IsSuccessful;
        }
        
        public bool UpdateProjectSheetFolder(int hubId, int projectId, int projectSheetFolderId, string key, object value)
        {
            string jsonToSend = "{'" + key + "': '" + value + "'}";
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/sheets/folders/" + projectSheetFolderId;
            IRestResponse response = Perform_Update(connStr, jsonToSend);

            return response.IsSuccessful;
        }
    }
}