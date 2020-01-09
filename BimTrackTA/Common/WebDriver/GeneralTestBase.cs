using System;
using System.Collections.Generic;
using BimTrackTA.API;
using SeleniumTest.BusinessObjects;
using SeleniumTest.Common;

namespace BimTrackTA.Common.WebDriver
{
    public class GeneralTestBase
    {
        public GeneralTestBase()
        {
            CTX.SetKeyChainId();
        }
        
        protected int __GetHubRandom(string hubName = null)
        {
            HubApi hubApiApi = new HubApi();
            List<Hub> listHub = hubApiApi.GetHubList();
            if (hubName != null)
            {
                foreach (var hub in listHub)
                {
                    if (hub.Name.ToLower() == hubName.ToLower())
                    {
                        return hub.Id;
                    }
                }
            }
            // if none found the first one will be
            return listHub[0].Id;
        }

        protected int __GetProjectRandom(int hubId, string projectName = null)
        {
            // Go on with the retrieval of the project list 
            ProjectApi projectApi = new ProjectApi();
            List<Project> listProject =  projectApi.GetHubProjectList(hubId);
            if (projectName != null)
            {
                foreach (var project in listProject)
                {
                    if (project.Name.ToLower() == projectName.ToLower())
                    {
                        return project.Id;
                    }
                }
            }
            // if none found the first one will be
            return listProject[0].Id;
        }

        protected int __GetTeamRandom(int hubId, int projectId, string teamName=null)
        {
            ProjectTeamApi projectApi = new ProjectTeamApi();
            List<Team> listTeam = projectApi.GetHubProjectTeams(hubId, projectId);
            if (teamName != null)
            {
                foreach (var team in listTeam)
                {
                    if (team.Name.ToLower() == teamName.ToLower())
                    {
                        return team.Id;
                    }
                }
            }            
            
            return listTeam[0].Id;
        }
        
        protected int __GetUserRandom(int hubId, int projectId, string userEmail=null)
        {
            ProjectUserApi projectApi = new ProjectUserApi();
            List<User> listUsers = projectApi.GetHubProjectUsers(hubId, projectId);
            if (userEmail != null)
            {
                foreach (var user in listUsers)
                {
                    if (user.Email.ToLower() == userEmail.ToLower())
                    {
                        return user.Id;
                    }
                }
            }            
            
            return listUsers[0].Id;
        }   
       
        protected int __GetHubUserRandom(int hubId, string userEmail=null)
        {
            HubUserApi hubUserApi = new HubUserApi();
            List<HubUser> listUsers = hubUserApi.GetHubUsers(hubId);
            if (userEmail != null)
            {
                foreach (var user in listUsers)
                {
                    if (user.User.Email.ToLower() == userEmail.ToLower())
                    {
                        return user.User.Id;
                    }
                }
            }
            return listUsers[0].User.Id;
        }   

               
        protected int __GetHubProjectTemplateRandom(int hubId, int projectId, string tmplName=null)
        {
            ProjectTemplateApi projectTemplateApi = new ProjectTemplateApi();
            List<ProjectTemplate> listPrjTemplates = projectTemplateApi.GetHubProjectTemplates(hubId);
            
            if (tmplName != null)
            {
                foreach (var tmpl in listPrjTemplates)
                {
                    if (tmpl.Name.ToLower() == tmplName.ToLower())
                    {
                        return tmpl.Id;
                    }
                }
            }
            return listPrjTemplates[0].Id;
        }   

        protected int __GetHubProjectAttributeRandom(int hubId, int projectId, string attrName=null)
        {
            ProjectAttributeApi projectAttributeApi = new ProjectAttributeApi();

            List<ProjectAttribute> listPrjAttributes = projectAttributeApi.GetHubProjectAttributeList(hubId, projectId);
            
            if (attrName != null)
            {
                foreach (var tmpl in listPrjAttributes)
                {
                    if (tmpl.Name.ToLower() == attrName.ToLower())
                    {
                        return tmpl.Id;
                    }
                }
            }
            return listPrjAttributes[0].Id;
        }   
        
        protected int __GetHubProjectAttributeValueRandom(int hubId, int projectId, int attrId, string attrName)
        {
            ProjectAttributeApi projectAttributeApi = new ProjectAttributeApi();

            ProjectAttribute prjAttribute = 
                projectAttributeApi.GetHubProjectAttributeDetail(hubId, projectId, attrId);
            
            if (attrName != null)
            {
                foreach (var attrVal in prjAttribute.ProjectCustomAttributeValues)
                {
                    if (attrVal.Name.ToLower() == attrName.ToLower())
                    {
                        return attrVal.Id;
                    }
                }
            }
            return prjAttribute.ProjectCustomAttributeValues[0].Id;
        }

