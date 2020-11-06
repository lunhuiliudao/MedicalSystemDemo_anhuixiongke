using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MedicalSystem.Anes.Framework;
using MedicalSystem.Anes.FrameWork;
namespace MedicalSystem.AnesWorkStation.ViewModel.ToolBarViewModel
{

    public class ImageList
    {
        public Bitmap ImageFirst { get; set; }
        public Bitmap ImageSecond { get; set; }
    }

    public class BottomMenuItemDictionary
    {
        private static Dictionary<string, ImageList> _bottomMenuItemDict = new Dictionary<string, ImageList>();
        public static Dictionary<string, ImageList> BottomMenuItemDict
        {
            get
            {
                if (_bottomMenuItemDict.Count <= 0)
                {
                    _bottomMenuItemDict = new Dictionary<string, ImageList>();

                    _bottomMenuItemDict.Add("麻醉记录单", new ImageList() { ImageFirst = ResourceImage.麻醉记录单, ImageSecond = ResourceImage.麻醉单_选中 });
                    _bottomMenuItemDict.Add("术前访视单", new ImageList() { ImageFirst = ResourceImage.术前访视单, ImageSecond = ResourceImage.术前访视单_选中 });
                    _bottomMenuItemDict.Add("麻醉同意书", new ImageList() { ImageFirst = ResourceImage.麻醉同意书, ImageSecond = ResourceImage.同意书_选中 });
                    _bottomMenuItemDict.Add("不良后果告知书", new ImageList() { ImageFirst = ResourceImage.麻醉同意书, ImageSecond = ResourceImage.同意书_选中 });
                    _bottomMenuItemDict.Add("术后随访单", new ImageList() { ImageFirst = ResourceImage.术后随访单, ImageSecond = ResourceImage.术后随访单_选中 });
                    _bottomMenuItemDict.Add("麻醉总结单", new ImageList() { ImageFirst = ResourceImage.术后随访单, ImageSecond = ResourceImage.术后随访单_选中 });
                    _bottomMenuItemDict.Add("手术信息", new ImageList() { ImageFirst = ResourceImage.手术信息, ImageSecond = ResourceImage.手术信息_选中 });
                    _bottomMenuItemDict.Add("仪器设置", new ImageList() { ImageFirst = ResourceImage.仪器设置, ImageSecond = ResourceImage.仪器设置_选中 });
                    _bottomMenuItemDict.Add("术后登记", new ImageList() { ImageFirst = ResourceImage.手术信息, ImageSecond = ResourceImage.手术信息_选中 });
                    _bottomMenuItemDict.Add("保存模板", new ImageList() { ImageFirst = ResourceImage.保存模板, ImageSecond = ResourceImage.模板保存_选中 });
                    _bottomMenuItemDict.Add("更换手术间", new ImageList() { ImageFirst = ResourceImage.术中换室_未选中, ImageSecond = ResourceImage.术中换室_选中 });
                    _bottomMenuItemDict.Add("手术交接班", new ImageList() { ImageFirst = ResourceImage.交班, ImageSecond = ResourceImage.交班_选中 });
                    _bottomMenuItemDict.Add("检验结果", new ImageList() { ImageFirst = ResourceImage.检验结果, ImageSecond = ResourceImage.检验结果_选中 });
                    _bottomMenuItemDict.Add("查看术中", new ImageList() { ImageFirst = ResourceImage.术中查看_未选中, ImageSecond = ResourceImage.术中查看_选中 });
                    _bottomMenuItemDict.Add("血气分析", new ImageList() { ImageFirst = ResourceImage.血气分析_未选中, ImageSecond = ResourceImage.血气分析_选中 });
                    _bottomMenuItemDict.Add("个性化体征", new ImageList() { ImageFirst = ResourceImage.个性化体征_未选中, ImageSecond = ResourceImage.个性化体征_选中 });
                    _bottomMenuItemDict.Add("手术跳转", new ImageList() { ImageFirst = ResourceImage.手术跳转_未选中, ImageSecond = ResourceImage.手术跳转_选中 });
                    _bottomMenuItemDict.Add("手术取消", new ImageList() { ImageFirst = ResourceImage.手术取消_未选中, ImageSecond = ResourceImage.手术取消_选中 });
                    _bottomMenuItemDict.Add("术后镇痛记录单", new ImageList() { ImageFirst = ResourceImage.麻醉同意书, ImageSecond = ResourceImage.同意书_选中 });
                    _bottomMenuItemDict.Add("输血评估单", new ImageList() { ImageFirst = ResourceImage.麻醉同意书, ImageSecond = ResourceImage.同意书_选中 });
                    _bottomMenuItemDict.Add("手术安全核查单", new ImageList() { ImageFirst = ResourceImage.麻醉同意书, ImageSecond = ResourceImage.同意书_选中 });
                    _bottomMenuItemDict.Add("家属协同", new ImageList() { ImageFirst = ResourceImage.家属协同_未选中, ImageSecond = ResourceImage.家属协同_选中 });
                    _bottomMenuItemDict.Add("麻醉计费", new ImageList() { ImageFirst = ResourceImage.麻醉计费_未选中, ImageSecond = ResourceImage.麻醉计费_选中 });

                    //_bottomMenuItemDict.Add("麻醉记录单", Application.StartupPath + @"\Images\BottomMenu\.png" + "," + Application.StartupPath + @"\Images\BottomMenu\.png");
                    //_bottomMenuItemDict.Add("术前访视单", Application.StartupPath + @"\Images\BottomMenu\术前访视单.png" + "," + Application.StartupPath + @"\Images\BottomMenu\术前访视单-选中.png");
                    //_bottomMenuItemDict.Add("麻醉同意书", Application.StartupPath + @"\Images\BottomMenu\麻醉同意书.png" + "," + Application.StartupPath + @"\Images\BottomMenu\同意书-选中.png");
                    //_bottomMenuItemDict.Add("不良后果告知书", Application.StartupPath + @"\Images\BottomMenu\麻醉同意书.png" + "," + Application.StartupPath + @"\Images\BottomMenu\同意书-选中.png");
                    //_bottomMenuItemDict.Add("术后随访单", Application.StartupPath + @"\Images\BottomMenu\术后随访单.png" + "," + Application.StartupPath + @"\Images\BottomMenu\术后随访单-选中.png");
                    //_bottomMenuItemDict.Add("麻醉总结单", Application.StartupPath + @"\Images\BottomMenu\术后随访单.png" + "," + Application.StartupPath + @"\Images\BottomMenu\术后随访单-选中.png");
                    //_bottomMenuItemDict.Add("手术信息", Application.StartupPath + @"\Images\BottomMenu\手术信息.png" + "," + Application.StartupPath + @"\Images\BottomMenu\手术信息-选中.png");
                    //_bottomMenuItemDict.Add("仪器设置", Application.StartupPath + @"\Images\BottomMenu\仪器设置.png" + "," + Application.StartupPath + @"\Images\BottomMenu\仪器设置-选中.png");
                    //_bottomMenuItemDict.Add("术后登记", Application.StartupPath + @"\Images\BottomMenu\手术信息.png" + "," + Application.StartupPath + @"\Images\BottomMenu\手术信息-选中.png");
                    //_bottomMenuItemDict.Add("保存模板", Application.StartupPath + @"\Images\BottomMenu\保存模板.png" + "," + Application.StartupPath + @"\Images\BottomMenu\模板保存-选中.png");
                    //_bottomMenuItemDict.Add("更换手术间", Application.StartupPath + @"\Images\BottomMenu\术中换室-未选中.png" + "," + Application.StartupPath + @"\Images\BottomMenu\术中换室-选中.png");
                    //_bottomMenuItemDict.Add("手术交接班", Application.StartupPath + @"\Images\BottomMenu\交班.png" + "," + Application.StartupPath + @"\Images\BottomMenu\交班-选中.png");
                    //_bottomMenuItemDict.Add("检验结果", Application.StartupPath + @"\Images\BottomMenu\检验结果.png" + "," + Application.StartupPath + @"\Images\BottomMenu\检验结果-选中.png");
                    //_bottomMenuItemDict.Add("查看术中", Application.StartupPath + @"\Images\BottomMenu\术中查看-未选中.png" + "," + Application.StartupPath + @"\Images\BottomMenu\术中查看-选中.png");
                    //_bottomMenuItemDict.Add("血气分析", Application.StartupPath + @"\Images\BottomMenu\血气分析-未选中.png" + "," + Application.StartupPath + @"\Images\BottomMenu\血气分析-选中.png");
                    //_bottomMenuItemDict.Add("个性化体征", Application.StartupPath + @"\Images\BottomMenu\个性化体征-未选中.png" + "," + Application.StartupPath + @"\Images\BottomMenu\个性化体征-选中.png");
                    //_bottomMenuItemDict.Add("手术跳转", Application.StartupPath + @"\Images\BottomMenu\手术跳转-未选中.png" + "," + Application.StartupPath + @"\Images\BottomMenu\手术跳转-选中.png");
                    //_bottomMenuItemDict.Add("手术取消", Application.StartupPath + @"\Images\BottomMenu\手术取消-未选中.png" + "," + Application.StartupPath + @"\Images\BottomMenu\手术取消-选中.png");
                    //_bottomMenuItemDict.Add("术后镇痛记录单", Application.StartupPath + @"\Images\BottomMenu\麻醉同意书.png" + "," + Application.StartupPath + @"\Images\BottomMenu\同意书-选中.png");
                    //_bottomMenuItemDict.Add("输血评估单", Application.StartupPath + @"\Images\BottomMenu\麻醉同意书.png" + "," + Application.StartupPath + @"\Images\BottomMenu\同意书-选中.png");
                    //_bottomMenuItemDict.Add("手术安全核查单", Application.StartupPath + @"\Images\BottomMenu\麻醉同意书.png" + "," + Application.StartupPath + @"\Images\BottomMenu\同意书-选中.png");
                    //_bottomMenuItemDict.Add("家属协同", Application.StartupPath + @"\Images\BottomMenu\家属协同-未选中.png" + "," + Application.StartupPath + @"\Images\BottomMenu\家属协同-选中.png");


                }
                return _bottomMenuItemDict;
            }
        }

    }
}
