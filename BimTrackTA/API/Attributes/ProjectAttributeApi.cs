using System;
using System.Collections.Generic;
using RestSharp;
using SeleniumTest.BusinessObjects;
using SeleniumTest.Common.Exceptions;

namespace BimTrackTA.API
{

    public class ProjectAttributeApi : ApiBase
    {
        public List<ProjectAttribute> GetHubProjectAttributeList(int hubId, int projectId)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/attributes";
            return Perform_Get<List<ProjectAttribute>>(connStr);
        }

        public int CreateHubProjectAttribute(int hubId, int projectId, ProjectAttribute prjAttr)
        {
            ValidateOperation(prjAttr);
            // Required fields for ProjectAttribute object are: 
            //     - Name (string)
            //     - Type ('predifined' or 'custom')
            //
            // CTRL+Click on ProjectAttribute for further details about the object's attributes
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/attributes";

            return Perform_Create(connStr, prjAttr);
        }

        public ProjectAttribute GetHubProjectAttributeDetail(int hubId, int projectId, int attributeId)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/attributes/" + attributeId;
            return Perform_Get<ProjectAttribute>(connStr);
        }

        public bool DeleteHubProjectAttribute(int hubId, int projectId, int attributeId)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/attributes/" + attributeId;
            IRestResponse response = Perform_Delete(connStr);
            return response.IsSuccessful;
        }

        public bool UpdateHubProjectAttribute(int hubId, int projectId, int attributeId, ProjectAttribute prjAttr)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/attributes/" + attributeId;
            IRestResponse response = Perform_Update(connStr, prjAttr);
            return response.IsSuccessful;
        }
        
        private void ValidateOperation(ProjectAttribute prjAttr)
        {
            if (prjAttr == null) throw new ArgumentNullException(nameof(prjAttr));
            if (prjAttr.Name == null)
            {
                throw new CustomObjectAttributeException("a name", "project attribute");
            }

            if (prjAttr.Type == null)
            {
                throw new CustomObjectAttributeException("a type", "project attribute ('predefined' or 'custom')");
            }

            if (prjAttr.Type.ToLower() != "predefined" && prjAttr.Type.ToLower() != "custom")
            {
                throw new CustomObjectAttributeException(
                    "The project attribute type needs to be 'predefined' or 'custom'.");
            }
        }
    }
}