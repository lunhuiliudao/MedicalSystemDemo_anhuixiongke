using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace MedicalSystem.Anes.Document.Configurations
{
   public class MedicalDocCollection : ConfigurationElementCollection
    {
       protected override ConfigurationElement CreateNewElement()
       {
           return new MedicalDocElement();
       }
       protected override object GetElementKey(ConfigurationElement element)
       {
           MedicalDocElement medicalDocElement = element as MedicalDocElement;
           return medicalDocElement.Key;
       }
    }
}
