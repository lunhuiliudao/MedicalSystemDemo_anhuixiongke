using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace MedicalSystem.Anes.Document.Configurations
{
   public class MedicalDocSection : ConfigurationSection
    {
       [ConfigurationProperty("medicalDocs", IsDefaultCollection = true)]
       public MedicalDocCollection MedicalDocs
       {
           get
           {
               return this["medicalDocs"] as MedicalDocCollection;
           }
           set
           {
               this["medicalDocs"] = value;
           }
       }

       [ConfigurationProperty("medicalForms", IsDefaultCollection = true)]
       public MedicalDocCollection MedicalForms
       {
           get
           {
               return this["medicalForms"] as MedicalDocCollection;
           }
           set
           {
               this["medicalForms"] = value;
           }
       }

       [ConfigurationProperty("customForms", IsDefaultCollection = true)]
       public MedicalDocCollection CustomForms
       {
           get
           {
               return this["customForms"] as MedicalDocCollection;
           }
           set
           {
               this["customForms"] = value;
           }
       }
    }
}
