using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MedicalSystem.Anes.Document.Controls
{
    public interface IPrintable
    {
        void Draw(Graphics g, float x, float y);
        bool NoPrint{get;}
    }
}
