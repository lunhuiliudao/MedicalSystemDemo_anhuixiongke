
using MDSD.Permission.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.Anes.Domain
{
    public partial class MED_USERS
    {
        [NotMapped]
        public virtual string DEPT_NAME { get; set; }
        [NotMapped]
        public ICollection<MDSD_ACTION> MDSD_ACTION { get; set; }
        [NotMapped]
        public MDSD_APPLICATION MDSD_APPLICATION { set; get; } 
    }
}
