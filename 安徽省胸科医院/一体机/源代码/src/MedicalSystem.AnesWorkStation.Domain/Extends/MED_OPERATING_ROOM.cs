using Dapper.Data;

namespace MedicalSystem.AnesWorkStation.Domain
{
    public partial class MED_OPERATING_ROOM
    {
        [NotMapped]
        public virtual string DEPT_NAME { get; set; }

        [NotMapped]
        public virtual string BED_TYPE_NAME { get; set; }

        [NotMapped]
        public virtual string STATUS_NAME { get; set; }
    }
}
