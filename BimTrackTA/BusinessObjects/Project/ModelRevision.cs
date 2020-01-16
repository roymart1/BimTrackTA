using System;
using System.Collections.Generic;
using System.IO;

namespace SeleniumTest.BusinessObjects
{
    public class ModelRevision
    {       
       public Author Author { get; set; }
       public BimFile IfcFile { get; set; }
       public BimFile WexBimFile { get; set; }
       public BimFile PropertiesFile { get; set; }
       public Model Model { get; set; }
       
       public bool IsProcessing { get; set; }
       public bool HasProcessingError { get; set; }
       public float ProcessingProgress { get; set; }
       public int Id { get; set; }
       public DateTime CreationDate { get; set; }
       public int Number { get; set; }
       public string Name { get; set; }
       public float IfcScaleFactor { get; set; }
       public string Comment { get; set; }
       public List<Discipline> Disciplines { get; set; }
    }
}