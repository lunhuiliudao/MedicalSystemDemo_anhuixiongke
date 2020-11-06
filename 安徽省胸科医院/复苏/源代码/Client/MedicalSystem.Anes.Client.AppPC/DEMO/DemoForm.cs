using Com.MedicalSystem.Icu;
using Medicalsystem.Anes.Score.Controls;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Document.Documents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MedicalSystem.Anes.Client.AppPC.DEMO
{
    public partial class DemoForm : Form
    {
        public DemoForm()
        {
            InitializeComponent();
            buttonMenu1.Title = "测试";
            List<string> item = new List<string>();
            item.Add("添加");
            item.Add("删除");
            item.Add("修改");
            item.Add("保存");
            item.Add("查询");
            buttonMenu1.Items = item;
            buttonMenu1.InitItem();


            buttonMenu2.Title = "测试2";
            List<string> item2 = new List<string>();
            item2.Add("添加2");
            item2.Add("删除2");
            item2.Add("修改2");
            item2.Add("保存2");
            item2.Add("查询2");
            buttonMenu2.Items = item2;
            buttonMenu2.InitItem();


        }
        private void buttonMenu1_ItemClick(object sender, SelectedItem item)
        {
            MessageBox.Show(item.SelectIndex + ":" + item.SelectValue);
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }
        public void ShowDocByDocName(string docName)
        {
            ApplicationConfiguration.MedicalDocucementElement document = ApplicationConfiguration.GetMedicalDocument(docName);

            //没有找到退出
            if (string.IsNullOrEmpty(document.Caption))
            {
                //DialogResult dialogResult = XtraMessageBox.Show(string.Format("无法加载文书'{0}'的设计模版,请确保模版文件已经存在", docName),
                //        "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.workSpaceControl1.AddDocToWorkSpace(null);
                return;
            }

            try
            {

                Type t = Type.GetType(document.Type);
                BaseDoc baseDoc = Activator.CreateInstance(t) as BaseDoc;
                baseDoc.BackColor = Color.White;
                baseDoc.Name = docName;
                baseDoc.HideScrollBar();
                baseDoc.Initial();
                baseDoc.LoadReport(ExtendApplicationContext.Current.AppPath + document.Path);
                if (baseDoc.DocKind == DocKind.Anes)
                {
                    // baseDoc.AfterPrint += new Medicalsystem.Anes.Framework.Documents.BaseDoc.EventAfterPrint(AfterPrint);

                }
                // this.workSpaceControl1.AddDocToWorkSpace(baseDoc);

                Timer a = new Timer();
                a.Interval = 1;
                a.Tick += delegate
                {
                    baseDoc.ShowScrollBar();
                    //销毁定义器
                    a.Enabled = false;
                    a.Stop();
                    a.Dispose();

                };
                a.Enabled = true;


                if (ExtendApplicationContext.Current.AppType == ApplicationType.Anesthesia)
                {


                }
                else if (ExtendApplicationContext.Current.AppType == ApplicationType.PACU)
                {

                }

            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form a = new Form();
            a.Controls.Add(new Balthazar("001", 1, 1));
            a.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form a = new Form();
            a.Controls.Add(new Child_Pugh("001", 1, 1));
            a.Show();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form a = new Form();
            a.Controls.Add(new Goldman("001", 1, 1));
            a.Show();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form a = new Form();
            a.Controls.Add(new Lutz("001", 1, 1));
            a.Show();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form a = new Form();
            a.Controls.Add(new Pars("001", 1, 1));
            a.Show();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form a = new Form();
            a.Controls.Add(new ScoreTISSPanel("001", 1, 1));
            a.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form a = new Form();
            a.Controls.Add(new ScoreAPACHEIIPanel("001", 1, 1));
            a.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {

            Form a = new Form();

            AnesScore anes = new AnesScore("001", 1, 1);
            a.Controls.Add(anes);
            anes.Dock = DockStyle.Fill;
            a.Show();

        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form a = new Form();
            a.Controls.Add(new Steward("001", 1, 1));
            a.Show();

        }

        private void button15_Click(object sender, EventArgs e)
        {
            Form a = new Form();
            a.Controls.Add(new Aldrete("001", 1, 1));
            a.Show();

        }

        private void button16_Click(object sender, EventArgs e)
        {
            Form a = new Form();
            a.Controls.Add(new DoctorQualityControl());
            a.Show();

        }

        private void buttonMenu1_Load(object sender, EventArgs e)
        {

        }

        private void DemoForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString("测试下能否水印", new Font("微软雅黑", 30), Brushes.White, 20, 20);
        }


    }
}
