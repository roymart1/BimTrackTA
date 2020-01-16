using System;
using System.Collections.Generic;
using BimTrackTA.API;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;
using SeleniumTest.Common;
using SeleniumTest.Common.Exceptions;

namespace BimTrackTA.Common.WebDriver
{
    public class GeneralTestBase
    {
        public GeneralTestBase()
        {
            CTX.SetKeyChainId();
        }
        
        protected int __GetHubRandom(string hubName = null, bool needToFind = false)
        {
            HubApi hubApiApi = new HubApi();
            List<Hub> listHub = hubApiApi.GetHubList();

            if (listHub.Count > 0)
            {
                if (hubName != null)
                {
                    foreach (var hub in listHub)
                    {
                        if (hub.Name.ToLower() == hubName.ToLower())
                        {
                            return hub.Id;
                        }
                    }
                    if (needToFind)
                    {
                        Assert.True(true, "The specified hub was not found.");
                    }
                    Console.Write("The specified hub was not found.");
                }
                // if none found the first one will be
                return listHub[0].Id;
            }
            throw new Exception("No hub found.");
        }

        protected int __GetProjectRandom(int hubId, string projectName = null, bool needToFind = false)
        {
            // Go on with the retrieval of the project list 
            ProjectApi projectApi = new ProjectApi();
            List<Project> listProject =  projectApi.GetHubProjectList(hubId);

            if (listProject.Count > 0)
            {
                if (projectName != null)
                {
                    foreach (var project in listProject)
                    {
                        if (project.Name.ToLower() == projectName.ToLower())
                        {
                            return project.Id;
                        }
                    }
                    if (needToFind)
                    {
                        Assert.True(true, "The specified project was not found.");
                    }
                    Console.Write("The specified project was not found.");
                }
                // if none found the first one will be
                return listProject[0].Id;
            }
            throw new Exception("No project for that hub.");
        }

        protected int __GetTeamRandom(int hubId, int projectId, string teamName=null, bool needToFind = false)
        {
            ProjectTeamApi projectApi = new ProjectTeamApi();
            List<Team> listTeam = projectApi.GetHubProjectTeams(hubId, projectId);
            
            if (listTeam.Count > 0)
            {
                if (teamName != null)
                {
                    foreach (var team in listTeam)
                    {
                        if (team.Name.ToLower() == teamName.ToLower())
                        {
                            return team.Id;
                        }
                    }
                    if (needToFind)
                    {
                        Assert.True(true, "The specified project team was not found.");
                    }
                    Console.Write("The specified project team was not found.");
                }            
            
                return listTeam[0].Id;
            }
            throw new Exception("No team for that project.");
        }
        
        protected int __GetUserRandom(int hubId, int projectId, string userEmail=null, bool needToFind = false)
        {
            ProjectUserApi projectApi = new ProjectUserApi();
            List<ProjectUser> listUsers = projectApi.GetHubProjectUsers(hubId, projectId);

            if (listUsers.Count > 0)
            {
                if (userEmail != null)
                {
                    foreach (var user in listUsers)
                    {
                        if (user.user.Email.ToLower() == userEmail.ToLower())
                        {
                            return user.user.Id;
                        }
                    }
                    if (needToFind)
                    {
                        Assert.True(true, "The specified user was not found.");
                    }
                    Console.Write("The specified user was not found.");
                }            
            
                return listUsers[0].user.Id;
            }
            throw new Exception("No user for that project.");
        }   
       
        protected int __GetHubUserRandom(int hubId, string userEmail=null, bool needToFind = false)
        {
            HubUserApi hubUserApi = new HubUserApi();
            List<HubUser> listUsers = hubUserApi.GetHubUsers(hubId);
            if (listUsers.Count > 0)
            {
                if (userEmail != null)
                {
                    foreach (var user in listUsers)
                    {
                        if (user.User.Email.ToLower() == userEmail.ToLower())
                        {
                            return user.User.Id;
                        }
                    }
                    if (needToFind)
                    {
                        Assert.True(true, "The specified hub user was not found.");
                    }
                    Console.Write("The specified hub user was not found.");
                }
                return listUsers[0].User.Id;
            }
            throw new Exception("No user for that hub.");
        }

