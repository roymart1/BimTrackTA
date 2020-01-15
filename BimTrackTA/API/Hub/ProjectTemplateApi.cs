using System;
using System.Collections.Generic;
using RestSharp;
using SeleniumTest.BusinessObjects;
using SeleniumTest.Common.Exceptions;

namespace BimTrackTA.API
{

    public class ProjectTemplateApi : ApiBase
    {
                
        public List<ProjectTemplate> GetHubProjectTemplates(int hubId)
        {
            string connStr = "v2/hubs/" + hubId + "/projecttemplates";
            return Perform_Get<List<ProjectTemplate>>(connStr);
        }


        public int CreateHubProjectTemplate(int hubId, ProjectTemplate template)
        {
            // Validate that the object is fine
            ValidateOperation(template);

            // Required fields for ProjectTemplate object are: 
            //     - Name (string)
            //     - SourceProjectId (int: the id of the source project from which we are creating the template)
            //
            // Since you need a project source, that means that you need to have created a project in that hub first.
            //
            // CTRL+Click on ProjectTemplate for further details about the object's attributes
            //
            // N.B. : If you receive the message 'the requested resource was not found', it's because your sourceProjectId
            //        is not valid, meaning that it doesn't come from an existing project in your hub.
            string connStr = "/v2/hubs/"+ hubId +"/projecttemplates";
            return Perform_Create(connStr, template);
        }
        
        public bool DeleteHubProjectTemplate(int hubId, int hubProjectTemplateId)
        {
            string connStr = "/v2/hubs/" + hubId + "/projecttemplates/" + hubProjectTemplateId;
            IRestResponse response = Perform_Delete(connStr);
            return response.IsSuccessful;
        }

        private void ValidateOperation(ProjectTemplate template)
        {
            if (template == null) throw new ArgumentNullException(nameof(template));
            if (template.Name == null)
            {
                throw new CustomObjectAttributeException("a name", "project template");
            }
        }
    }
}