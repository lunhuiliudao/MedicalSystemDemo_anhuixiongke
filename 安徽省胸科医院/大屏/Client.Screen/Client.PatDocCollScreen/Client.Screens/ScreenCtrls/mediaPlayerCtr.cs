using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using System.Xml;
using System.IO;
using MedicalSystem.MedScreen.Network;

namespace MedicalSystem.MedScreen.Client.PatDocScreen
{
    [ToolboxItem(true), Description("媒体播放控件")]
    public partial class mediaPlayerCtr : UserControl
    {
        #region 变量
        /// <summary>
        /// 播放文件的路径字典
        /// </summary>
        Dictionary<string, string> playListDict = new Dictionary<string, string>();
        /// <summary>
        /// 当前播放的媒体列表
        /// </summary>
        IWMPMediaCollection mediacollection;
        /// <summary>
        /// 当前播放的媒体
        /// </summary>
        IWMPMedia media;
        /// <summary>
        /// 是否浏览PPT
        /// </summary>
        bool isBrowPPT = false;
        #endregion

        #region 构造函数
        public mediaPlayerCtr()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
            mediaPlayer.stretchToFit = true;
            mediaPlayer.settings.autoStart = true;
            mediaPlayer.settings.setMode("loop", true);
        }
        #endregion

        /// <summary>
        /// 界面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mediaPlayerCtr_Load(object sender, EventArgs e)
        {
            this.leftMargin.Width = this.Width / 50;
            this.rightMargin.Width = 0;
            this.bottomMargin.Height = this.Height / 80;
            InitialPlayList();
            btnHideList.PerformClick();
        }

