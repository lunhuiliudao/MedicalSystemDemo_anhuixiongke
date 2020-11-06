using MedicalSystem.Anes.Domain;
using MedicalSystem.DataServices.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.Anes.Client.Repository
{
    public class WebApiSetting
    {
        /// <summary>
        /// Header中的token键值
        /// </summary>
        public const string TOKENKEY = "ANESCARETOKEN";
    }
}