        protected int __GetHubProjectTemplateRandom(int hubId, string tmplName=null, bool needToFind = false)
        {
            ProjectTemplateApi projectTemplateApi = new ProjectTemplateApi();
            List<ProjectTemplate> listPrjTemplates = projectTemplateApi.GetHubProjectTemplates(hubId);

            if (listPrjTemplates.Count > 0)
            {
                if (tmplName != null)
                {
                    foreach (var tmpl in listPrjTemplates)
                    {
                        if (tmpl.Name.ToLower() == tmplName.ToLower())
                        {
                            return tmpl.Id;
                        }
                    }
                    if (needToFind)
                    {
                        Assert.True(true, "The specified project template was not found.");
                    }
                    Console.Write("The specified project template was not found.");
                }
                return listPrjTemplates[0].Id;
            }
            throw new Exception("No project template for that hub.");
        }   

        protected int __GetHubProjectAttributeRandom(int hubId, int projectId, string attrName=null, bool needToFind = false)
        {
            ProjectAttributeApi projectAttributeApi = new ProjectAttributeApi();

            List<ProjectAttribute> listPrjAttributes = projectAttributeApi.GetHubProjectAttributeList(hubId, projectId);

            if (listPrjAttributes.Count > 0)
            {
                if (attrName != null)
                {
                    foreach (var tmpl in listPrjAttributes)
                    {
                        if (tmpl.Name.ToLower() == attrName.ToLower())
                        {
                            return tmpl.Id;
                        }
                    }
                    if (needToFind)
                    {
                        Assert.True(true, "The specified project attribute was not found.");
                    }
                    Console.Write("The specified project attribute was not found.");
                }
                return listPrjAttributes[0].Id;
            }
            throw new Exception("No attribute for that project.");
        }   
        
        protected int __GetHubProjectAttributeValueRandom(int hubId, int projectId, int attrId, string attrName=null, bool needToFind = false)
        {
            ProjectAttributeApi projectAttributeApi = new ProjectAttributeApi();

            ProjectAttribute prjAttribute = 
                projectAttributeApi.GetHubProjectAttributeDetail(hubId, projectId, attrId);
            
            if (prjAttribute != null)
            {
                if (attrName != null)
                {
                    foreach (var attrVal in prjAttribute.ProjectCustomAttributeValues)
                    {
                        if (attrVal.Name.ToLower() == attrName.ToLower())
                        {
                            return attrVal.Id;
                        }
                    }
                    if (needToFind)
                    {
                        Assert.True(true, "The specified project attribute value was not found.");
                    }
                    Console.Write("The specified project attribute value was not found.");
                }
                return prjAttribute.ProjectCustomAttributeValues[0].Id;
            }
            throw new Exception("Attribute value not found.");
        }

        protected int __GetProjectModelRandom(int hubId, int projectId, string modelName=null, bool needToFind = false)
        {
            // IMPORTANT: The model name is the name of the file that has been sent, not the name of the model object.
            ProjectModelApi projectModelApi = new ProjectModelApi();
            List<Model> listModels = projectModelApi.GetProjectModelList(hubId, projectId);
            if (listModels.Count > 0)
            {
                if (modelName != null)
                {
                    foreach (var model in listModels)
                    {
                        if (model.Name.ToLower() == modelName.ToLower())
                        {
                            return model.Id;
                        }
                    }
                    if (needToFind)
                    {
                        Assert.True(true, "The specified project model was not found.");
                    }
                    Console.Write("The specified project model was not found.");
                }
                return listModels[0].Id;
            }
            throw new Exception("There is no model in that project.");
        }
        