        protected int __GetProjectModelRandom(int hubId, int projectId)
        {
            ProjectModelApi projectModelApi = new ProjectModelApi();
            List<Model> listModels = projectModelApi.GetProjectModelList(hubId, projectId);
            if (listModels.Count > 0)
            {
                return listModels[0].Id;
            }
            throw new Exception("There is no model in that project.");
        }
        
        protected int __GetProjectModelFolderRandom(int hubId, int projectId)
        {
            ProjectModelFolderApi projectModelFolderApi = new ProjectModelFolderApi();
            List<Folder> listFolders = projectModelFolderApi.GetProjectModelFolderList(hubId, projectId);
            if (listFolders.Count > 0)
            {
                return listFolders[0].Id;
            }
            throw new Exception("There is no model folder in that project.");
        }
        
        protected int __GetProjectModelRevisionRandom(int hubId, int projectId, int modelId)
        {
            ProjectModelRevisionApi projectModelRevisionApi = new ProjectModelRevisionApi();
            List<Revision> listRevisions = projectModelRevisionApi
                .GetProjectModelRevisionList(hubId, projectId, modelId);
            if (listRevisions.Count > 0)
            {
                return listRevisions[0].Id;
            }
            throw new Exception("There is no revision for that model.");
        }
        
        protected int __GetProjectSheetRandom(int hubId, int projectId)
        {
            ProjectSheetApi projectSheetApi = new ProjectSheetApi();
            List<Sheet> listSheets = projectSheetApi.GetProjectSheetList(hubId, projectId);
            if (listSheets.Count > 0)
            {
                return listSheets[0].Id;
            }
            throw new Exception("There is no sheet in that project.");
        }
        
        protected int __GetProjectSheetFolderRandom(int hubId, int projectId)
        {
            ProjectSheetFolderApi projectSheetFolderApi = new ProjectSheetFolderApi();
            List<Folder> listFolders = projectSheetFolderApi.GetProjectSheetFolderList(hubId, projectId);
            if (listFolders.Count > 0)
            {
                return listFolders[0].Id;
            }
            throw new Exception("There is no sheet folder in that project.");
        }
        
        protected int __GetProjectSheetRevisionRandom(int hubId, int projectId, int sheetId)
        {
            ProjectSheetRevisionApi projectSheetRevisionApi = new ProjectSheetRevisionApi();
            List<Revision> listRevisions = projectSheetRevisionApi
                .GetProjectSheetRevisionList(hubId, projectId, sheetId);
            if (listRevisions.Count > 0)
            {
                return listRevisions[0].Id;
            }
            throw new Exception("There is no revision for that sheet.");
        }
        
        protected int __GetProjectSheetRevisionInstanceRandom(int hubId, int projectId, int sheetId, int revisionId)
        {
            ProjectSheetRevisionInstanceApi projectSheetRevisionInstanceApi = new ProjectSheetRevisionInstanceApi();
            List<Instance> listInstance = projectSheetRevisionInstanceApi
                .GetProjectSheetRevisionInstanceList(hubId, projectId, sheetId, revisionId);
            if (listInstance.Count > 0)
            {
                return listInstance[0].Id;
            }
            throw new Exception("There is no instance for that revision.");
        }
        
        protected int __GetIssueRandom(int hubId, int projectId, string issueTitle=null)
        {
            IssueApi issueApi = new IssueApi();

            List<Issue> listIssues = issueApi.GetIssueList(hubId, projectId);
            
            if (issueTitle != null)
            {
                foreach (var issue in listIssues)
                {
                    if (issue.Title.ToLower() == issueTitle.ToLower())
                    {
                        return issue.Id;
                    }
                }
            }
            return listIssues[0].Id;
        }   
        
        protected int __GetArchivedIssueRandom(int hubId, int projectId, string issueTitle=null)
        {
            IssueArchivedApi issueArchivedApi = new IssueArchivedApi();

            List<Issue> listArchivedIssues = issueArchivedApi.GetIssueArchivedList(hubId, projectId);
            
            if (issueTitle != null)
            {
                foreach (var archivedIssue in listArchivedIssues)
                {
                    if (archivedIssue.Title.ToLower() == issueTitle.ToLower())
                    {
                        return archivedIssue.Id;
                    }
                }
            }
            return listArchivedIssues[0].Id;
        }
        
        protected int __GetIssueAttachmentRandom(int hubId, int projectId, int issueId, string attachmentName=null)
        {
            IssueAttachmentApi issueAttachmentApi = new IssueAttachmentApi();

            List<Issue.Attachment> listIssueAttachments = issueAttachmentApi
                .GetIssueAttachmentList(hubId, projectId, issueId);
            
            if (attachmentName != null)
            {
                foreach (var issue in listIssueAttachments)
                {
                    if (issue.Name.ToLower() == attachmentName.ToLower())
                    {
                        return issue.Id;
                    }
                }
            }
            return listIssueAttachments[0].Id;
        }  
        
