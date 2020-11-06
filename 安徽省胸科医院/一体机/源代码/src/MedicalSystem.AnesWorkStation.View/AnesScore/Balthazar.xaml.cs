//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      Balthazar.xaml.cs
//功能描述(Description)：    Balthazar评分
//数据表(Tables)：		     无
//作者(Author)：             MDSD
//日期(Create Date)：        2019-08-15 10:05:39
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.ViewModel.AnesScoreViewModel;
using System;
using System.Windows;

namespace MedicalSystem.AnesWorkStation.View.AnesScore
{
    /// <summary>
    /// Balthazar.xaml 的交互逻辑
    /// </summary>
    public partial class Balthazar : BaseUserControl
    {
        private BalthazarViewModel balthazarViewModel;
        public Balthazar()
        {
            InitializeComponent();

            balthazarViewModel = new BalthazarViewModel();

            this.DataContext = this.balthazarViewModel;
        }

        /// <summary>
        /// 载入文书
        /// </summary>
        private void BaseUserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void TabControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            double containerWidth = SystemParameters.PrimaryScreenWidth;
            double containerHeight = SystemParameters.PrimaryScreenHeight - 30;

            string header = ((System.Windows.Controls.HeaderedContentControl)((object[])e.AddedItems)[0]).Header.ToString();

            if (header == "Balthazar胰腺病变CT严重性指数评分")
            {
                winHostMain.Width = containerWidth;
                winHostMain.Height = containerHeight;
                winPanelContent.Width = (int)containerWidth;
                winPanelContent.Height = (int)containerHeight;
                winPanelContent.Controls.Add(this.balthazarViewModel.BalthazarForm);
            }
            else if (header == "Child-Pugh肝脏疾病患者手术危险性评分")
            {
                winHostMain1.Width = containerWidth;
                winHostMain1.Height = containerHeight;
                winPanelContent1.Width = (int)containerWidth;
                winPanelContent1.Height = (int)containerHeight;
                winPanelContent1.Controls.Add(this.balthazarViewModel.Child_PughForm);
            }
            else if (header == "GOLDMAN心脏高危因素评分")
            {
                winHostMain2.Width = containerWidth;
                winHostMain2.Height = containerHeight;
                winPanelContent2.Width = (int)containerWidth;
                winPanelContent2.Height = (int)containerHeight;
                winPanelContent2.Controls.Add(this.balthazarViewModel.GoldmanForm);
            }
            else if (header == "Lutz麻醉危险性评分")
            {
                winHostMain3.Width = containerWidth;
                winHostMain3.Height = containerHeight;
                winPanelContent3.Width = (int)containerWidth;
                winPanelContent3.Height = (int)containerHeight;
                winPanelContent3.Controls.Add(this.balthazarViewModel.Lutz);
            }
            else if (header == "PARS麻醉恢复评分")
            {
                winHostMain4.Width = containerWidth;
                winHostMain4.Height = containerHeight;
                winPanelContent4.Width = (int)containerWidth;
                winPanelContent4.Height = (int)containerHeight;
                winPanelContent4.Controls.Add(this.balthazarViewModel.Pars);
            }
            else if (header == "APACHE2评分")
            {
                winHostMain5.Width = containerWidth;
                winHostMain5.Height = containerHeight;
                winPanelContent5.Width = (int)containerWidth;
                winPanelContent5.Height = (int)containerHeight;
                winPanelContent5.Controls.Add(this.balthazarViewModel.ScoreAPACHEIIPanel);
            }
            else if (header == "TISS评分")
            {
                winHostMain6.Width = containerWidth;
                winHostMain6.Height = containerHeight;
                winPanelContent6.Width = (int)containerWidth;
                winPanelContent6.Height = (int)containerHeight;
                winPanelContent6.Controls.Add(this.balthazarViewModel.ScoreTISSPanel);
            }
        }
    }
}