        protected int __GetProjectModelFolderRandom(int hubId, int projectId, string modelFolderName=null, bool needToFind = false)
        {
            ProjectModelFolderApi projectModelFolderApi = new ProjectModelFolderApi();
            List<Folder> listFolders = projectModelFolderApi.GetProjectModelFolderList(hubId, projectId);
            if (listFolders.Count > 0)
            {
                if (modelFolderName != null)
                {
                    foreach (var folder in listFolders)
                    {
                        if (folder.Name.ToLower() == modelFolderName.ToLower())
                        {
                            return folder.Id;
                        }
                    }
                    if (needToFind)
                    {
                        Assert.True(true, "The specified model folder was not found.");
                    }
                    Console.Write("The specified model folder was not found.");
                }
                return listFolders[0].Id;
            }
            throw new Exception("There is no model folder in that project.");
        }
        
        protected int __GetProjectModelRevisionRandom(int hubId, int projectId, int modelId, string fileName=null, bool needToFind = false)
        {
            ProjectModelRevisionApi projectModelRevisionApi = new ProjectModelRevisionApi();
            List<Revision> listRevisions = projectModelRevisionApi
                .GetProjectModelRevisionList(hubId, projectId, modelId);
            if (listRevisions.Count > 0)
            {
                if (fileName != null)
                {
                    foreach (var revision in listRevisions)
                    {
                        if (revision.FileInfo != null)
                        {
                            if (revision.FileInfo.Name.ToLower() == fileName.ToLower())
                            {
                                return revision.Id;
                            }
                        }
                    }
                    if (needToFind)
                    {
                        Assert.True(true, "The specified model revision was not found.");
                    }
                    Console.Write("The specified model revision was not found.");
                }
                return listRevisions[0].Id;
            }
            throw new Exception("There is no revision for that model.");
        }
        
        protected int __GetProjectSheetRandom(int hubId, int projectId, string sheetName=null, bool needToFind = false)
        {
            ProjectSheetApi projectSheetApi = new ProjectSheetApi();
            List<Sheet> listSheets = projectSheetApi.GetProjectSheetList(hubId, projectId);
            if (listSheets.Count > 0)
            {
                if (sheetName != null)
                {
                    foreach (var sheet in listSheets)
                    {
                        if (sheet.Name.ToLower() == sheetName.ToLower())
                        {
                            return sheet.Id;
                        }
                    } 
                    if (needToFind)
                    {
                        Assert.True(true, "The specified project sheet was not found.");
                    }
                    Console.Write("The specified project sheet was not found.");
                }
                return listSheets[0].Id;
            }
            throw new Exception("There is no sheet in that project.");
        }
        
        protected int __GetProjectSheetFolderRandom(int hubId, int projectId, string sheetFolderName=null, bool needToFind = false)
        {
            ProjectSheetFolderApi projectSheetFolderApi = new ProjectSheetFolderApi();
            List<Folder> listFolders = projectSheetFolderApi.GetProjectSheetFolderList(hubId, projectId);
            
            if (listFolders.Count > 0)
            {
                if (sheetFolderName != null)
                {
                    foreach (var folder in listFolders)
                    {
                        if (folder.Name.ToLower() == sheetFolderName.ToLower())
                        {
                            return folder.Id;
                        }
                    }
                    if (needToFind)
                    {
                        Assert.True(true, "The specified sheet folder was not found.");
                    }
                    Console.Write("The specified sheet folder was not found.");
                }
                return listFolders[0].Id;
            }
            throw new Exception("There is no sheet folder in that project.");
        }
        
        protected int __GetProjectSheetRevisionRandom(int hubId, int projectId, int sheetId, string fileName=null, bool needToFind = false)
        {
            ProjectSheetRevisionApi projectSheetRevisionApi = new ProjectSheetRevisionApi();
            List<Revision> listRevisions = projectSheetRevisionApi
                .GetProjectSheetRevisionList(hubId, projectId, sheetId);
            if (listRevisions.Count > 0)
            {
                if (fileName != null)
                {
                    foreach (var revision in listRevisions)
                    {
                        if (revision.FileInfo != null)
                        {
                            if (revision.FileInfo.Name.ToLower() == fileName.ToLower())
                            {
                                return revision.Id;
                            }
                        }
                    }
                    if (needToFind)
                    {
                        Assert.True(true, "The specified sheet revision was not found.");
                    }
                    Console.Write("The specified sheet revision was not found.");
                }
                return listRevisions[0].Id;
            }
            throw new Exception("There is no revision for that sheet.");
        }
        
