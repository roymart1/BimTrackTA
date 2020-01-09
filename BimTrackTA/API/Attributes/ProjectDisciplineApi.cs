using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{

    public class ProjectDisciplineApi : ApiBase
    {
        public List<Discipline> GetHubProjectDisciplineList(int hubId, int projectId)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/disciplines";
            return Perform_Get<List<Discipline>>(connStr);
        }

        public bool CreateHubProjectDiscipline(int hubId, int projectId, Discipline discipline)
        {
            string jsonPayload = JsonConvert.SerializeObject(discipline);
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/disciplines";
            IRestResponse response =  Perform_Create(connStr, jsonPayload);
            
            return response.IsSuccessful;
        }

        public bool DeleteHubProjectDiscipline(int hubId, int projectId, int disciplineId)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/disciplines/" + disciplineId;
            
            IRestResponse response = Perform_Delete(connStr);
            return response.IsSuccessful;
            
        }

        public bool UpdateHubProjectDiscipline(int hubId, int projectId, int disciplineId, Discipline discipline)
        {
            string jsonPayload = JsonConvert.SerializeObject(discipline);
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/disciplines/" + disciplineId;
            
            IRestResponse response = Perform_Update(connStr, jsonPayload);
            return response.IsSuccessful;
        }
        
    }
}