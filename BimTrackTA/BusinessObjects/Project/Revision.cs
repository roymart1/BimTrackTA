using System;
using System.Collections.Generic;

namespace SeleniumTest.BusinessObjects
{
    public class Revision
    {       
        public List<Instance> Instances { get; set; }
        public int Id { get; set; }
        public FileInformation FileInfo { get; set; }
        public DateTime CreationDate { get; set; }
        public Author Author { get; set; }
        public int Number { get; set; }

        public class FileInformation
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Size { get; set; }
            public DateTime Date { get; set; }
            public string Url { get; set; }
            public DateTime UrlExpiration { get; set; }
        }
    }
}