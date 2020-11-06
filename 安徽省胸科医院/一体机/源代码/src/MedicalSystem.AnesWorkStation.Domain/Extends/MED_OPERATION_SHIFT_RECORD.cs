using Dapper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{
    public partial class MED_OPERATION_SHIFT_RECORD
    {
        [NotMapped]
        public virtual string PERSON_NAME { get; set; }

        private string _shiftPersonName;
        [NotMapped]
        public virtual string SHIFT_PERSON_NAME
        {
            get
            {
                return _shiftPersonName;
            }
            set
            {
                _shiftPersonName = value;
                RaisePropertyChanged("SHIFT_PERSON_NAME");
            }
        }

        private bool _is_Show = false;
        [NotMapped]
        public virtual bool IS_SHOW
        {
            get
            {
                return _is_Show;
            }
            set
            {
                _is_Show = value;
                RaisePropertyChanged("IS_SHOW");
            }
        }
    }
}