        protected int __GetProjectSheetRevisionInstanceRandom(int hubId, int projectId, int sheetId, int revisionId, string viewName=null, bool needToFind = false)
        {
            ProjectSheetRevisionInstanceApi projectSheetRevisionInstanceApi = new ProjectSheetRevisionInstanceApi();
            List<Instance> listInstance = projectSheetRevisionInstanceApi
                .GetProjectSheetRevisionInstanceList(hubId, projectId, sheetId, revisionId);
            if (listInstance.Count > 0)
            {
                if (viewName != null)
                {
                    foreach (var instance in listInstance)
                    {
                        if (instance?.ViewName != null)
                        {
                            return instance.Id;
                        }
                    }
                    if (needToFind)
                    {
                        Assert.True(true, "The specified sheet revision instance was not found.");
                    }
                    Console.Write("The specified sheet revision instance was not found.");
                }
                return listInstance[0].Id;
            }
            throw new Exception("There is no instance for that revision.");
        }
        
        protected int __GetIssueRandom(int hubId, int projectId, string issueTitle=null, bool needToFind = false)
        {
            IssueApi issueApi = new IssueApi();

            List<Issue> listIssues = issueApi.GetIssueList(hubId, projectId);

            if (listIssues.Count > 0)
            {
                if (issueTitle != null)
                {
                    foreach (var issue in listIssues)
                    {
                        if (issue.Title.ToLower() == issueTitle.ToLower())
                        {
                            return issue.Id;
                        }
                    }
                    if (needToFind)
                    {
                        Assert.True(true, "The specified issue was not found.");
                    }
                    Console.Write("The specified issue was not found.");
                }
                return listIssues[0].Id;
            }
            throw new Exception("No issue for that project.");
        }   
        
        protected int __GetArchivedIssueRandom(int hubId, int projectId, string issueTitle=null, bool needToFind = false)
        {
            IssueArchivedApi issueArchivedApi = new IssueArchivedApi();

            List<Issue> listArchivedIssues = issueArchivedApi.GetIssueArchivedList(hubId, projectId);

            if (listArchivedIssues.Count > 0)
            {
                if (issueTitle != null)
                {
                    foreach (var archivedIssue in listArchivedIssues)
                    {
                        if (archivedIssue.Title.ToLower() == issueTitle.ToLower())
                        {
                            return archivedIssue.Id;
                        }
                    }
                    if (needToFind)
                    {
                        Assert.True(true, "The specified archived issue was not found.");
                    }
                    Console.Write("The specified archived issue was not found.");
                }
                return listArchivedIssues[0].Id;
            }
            throw new Exception("No archived issue for that project.");
        }
        
        protected int __GetIssueAttachmentRandom(int hubId, int projectId, int issueId, string attachmentName=null, bool needToFind = false)
        {
            IssueAttachmentApi issueAttachmentApi = new IssueAttachmentApi();

            List<Issue.Attachment> listIssueAttachments = issueAttachmentApi
                .GetIssueAttachmentList(hubId, projectId, issueId);

            if (listIssueAttachments.Count > 0)
            {
                if (attachmentName != null)
                {
                    foreach (var attachment in listIssueAttachments)
                    {
                        if (attachment.Name.ToLower() == attachmentName.ToLower())
                        {
                            return attachment.Id;
                        }
                    }
                    if (needToFind)
                    {
                        Assert.True(true, "The specified issue attachment was not found.");
                    }
                    Console.Write("The specified issue attachment was not found.");
                }
                return listIssueAttachments[0].Id;
            }
            throw new Exception("No attachment for that issue.");
        }  
        
