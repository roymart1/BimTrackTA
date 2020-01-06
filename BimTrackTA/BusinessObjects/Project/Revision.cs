using System;
using System.Collections.Generic;

namespace SeleniumTest.BusinessObjects
{
    public class Revision
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public int IfcScaleFactor { get; set; }
        public string Comment { get; set; }
        public List<Discipline> Disciplines { get; set; }
    }
}