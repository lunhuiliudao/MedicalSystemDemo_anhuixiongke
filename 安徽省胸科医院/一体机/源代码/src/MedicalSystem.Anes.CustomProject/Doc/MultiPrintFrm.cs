// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      MultiPrintFrm.cs
// 功能描述(Description)：    集中打印文书窗口实体类
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2018/01/23 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using DevExpress.XtraEditors.Controls;
using MedicalSystem.Anes.CustomProject;
using MedicalSystem.Anes.Document.Configurations;
using MedicalSystem.Anes.FrameWork;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MedicalSystem.Anes.Custom.CustomProject
{
    /// <summary>
    /// 集中打印文书窗口实体类
    /// </summary>
    public partial class MultiPrintFrm : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// 无参构造
        /// </summary>
        public MultiPrintFrm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载事件，显示所有的文书
        /// </summary>
        private void MultiPrintFrm_Load(object sender, EventArgs e)
        {
            List<string> fileList = new List<string>();
            Dictionary<string, MedicalDocElement> docKeyValuePairs = MedicalDocSettings.GetMedicalDocNameAndPath();
            foreach (KeyValuePair<string, MedicalDocElement> keyValuePair in docKeyValuePairs)
            {
                CheckedListBoxItem boxItemDocCheck = new CheckedListBoxItem(keyValuePair.Key, keyValuePair.Value.Key);
                chkDocCheckList.Items.Add(boxItemDocCheck);
                if (fileList.Contains(keyValuePair.Key))
                {
                    boxItemDocCheck.CheckState = CheckState.Checked;
                }
            }
        }

        /// <summary>
        /// 集中打印按钮
        /// </summary>
        private void BtnPrint_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("文书是否要集中打印", "集中打印", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            // 集中打印文书前，记录当前文书的名称，在集中打印完成后重新设置回来。
            // 之所以记录当前文书名称，是防止在打印各时，需要根据根据文书名称来实现个性化的功能.
            string strCurDocName = ExtendAppContext.Current.CurrentDocName;
            foreach (CheckedListBoxItem item in chkDocCheckList.Items)
            {
                if (item.CheckState == CheckState.Checked)
                {
                    ApplicationConfiguration.MedicalDocucementElement document = ApplicationConfiguration.GetMedicalDocument(item.Value.ToString());

                    //没有找到退出
                    if (string.IsNullOrEmpty(document.Caption))
                    {
                        DialogResult dialogResult = MessageBoxFormPC.Show(string.Format("无法加载文书'{0}'的设计模版,请确保模版文件已经存在", 
                                                                          item.Value.ToString()),
                                                                          "提示信息", 
                                                                          MessageBoxButtons.OK, 
                                                                          MessageBoxIcon.Information);
                        continue;
                    }

                    try
                    {
                        // 减少资源消耗，每次加载文书前都手动释放资源
                        GC.Collect();
                        GC.Collect();

                        // 使用using(){} 格式，确保在执行完该代码块时调用Dispose，实现手动释放资源
                        Type t = Type.GetType(document.Type);
                        using (CustomBaseDoc baseDoc = Activator.CreateInstance(t) as CustomBaseDoc)
                        {
                            baseDoc.BackColor = Color.White;
                            baseDoc.Name = item.Value.ToString();
                            ExtendAppContext.Current.CurrentDocName = baseDoc.Name;
                            baseDoc.HideScrollBar();
                            baseDoc.Initial();
                            baseDoc.LoadReport(ExtendAppContext.Current.AppPath + document.Path);
                            bool IsPrintSuccess = baseDoc.PrintBaseDoc();
                            baseDoc.CommitDocNoMess();
                        }

                        List<string> fileList = new List<string>();
                        foreach (CheckedListBoxItem boxItem in chkDocCheckList.Items)
                        {
                            if (boxItem.CheckState == CheckState.Checked)
                            {
                                fileList.Add(boxItem.Value.ToString());
                            }
                        }
                    }
                    catch
                    {
                    }
                    finally
                    {
                        // 减少资源消耗，每次加载文书前都手动释放资源
                        GC.Collect();
                        GC.Collect();
                    }
                }
            }

            // 重置当前文书名称
            ExtendAppContext.Current.CurrentDocName = strCurDocName;

            //打印结束后，自动关闭打印选择界面。
            this.Close();
        }

        /// <summary>
        /// 关闭按钮
        /// </summary>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}