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
        public List<Instance> Instances { get; set; }
        
        public class Discipline
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        
        public class Instance
        {
            public int Id { set; get; }
            public Xyz Position { set; get; }
            public Xyz Rotation { set; get; }
            public Xyz CropBoxSize { set; get; }
            public Xyz CropBoxCenter { set; get; }
            public Xyz CropBoxRotation { set; get; }
            public int Scale { set; get; }
            public bool IsClippingPlaneInverted { set; get; }
            public string ViewUniqueId { set; get; }
            public string ViewName { set; get; }
            public bool IsDefault { set; get; }
        
            public class Xyz
            {
                public int X { set; get; }
                public int Y { set; get; }
                public int Z { set; get; }
            }
        }
    }
}