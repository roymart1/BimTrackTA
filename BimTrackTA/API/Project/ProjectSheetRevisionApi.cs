using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{
    public class ProjectSheetRevisionApi : ApiBase
    {
        public List<Revision> GetProjectSheetRevisionList(int hubId, int projectId, int sheetId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/sheets/" + sheetId + "/revisions";
            return Perform_Get<List<Revision>>(connStr);
        }

        public bool CreateProjectSheetRevision(int hubId, int projectId, int sheetId, string revisionName, string revisionPath)
        {
            // Since we are using Multipart, you need to provide a file name and a filepath. The file name needs
            // to end with .pdf. A revision is basically another sheet object, so it works the same
            // way as the ProjectSheetApi.
            //
            // Since you need a sheet id, that means that you need to have created a project in that hub first and
            // a sheet created in that project.
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/sheets/" + sheetId + "/revisions";
            IRestResponse response =  Perform_Create_Multipart(connStr, revisionName, revisionPath);
            
            return response.IsSuccessful;
        }
        
        public bool DeleteProjectSheetRevision(int hubId, int projectId, int sheetId, int revisionId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/sheets/" + sheetId  
                             + "/revisions/" + revisionId;
            IRestResponse response =  Perform_Delete(connStr);
            
            return response.IsSuccessful;
        }

        public Revision GetProjectSheetRevision(int hubId, int projectId, int sheetId, int revisionId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/sheets/" + sheetId 
                             + "/revisions/" + revisionId;
            return Perform_Get<Revision>(connStr);
        }
    }
}