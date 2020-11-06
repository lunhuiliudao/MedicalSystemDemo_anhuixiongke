using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MedicalSystem.Anes.Document.Views;

namespace MedicalSystem.Anes.Client.AppPC
{
     [ToolboxItem(false)]
    public partial class EditTemplet : BaseView
    {
        public EditTemplet()
        {
            InitializeComponent();
        }
        public override bool IsDirty
        {
            get
            {
                return eventTemplet1.IsDirty | documentTemplet1.IsDirty;
            }
        }

        public override bool Save()
        {
            bool b = false;
            if (eventTemplet1.IsDirty && eventTemplet1.Save())
            {
                b = true;
            }
            if (documentTemplet1.IsDirty && documentTemplet1.Save())
            {
                b = true;
            }
            return b;
        }
        private void EditTemplet_Load(object sender, EventArgs e)
        {

        }
    }
}
