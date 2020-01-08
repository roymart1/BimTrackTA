using System;
using System.Collections.Generic;

namespace SeleniumTest.BusinessObjects
{
    public class Model
    {
        public int Id { get; set; }
        public ProjectTemplate Project { get; set; }
        public string Name { get; set; }
        public List<Revision> Revisions { get; set; }
        public Folder Folder { get; set; }

        // TODO: Why is it not a normal project? Is that supposed to be like that?

    }
}