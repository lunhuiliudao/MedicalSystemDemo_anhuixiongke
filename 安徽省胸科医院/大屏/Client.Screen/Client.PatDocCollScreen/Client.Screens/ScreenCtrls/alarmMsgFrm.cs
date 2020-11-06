using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalSystem.MedScreen.Client.PatDocScreen
{
    [ToolboxItem(true), Description("通告信息提示框")]
    public partial class alarmMsgFrm : UserControl
    {
        public alarmMsgFrm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
        }

        private void alarmMsgFrm_Load(object sender, EventArgs e)
        {
            this.leftMargin.Width = this.Width / 30;
            this.rightMargin.Width = 0;
            this.bottomMargin.Height = this.Height / 80;
            
        }
    }
}
