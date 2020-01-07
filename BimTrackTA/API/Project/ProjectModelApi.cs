using System.Collections.Generic;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{
    public class ProjectModelApi : ApiBase
    {
        public List<Project.Model> GetProjectModelList(int hubId, int projectId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/models";
            return Perform_Get<List<Project.Model>>(connStr);
        }

        public bool CreateProjectModel(int hubId, int projectId, string name)
        {
            string jsonToSend = "{'Name': '" + name + "'}";
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/models";
            IRestResponse response =  Perform_Create(connStr, jsonToSend);
            
            return response.IsSuccessful;
        }
        
        public bool DeleteProjectModel(int hubId, int projectId, int modelId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/models/" + modelId;
            IRestResponse response =  Perform_Delete(connStr);
            
            return response.IsSuccessful;
        }

        public Project.Model GetProjectModel(int hubId, int projectId, int modelId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/models/" + modelId;
            return Perform_Get<Project.Model>(connStr);
        }

        public bool UpdateProjectModel(int hubId, int projectId, int modelId, string key, object value)
        {
            string jsonToSend = Create_UpdateJsonString(key, value);
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/models/" + modelId;
            IRestResponse response = Perform_Update(connStr, jsonToSend);

            return response.IsSuccessful;
        }
    }
}