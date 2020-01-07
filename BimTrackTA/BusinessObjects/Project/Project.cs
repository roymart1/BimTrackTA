using System;
using System.Collections.Generic;

namespace SeleniumTest.BusinessObjects
{
    public class Project
    {
        public int Id { get; set; }
        public Author Author { get; set; }
        public Image Image { get; set; }
        public DateTime CreationDate { get; set; }
        public string Name { get; set; }
        public List<Model> Models { get; set; }
        public List<Team> Teams { get; set; }
        public List<User> Users { get; set; }
        
        public class Model
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Size { get; set; }
            public DateTime Date { get; set; }
            public string Url { get; set; }
            public DateTime UrlExpiration { get; set; }
            
            public List<Folder> Folders { get; set; }
            public List<Revision> Revisions { get; set; }
        }
        
        public class Sheet
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string UniqueId { get; set; }
            
            public List<Folder> Folders { get; set; }
            public List<Revision> Revisions { get; set; }
        }
    }
}