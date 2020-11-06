using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MedicalSystem.Anes.Document.Designer.Controler
{
    public partial class TableSize : UserControl
    {
        public TableSize()
        {
            InitializeComponent();
        }

        public double Value
        {
            get
            {
                try
                {
                    return Convert.ToDouble(textEdit1.Text);
                }
                catch (Exception)
                {
                    return 0;
                }
            }

            set
            {
                textEdit1.Text = value.ToString();
            }
        }

        public int ValueType  // 0 像素 1 百分比
        {
            get
            {
                return radioGroup1.SelectedIndex;
            }

            set
            {
                radioGroup1.SelectedIndex = value;
            }
        }
    }
}
