using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSystem.Anes.Document.Controls
{
    public interface ICheckable
    {
        string InputNeededMessage
        {
            get;
            set;
        }

        bool IsInputNeeded
        {
            get;
        }

        bool IsValid
        {
            get;
        }
    }
}
