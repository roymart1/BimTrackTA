using System;
using System.Collections.Generic;

namespace SeleniumTest.BusinessObjects
{
    public class Model
    {
        public int Id { get; set; }
        public ProjectTemplate Project { get; set; }
        public string Name { get; set; }
        public List<ModelRevision> Revisions { get; set; }
        public Folder Folder { get; set; }
    }
}