        protected int __GetIssueCommentRandom(int hubId, int projectId, int issueId, string commentValue=null, bool needToFind = false)
        {
            IssueCommentApi issueCommentApi = new IssueCommentApi();
            List<BimComment> listIssueComments = issueCommentApi
                .GetIssueCommentList(hubId, projectId, issueId);

            if (listIssueComments.Count > 0)
            {
                if (commentValue != null)
                {
                    foreach (var comment in listIssueComments)
                    {
                        if (comment.Comment.ToLower() == commentValue.ToLower())
                        {
                            return comment.Id;
                        }
                    }
                    if (needToFind)
                    {
                        Assert.True(true, "The specified issue comment was not found.");
                    }
                    Console.Write("The specified issue comment was not found.");
                }
                return listIssueComments[0].Id;
            }
            throw new Exception("No comment for that issue.");
        } 
        
        protected int __GetIssueViewPointRandom(int hubId, int projectId, int issueId, string viewName=null, bool needToFind = false)
        {
            IssueViewPointApi issueViewPointApi = new IssueViewPointApi();

            List<ViewPoint> listIssueViewPoints = issueViewPointApi
                .GetIssueViewPointList(hubId, projectId, issueId);

            if (listIssueViewPoints.Count > 0)
            {
                if (viewName != null)
                {
                    foreach (ViewPoint viewPoint in listIssueViewPoints)
                    {
                        if (viewPoint.ViewName != null && viewPoint.ViewName.ToLower() == viewName)
                        {
                            return viewPoint.Id;
                        }
                    }
                    if (needToFind)
                    {
                        Assert.True(true, "The specified issue viewpoint was not found.");
                    }
                    Console.Write("The specified issue viewpoint was not found.");
                }
                return listIssueViewPoints[0].Id;
            }
            throw new Exception("No view point for that issue.");
        } 
        
        protected int __GetIssueViewPointCommentRandom(int hubId, int projectId, int issueId, int viewPointId, string commentValue=null, bool needToFind = false)
        {
            IssueViewPointCommentApi issueViewPointCommentApi = new IssueViewPointCommentApi();
            List<BimComment> listIssueViewPointComments = issueViewPointCommentApi
                .GetIssueViewPointCommentList(hubId, projectId, issueId, viewPointId);

            if (listIssueViewPointComments.Count > 0)
            {
                if (commentValue != null)
                {
                    foreach (var comment in listIssueViewPointComments)
                    {
                        if (comment.Comment.ToLower() == commentValue.ToLower())
                        {
                            return comment.Id;
                        }
                    }
                    if (needToFind)
                    {
                        Assert.True(true, "The specified viewpoint comment was not found.");
                    }
                    Console.Write("The specified viewpoint comment was not found.");
                }
                return listIssueViewPointComments[0].Id;
            }
            throw new Exception("No comment for that viewpoint.");
        } 
        
        protected int __GetProjectDisciplineRandom(int hubId, int projectId, string name=null, bool needToFind = false)
        {
            ProjectDisciplineApi projectDisciplineApi = new ProjectDisciplineApi();

            List<Discipline> listProjectDisciplines = projectDisciplineApi
                .GetProjectDisciplines(hubId, projectId);

            if (listProjectDisciplines.Count > 0)
            {
                if (name != null)
                {
                    foreach (var discipline in listProjectDisciplines)
                    {
                        if (discipline.Name.ToLower() == name.ToLower())
                        {
                            return discipline.Id;
                        }
                    }
                    if (needToFind)
                    {
                        Assert.True(true, "The specified project discipline was not found.");
                    }
                    Console.Write("The specified project discipline was not found.");
                }
                return listProjectDisciplines[0].Id;
            }
            throw new Exception("No discipline for that project.");
        } 
        
