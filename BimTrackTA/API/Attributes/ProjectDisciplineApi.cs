using System;
using System.Collections.Generic;
using RestSharp;
using SeleniumTest.BusinessObjects;
using SeleniumTest.Common.Exceptions;

namespace BimTrackTA.API
{

    public class ProjectDisciplineApi : ApiBase
    {
        public List<Discipline> GetProjectDisciplines(int hubId, int projectId)
        {
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + DISCI_ROUTE;
            return Perform_Get<List<Discipline>>(connStr);
        }

        public int CreateProjectDiscipline(int hubId, int projectId, Discipline discipline)
        {
            // Validate that the object is fine
            ValidateOperation(discipline);
            
            // Required fields for Discipline object are: 
            //     - Name (string)
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + DISCI_ROUTE;
            return Perform_Create(connStr, discipline);
        }

        public bool DeleteProjectDiscipline(int hubId, int projectId, int disciplineId)
        {
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + DISCI_ROUTE + "/" + disciplineId;
            
            IRestResponse response = Perform_Delete(connStr);
            return response.IsSuccessful;
        }

        public bool UpdateProjectDiscipline(int hubId, int projectId, int disciplineId, Discipline discipline)
        {
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + DISCI_ROUTE + "/" + disciplineId;
            
            IRestResponse response = Perform_Update(connStr, discipline);
            return response.IsSuccessful;
        }
        
        private void ValidateOperation(Discipline discipline)
        {
            if (discipline == null) throw new ArgumentNullException(nameof(discipline));
            if (discipline.Name == null)
            {
                throw new CustomObjectAttributeException("a name","project discipline");
            }
        }
    }
}