        /// <summary>
        /// 初始化播放列表
        /// </summary>
        private void InitialPlayList()
        {
            try
            {
                playList.Items.Clear();
                XmlDocument xmlDoc = new XmlDocument();
                //读取保存的历史播放列表
                string path = Application.StartupPath + "\\mediaPlayList.xml";
                List<string> filePathList = new List<string>();
                playListDict = new Dictionary<string, string>();

                if (File.Exists(path))
                {
                    xmlDoc.Load(path);
                    foreach (XmlNode xmlNode in xmlDoc.ChildNodes[0].ChildNodes)
                    {
                        string filePath = xmlNode.InnerText;
                        if (!filePathList.Contains(filePath) && File.Exists(@filePath))
                        {
                            filePathList.Add(filePath);
                            string fileName = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                            fileName = fileName.Substring(0, fileName.LastIndexOf("."));
                            if (playListDict.Keys.Contains(fileName))
                            {
                                fileName += "(1)";
                            }
                            playListDict.Add(fileName, filePath);
                        }
                    }
                }
                foreach (string file in playListDict.Keys)
                {
                    this.AddFile(playListDict[file]);
                }
                if (playList.Items.Count > 0)
                {
                    playList.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
        }

        /// <summary>
        /// 隐藏（展示）播放列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHideList_Click(object sender, EventArgs e)
        {
            if (grpBoxContainer.Visible)
            {
                btnHideList.Text = "<";
            }
            else
            {
                btnHideList.Text = ">";
            }
            grpBoxContainer.Visible = !grpBoxContainer.Visible;

            if (grpBoxContainer.Visible)
                btnHideList.Location = new Point(grpBoxContainer.Left - btnHideList.Width, (mediaPlayArea.Bottom - btnHideList.Height) / 2);
            else
            {
                btnHideList.Location = new Point(this.Right - btnHideList.Width - 10 - rightMargin.Width, (mediaPlayArea.Bottom - btnHideList.Height) / 2);
            }
        }

        /// <summary>
        /// 添加文件，视频文件或PPT
        /// </summary>
        /// <param name="path">文件路径</param>
        private void AddFile(string path)
        {
            try
            {
                string fileName = path.Substring(path.LastIndexOf("\\") + 1);
                fileName = fileName.Substring(0,fileName.LastIndexOf("."));
                //查看lstBox是否已存在要添加的文件，不存在则继续添加
                for (int i = 0; i < playList.Items.Count; i++)
                {
                    if (playList.Items[i].ToString() == fileName)
                    {
                        playList.SelectedIndex = i;
                        return;
                    }
                }

                if (Path.GetExtension(path).ToLower() == ".ppt" || Path.GetExtension(path).ToLower() == ".pptx")
                {
                    mediaPlayer.currentPlaylist.clear();
                    btnHideList.Visible = false;
                    grpBoxContainer.Visible = false;
                    mediaPlayer.Visible = false;
                    browserPPT.Visible = true;
                    browserPPT.Parent = mediaPlayArea;
                    browserPPT.Dock = DockStyle.Fill;
                    browserPPT.Navigate(path, false);
                    
                    isBrowPPT = true;
                    //设置PPT的自动翻页时间，10秒
                    Timer turnPptTimer = new Timer();
                    turnPptTimer.Interval = 10000;
                    turnPptTimer.Tick += new EventHandler(delegate(object sender1, EventArgs e1)
                    {
                        SendKeys.Send("{RIGHT}");
                        if (browserPPT.ReadyState == WebBrowserReadyState.Complete) 
                        { }
                    });
                    turnPptTimer.Start();
                }
                else
                {
                    mediacollection = mediaPlayer.mediaCollection;
                    media = mediacollection.add(path);
                    mediaPlayer.currentPlaylist.appendItem(media);
                    mediacollection.remove(media, false);//可省
                    playList.Items.Add(fileName);
                    playList.SelectedIndex = playList.Items.Count - 1;
                    if (!playListDict.ContainsKey(fileName))
                    {
                        playListDict.Add(fileName, path);
                        SavePlayListToXml();
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
        }

        /// <summary>
        /// 保存历史播放列表
        /// </summary>
        private void SavePlayListToXml()
        {
            try
            {
                XmlDocument targetXml = new XmlDocument();
                XmlElement root = targetXml.CreateElement("Files"); // 创建根节点Files
                targetXml.AppendChild(root);    //  加入到xml document

                foreach (string key in playListDict.Keys)
                {
                    if (File.Exists(playListDict[key]))
                    {
                        XmlElement path = targetXml.CreateElement("path");  // 创建path元素
                        path.InnerXml = playListDict[key];
                        root.AppendChild(path);   // 添加到xml document
                    }
                }
                targetXml.Save(Application.StartupPath + "\\mediaPlayList.xml");   // 保存文件
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
        }

        /// <summary>
        /// 添加播放内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (Path.GetExtension(openFileDialog.FileName).ToLower() == ".ppt" || Path.GetExtension(openFileDialog.FileName).ToLower() == ".pptx")
                    {
                        this.AddFile(openFileDialog.FileName);
                    }
                    else
                    {
                        this.AddFile(openFileDialog.FileName);
                    }
                    if (playList.SelectedIndex != -1 && !isBrowPPT)
                    {
                        IWMPMedia curntMedia = mediaPlayer.currentPlaylist.get_Item(playList.SelectedIndex);
                        mediaPlayer.Ctlcontrols.playItem(curntMedia);
                    }
                }
            }
            catch (Exception error)
            {
                ExceptionHandler.Handle(error);
            }
        }

        /// <summary>
        /// 隐藏或显示播放器下方的播放控制按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 隐藏播放控制HToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mediaPlayer.uiMode == "none")
                mediaPlayer.uiMode = "full";
            else mediaPlayer.uiMode = "none";
        }

        /// <summary>
        /// 设置为加载后播放自动开始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mediaPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (mediaPlayer.status == "准备就绪")
            {
                mediaPlayer.Ctlcontrols.play();
            }
            if (mediaPlayer.status.Contains("正在播放"))
            {
                playList.SelectedItem = mediaPlayer.currentMedia.name;
            }
        }

        private void playList_MouseHover(object sender, EventArgs e)
        {
            //playList.GetItemText(playList.GetChildAtPoint(new Point(sender.
            //toolTip1.SetToolTip(playList,
        }

        /// <summary>
        /// 双击开始播放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (playList.SelectedIndex == -1) return;
                string item = playList.SelectedItem.ToString();
                IWMPMedia curntMedia = mediaPlayer.currentPlaylist.get_Item(playList.SelectedIndex);
                mediaPlayer.Ctlcontrols.playItem(curntMedia);
            }
            catch (Exception error)
            {
                ExceptionHandler.Handle(error);
            }
        }

        /// <summary>
        /// 修改当前的播放内容显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (playList.SelectedIndex == -1) return;
            toolTip.SetToolTip(playList, playList.Items[playList.SelectedIndex].ToString());
        }

        /// <summary>
        /// 播放选中的内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 播放ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (playList.SelectedIndex == -1) return;
            try
            {
                string item = playList.SelectedItem.ToString();
                IWMPMedia curntMedia = mediaPlayer.currentPlaylist.get_Item(playList.SelectedIndex);
                mediaPlayer.Ctlcontrols.playItem(curntMedia);
            }
            catch (Exception error)
            {
                ExceptionHandler.Handle(error);
            }
        }

        /// <summary>
        /// 将文件从播放列表中删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (playList.SelectedIndex == -1) return;
            IWMPMedia currentMedia = mediaPlayer.currentPlaylist.get_Item(playList.SelectedIndex);
            mediaPlayer.currentPlaylist.removeItem(currentMedia);
            string item = playList.SelectedItem.ToString();
            playList.Items.RemoveAt(playList.SelectedIndex);
            playListDict.Remove(item);
            SavePlayListToXml();
        }

        /// <summary>
        /// 清空播放列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            playList.Items.Clear();
            playListDict.Clear();
            mediaPlayer.currentPlaylist.clear();
            SavePlayListToXml();
        }
    }
}