        protected int __GetProjectPhaseRandom(int hubId, int projectId, string name=null, bool needToFind = false)
        {
            ProjectPhaseApi projectPhaseApi = new ProjectPhaseApi();

            List<Phase> listProjectPhases = projectPhaseApi
                .GetProjectPhases(hubId, projectId);

            if (listProjectPhases.Count > 0)
            {
                if (name != null)
                {
                    foreach (var phase in listProjectPhases)
                    {
                        if (phase.Name.ToLower() == name.ToLower())
                        {
                            return phase.Id;
                        }
                    }
                    if (needToFind)
                    {
                        Assert.True(true, "The specified project phase was not found.");
                    }
                    Console.Write("The specified project phase was not found.");
                }
                return listProjectPhases[0].Id;
            }
            throw new Exception("No phase for that project.");
        } 
        
        protected int __GetProjectPriorityRandom(int hubId, int projectId, string name=null, bool needToFind = false)
        {
            ProjectPriorityApi projectPriorityApi = new ProjectPriorityApi();

            List<Priority> listProjectPriorities = projectPriorityApi
                .GetProjectPriorities(hubId, projectId);

            if (listProjectPriorities.Count > 0)
            {
                if (name != null)
                {
                    foreach (var priority in listProjectPriorities)
                    {
                        if (priority.Name.ToLower() == name.ToLower())
                        {
                            return priority.Id;
                        }
                    }
                    if (needToFind)
                    {
                        Assert.True(true, "The specified project priority was not found.");
                    }
                    Console.Write("The specified project priority was not found.");
                }
                return listProjectPriorities[0].Id;
            }
            throw new Exception("No priority for that project.");
        } 
        
        protected int __GetProjectStatusRandom(int hubId, int projectId, string name=null, bool needToFind = false)
        {
            ProjectStatusApi projectStatusApi = new ProjectStatusApi();

            List<Status> listProjectStatuses = projectStatusApi
                .GetProjectStatuses(hubId, projectId);

            if (listProjectStatuses.Count > 0)
            {
                if (name != null)
                {
                    foreach (var status in listProjectStatuses)
                    {
                        if (status.Name.ToLower() == name.ToLower())
                        {
                            return status.Id;
                        }
                    }
                    if (needToFind)
                    {
                        Assert.True(true, "The specified project status was not found.");
                    }
                    Console.Write("The specified project status was not found.");
                }
                return listProjectStatuses[0].Id;
            }
           throw new Exception("No status for that project.");
        } 
        
        protected int __GetProjectTypeRandom(int hubId, int projectId, string name=null, bool needToFind = false)
        {
            ProjectTypeApi projectTypeApi = new ProjectTypeApi();

            List<BimType> listProjectTypes = projectTypeApi
                .GetProjectTypes(hubId, projectId);

            if (listProjectTypes.Count > 0)
            {
                if (name != null)
                {
                    foreach (var type in listProjectTypes)
                    {
                        if (type.Name.ToLower() == name.ToLower())
                        {
                            return type.Id;
                        }
                    }
                    if (needToFind)
                    {
                        Assert.True(true, "The specified project type was not found.");
                    }
                    Console.Write("The specified project type was not found.");
                }
                return listProjectTypes[0].Id;
            }
            throw new Exception("No type in that project.");
        } 
        
        protected int __GetProjectZoneRandom(int hubId, int projectId, string name=null, bool needToFind = false)
        {
            ProjectZoneApi projectZoneApi = new ProjectZoneApi();

            List<Zone> listProjectZones = projectZoneApi
                .GetProjectZones(hubId, projectId);

            if (listProjectZones.Count > 0)
            {
                if (name != null)
                {
                    foreach (var zone in listProjectZones)
                    {
                        if (zone.Name.ToLower() == name.ToLower())
                        {
                            return zone.Id;
                        }
                    }
                    if (needToFind)
                    {
                        Assert.True(true, "The specified project zone was not found.");
                    }
                    Console.Write("The specified project zone was not found.");
                }
                return listProjectZones[0].Id;
            }
            throw new Exception("No zone in that project.");
        } 
    }
}