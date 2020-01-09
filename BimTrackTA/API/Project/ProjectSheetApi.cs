using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{
    public class ProjectSheetApi : ApiBase
    {
        public List<Sheet> GetProjectSheetList(int hubId, int projectId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/sheets";
            return Perform_Get<List<Sheet>>(connStr);
        }

        public bool CreateProjectSheet(int hubId, int projectId, Sheet sheet)
        {
            string jsonPayload = JsonConvert.SerializeObject(sheet);
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/sheets";
            IRestResponse response =  Perform_Create(connStr, jsonPayload);
            
            return response.IsSuccessful;
        }
        
        public bool DeleteProjectSheet(int hubId, int projectId, int sheetId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/sheets/" + sheetId;
            IRestResponse response = Perform_Delete(connStr);
            
            return response.IsSuccessful;
        }

        public Sheet GetProjectSheet(int hubId, int projectId, int sheetId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/sheets/" + sheetId;
            return Perform_Get<Sheet>(connStr);
        }
    }
}