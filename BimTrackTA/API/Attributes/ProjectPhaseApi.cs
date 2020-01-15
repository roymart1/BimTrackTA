using System;
using System.Collections.Generic;
using RestSharp;
using SeleniumTest.BusinessObjects;
using SeleniumTest.Common.Exceptions;

namespace BimTrackTA.API
{

    public class ProjectPhaseApi : ApiBase
    {
        public List<Phase> GetProjectPhases(int hubId, int projectId)
        {
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + PHASE_ROUTE;
            return Perform_Get<List<Phase>>(connStr);
        }

        public int CreateProjectPhase(int hubId, int projectId, Phase phase)
        {
            // Validate the the object is fine
            ValidateOperation(phase);

            // Required fields for Phase object are: 
            //     - Name (string)
            //     - Color (hex format)
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + PHASE_ROUTE;
            return Perform_Create(connStr, phase);
        }

        public bool DeleteProjectPhase(int hubId, int projectId, int phaseId)
        {
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + PHASE_ROUTE + "/" + phaseId;
            
            IRestResponse response = Perform_Delete(connStr);
            return response.IsSuccessful;
            
        }

        public bool UpdateProjectPhase(int hubId, int projectId, int phaseId, Phase phase)
        {
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + PHASE_ROUTE + "/" + phaseId;
            
            IRestResponse response = Perform_Update(connStr, phase);
            return response.IsSuccessful;
        }
        
        private void ValidateOperation(Phase phase)
        {
            if (phase == null) throw new ArgumentNullException(nameof(phase));
            if (phase.Name == null)
            {
                throw new CustomObjectAttributeException("a name","project phase");
            }
            if (phase.Color == null)
            {
                throw new CustomObjectAttributeException("a color in hex format", "project phase");
            }
        }
    }
}