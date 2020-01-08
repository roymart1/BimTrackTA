using System;
using System.Collections.Generic;

namespace SeleniumTest.BusinessObjects
{
    public class Project
    {
        public int Id { get; set; }
        public int TotalIssues { get; set; }
        
        public List<String> IssuesGroups { get; set; }
        public List<Discipline> Disciplines { get; set; }
        public List<Priority> Priorities { get; set; }
        public List<Status> Statuses { get; set; }
        public List<Type> Types { get; set; }
        public List<CustomAttribute> Phases { get; set; }
        public List<CustomAttribute> Zones { get; set; }
        public List<Team> Teams { get; set; }
        public List<User> Users { get; set; }

        public Settings ProjectSettings { get; set; }
        public Author Author { get; set; }
        public Image Image { get; set; }
        public DateTime CreationDate { get; set; }
        public string Name { get; set; }

        public class Settings
        {
            public int DefaultDueDateDays { get; set; }
            public int ClosedProjectIssueStatusId { get; set; }
            public int DefaultProjectPhaseId { get; set; }
            public int DefaultProjectZoneId { get; set; }
            public int DefaultProjectIssueLabelId { get; set; }
            public int DefaultProjectIssuePriorityId { get; set; }
            public int DefaultProjectIssueStatusId { get; set; }
            public int DefaultProjectIssueTypeId { get; set; }
            public string DefaultColorAttributeProperty { get; set; }
            public int DefaultColorCustomAttributeId { get; set; }
            public bool IssueMandatoryAttributesZone { get; set; }
            public bool IssueMandatoryAttributesPhase { get; set; }
            public bool IssueMandatoryAttributesAssignedTo { get; set; }
            public bool IssueMandatoryAttributesPriority { get; set; }
            public bool IssueMandatoryAttributesLabel { get; set; }
            public bool IssueMandatoryAttributesTeam { get; set; }
            public bool IssueMandatoryAttributesIssueGroup { get; set; }
            public bool IssueMandatoryAttributesDueDate { get; set; }
            public bool IssueMandatoryAttributesNotify { get; set; }
            public bool IssueMandatoryAttributesStatus { get; set; }
            public bool IssueMandatoryAttributesType { get; set; }
            public List<int> IssueMandatoryCustomAttributeId { get; set; }
            public List<DefaultAttributeValue> DefaultProjectCustomAttributes { get; set; }
        }
    }
}