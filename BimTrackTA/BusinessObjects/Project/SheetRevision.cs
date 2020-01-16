using System;
using System.Collections.Generic;

namespace SeleniumTest.BusinessObjects
{
    public class SheetRevision
    {       
        public List<Instance> Instances { get; set; }
        public int? Id { get; set; }
        public BimFile FileInfo { get; set; }
        public DateTime? CreationDate { get; set; }
        public Author Author { get; set; }
        public int? Number { get; set; }
    }
}