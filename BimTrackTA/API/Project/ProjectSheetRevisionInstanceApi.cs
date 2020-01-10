using System;
using System.Collections.Generic;
using Newtonsoft.Json;
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
            Instance instance)
        {
            if (instance.CropBoxCenter == null || instance.CropBoxRotation == null || instance.CropBoxSize == null ||
                instance.Position == null || instance.Rotation == null)
            {
                throw new Exception("You need to provide these values:\n" +
                                    "    - CropBoxCenter (Type: Xyz)\n" +
                                    "    - CropBoxRotation (Type: Xyz)\n" +
                                    "    - CropBoxSize (Type: Xyz)\n" +
                                    "    - Position (Type: Xyz)\n" +
                                    "    - Rotation (Type: Xyz)\n");
            }
                string jsonPayload = JsonConvert.SerializeObject(instance);
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/sheets/" + sheetId 
                             + "/revisions/" + revisionId  + "/instances";
            IRestResponse response =  Perform_Create(connStr, jsonPayload);
            
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
            int instanceId, Instance instance)
        {
            string jsonPayload = JsonConvert.SerializeObject(instance);
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/sheets/" + sheetId 
                             + "/revisions/" + revisionId + "/instances/" + instanceId;
            IRestResponse response =  Perform_Update(connStr, jsonPayload);

            return response.IsSuccessful;
        }
    }
}