        protected int __GetIssueCommentRandom(int hubId, int projectId, int issueId, string commentValue=null)
        {
            IssueCommentApi issueCommentApi = new IssueCommentApi();
            List<BimComment> listIssueComments = issueCommentApi
                .GetIssueCommentList(hubId, projectId, issueId);
            if (commentValue != null)
            {
                foreach (var comment in listIssueComments)
                {
                    if (comment.Comment.ToLower() == commentValue.ToLower())
                    {
                        return comment.Id;
                    }
                }
            }
            return listIssueComments[0].Id;
        } 
        
        protected int __GetIssueViewPointRandom(int hubId, int projectId, int issueId, string viewName=null)
        {
            IssueViewPointApi issueViewPointApi = new IssueViewPointApi();

            List<ViewPoint> listIssueViewPoints = issueViewPointApi
                .GetIssueViewPointList(hubId, projectId, issueId);
            
            if (viewName != null)
            {
                foreach (var viewPoint in listIssueViewPoints)
                {
                    if (viewPoint.ViewName.ToLower() == viewName.ToLower())
                    {
                        return viewPoint.Id;
                    }
                }
            }
            return listIssueViewPoints[0].Id;
        } 
        
        protected int __GetIssueViewPointCommentRandom(int hubId, int projectId, int issueId, int viewPointId)
        {
            IssueViewPointCommentApi issueViewPointCommentApi = new IssueViewPointCommentApi();
            List<BimComment> listIssueViewPointComments = issueViewPointCommentApi
                .GetIssueViewPointCommentList(hubId, projectId, issueId, viewPointId);
            return listIssueViewPointComments[0].Id;
        } 
        
        protected int __GetProjectDisciplineRandom(int hubId, int projectId, string name=null)
        {
            ProjectDisciplineApi projectDisciplineApi = new ProjectDisciplineApi();

            List<Discipline> listProjectDisciplines = projectDisciplineApi
                .GetHubProjectDisciplineList(hubId, projectId);
            
            if (name != null)
            {
                foreach (var discipline in listProjectDisciplines)
                {
                    if (discipline.Name.ToLower() == name.ToLower())
                    {
                        return discipline.Id;
                    }
                }
            }
            return listProjectDisciplines[0].Id;
        } 
        
        protected int __GetProjectPhaseRandom(int hubId, int projectId, string name=null)
        {
            ProjectPhaseApi projectPhaseApi = new ProjectPhaseApi();

            List<Phase> listProjectPhases = projectPhaseApi
                .GetHubProjectPhaseList(hubId, projectId);
            
            if (name != null)
            {
                foreach (var phase in listProjectPhases)
                {
                    if (phase.Name.ToLower() == name.ToLower())
                    {
                        return phase.Id;
                    }
                }
            }
            return listProjectPhases[0].Id;
        } 
        
        protected int __GetProjectPriorityRandom(int hubId, int projectId, string name=null)
        {
            ProjectPriorityApi projectPriorityApi = new ProjectPriorityApi();

            List<Priority> listProjectPriorities = projectPriorityApi
                .GetHubProjectPriorityList(hubId, projectId);
            
            if (name != null)
            {
                foreach (var priority in listProjectPriorities)
                {
                    if (priority.Name.ToLower() == name.ToLower())
                    {
                        return priority.Id;
                    }
                }
            }
            return listProjectPriorities[0].Id;
        } 
        
        protected int __GetProjectStatusRandom(int hubId, int projectId, string name=null)
        {
            ProjectStatusApi projectStatusApi = new ProjectStatusApi();

            List<Status> listProjectStatuses = projectStatusApi
                .GetHubProjectStatusList(hubId, projectId);
            
            if (name != null)
            {
                foreach (var status in listProjectStatuses)
                {
                    if (status.Name.ToLower() == name.ToLower())
                    {
                        return status.Id;
                    }
                }
            }
            return listProjectStatuses[0].Id;
        } 
        
        protected int __GetProjectTypeRandom(int hubId, int projectId, string name=null)
        {
            ProjectTypeApi projectTypeApi = new ProjectTypeApi();

            List<BimType> listProjectTypes = projectTypeApi
                .GetHubProjectTypeList(hubId, projectId);
            
            if (name != null)
            {
                foreach (var type in listProjectTypes)
                {
                    if (type.Name.ToLower() == name.ToLower())
                    {
                        return type.Id;
                    }
                }
            }
            return listProjectTypes[0].Id;
        } 
        
        protected int __GetProjectZoneRandom(int hubId, int projectId, string name=null)
        {
            ProjectZoneApi projectZoneApi = new ProjectZoneApi();

            List<Zone> listProjectZones = projectZoneApi
                .GetHubProjectZoneList(hubId, projectId);
            
            if (name != null)
            {
                foreach (var zone in listProjectZones)
                {
                    if (zone.Name.ToLower() == name.ToLower())
                    {
                        return zone.Id;
                    }
                }
            }
            return listProjectZones[0].Id;
        } 
    }
}