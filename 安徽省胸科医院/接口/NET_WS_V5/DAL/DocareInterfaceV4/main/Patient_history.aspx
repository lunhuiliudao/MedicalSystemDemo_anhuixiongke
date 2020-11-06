<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Patient_history.aspx.cs"
    Inherits="main_Patient_history" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
    <title>第三方电子病历查阅系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=uft-8" />
    <meta http-equiv="Content-Language" content="zh-CN" />
    <link rel="stylesheet" href="../css/frameStyle.css" type="text/css" />
    <%--<link href="css.css" rel="stylesheet" type="text/css" />--%>

    <script type="text/javascript" charset="gb2312" src="image/design.js"></script>

    <script type="text/javascript" charset="gb2312" src="../public/suggest.js"></script>

    <script type="text/javascript">
function showPage(){
		//alert(11);
		var info = null;
	 info = window.showModalDialog('search.aspx','window','dialogwidth=703px; dialogheight=668px; status=no; help=no');
	 // alert((info==undefined?(""):(info)));
	 if(info==undefined)
	 {
	 return ;
	 }
	 else if(info.length<1)
	 {
	  alert("请填写检索条件!");
	 // window.showModalDialog('search.aspx','window','dialogwidth=703px; dialogheight=568px; status=no; help=no');
	  return ;
	 }
	// var info = info==undefined?(""):(info);
	 document.getElementById("idBoard").src="jieYueShenQing.aspx?params=true"+info;
	}
	function show()
{
	this.style.display = "block"
}
function hide()
{
	this.style.display = "none"

}
function hiddenMenu()
	{
	document.getElementById("idBoard").src="welcomePage.htm";
	document.getElementById("SysMenuBar").style.display='none';
	document.getElementById("SysMenuBar1").style.display='none';
	} 
function Print()
{
var pdf = window.frames['idBoard'].document.getElementById('YCanPDF');
if(pdf!=undefined)
{
pdf.DeleteWaterMark(0,1);
pdf.PrintNoDlg('Print',1,pdf.MaxPage,1,3,1);
}
//pdf.DeleteWaterMark(0,1)
//pdf.PrintNoDlg("Print",1,3,1,3,0);

//pdf.PrintNoDlg();
//pdf.Print("","",0);

}
    </script>

    <style type="text/css">
        .style1
        {
            width: 250px;
        }
    </style>
</head>
<body onload="MM_preloadImages('image/but_01a.png','image/but_02a.png','image/but_03a.png','image/but_04a.png','image/but_05a.png')">
    <table style="width: 100%; height: 100%" cellspacing="0" cellpadding="0" border="0">
        <tr>
            <td valign="top">
                <table cellspacing="0" cellpadding="0" border="0" style="width: 100%; height: 100%">
                    <tr>
                        <td>
                            <form id="Form1" runat="server">
                            <table border="0" cellspacing="0" cellpadding="0" style="margin-top: 0px; width: 100%;
                                height: 100%">
                            
                                <tr>
                                    <td>
                                        <table cellspacing="0" cellpadding="0" border="0" id="frame_middleTab">
                                            <tr>
                                                <td class="style1" valign="top" id="SysMenuBar" style="display: block">
                                                    <div class="sigmaQQ" id="SigmaQQ">
                                                        <div id="3">
                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0" background="image/tree_bg.gif">
                                                                <tr>
                                                                    <td width="90%" class="blue1" style="padding-left: 18px">
                                                                        病人病历
                                                                    </td>
                                                                    <td width="10%">
                                                                        <img src="image/tree_1.gif" width="22" height="27" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                        <!--mMenuEvent(this)-->
                                                        <div id="sMenu3" class="sMenuBlock" style="height: 100%; display: block;">
                                                            <asp:TreeView ID="TreeView1" runat="server" Width="178px" ImageSet="XPFileExplorer"
                                                                NodeIndent="15" ShowLines="True" CollapseImageUrl="~/main/image/folder2.gif"
                                                                ExpandImageUrl="~/main/image/folder1.gif">
                                                                <ParentNodeStyle Font-Bold="False" />
                                                                <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px"
                                                                    VerticalPadding="0px" />
                                                                <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px"
                                                                    NodeSpacing="0px" VerticalPadding="2px" />
                                                            </asp:TreeView>
                                                            <br />
                                                            <br />
                                                            <br />
                                                        </div>
                                                    </div>
                                                </td>
                                                <td class="controller" id="SysMenuBar1" style="display: block">
                                                    <img src="../img/controlNavTip_close.gif" width="7" style="position: relative; top: -50;"
                                                        ondrag="return false" onmousedown="this.style.marginTop=1" onmouseup="this.style.marginTop=0"
                                                        height="40" onmouseover="this.src=this.src.replace(/.gif/ig,'')+'_hover.gif'"
                                                        onmouseout="this.src=this.src.replace(/_hover.gif/ig,'.gif',this)" onclick="document.all.SysMenuBar.show=show;document.all.SysMenuBar.hide=hide;(this.open=!this.open)?document.all.SysMenuBar.hide():document.all.SysMenuBar.show();this.src=!this.open?this.src.replace(/open/ig,'close'):this.src.replace(/close/ig,'open');">
                                                </td>
                                                <td>
                                                    <iframe id="idBoard" width="100%" height="100%" frameborder="0" src="welcomePage.htm"
                                                        name="workAreaFame">&nbsp;</iframe>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            </form>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="7px">
                <div id="xia">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="xia">
                        <tr style="background-image: url(image/bot.jpg); height: 26px">
                            <td width="69%">
                            </td>
                            <td width="17%">
                                建议分辨率：1024*768
                            </td>
                            <td width="14%">
                                <span id="loadDate">2009年11月16日</span>
                            </td>
                        </tr>
                    </table>

                    <script type="text/javascript">
	var now = new Date() ;
//	var week1;
//	switch(now.getDay()){
//	case 0:
//			week1="星期日";
//			break;
//	case 1:
//			week1="星期一";
//			break;
//	case 2:
//			week1="星期二";
//			break;
//	case 3:
//			week1="星期三";
//			break;
//	case 4:
//			week1="星期四";
//			break;
//	case 5:
//			week1="星期五";
//			break;
//	case 6:
//			week1="星期六";
//			break;
//	}
	var year = now.getYear() ;
	var month = now.getMonth()+1 ;
	var day = now.getDate() ;
	var taday1= year+"年"+month+"月"+day+"日";
	document.all.loadDate.innerText=taday1;
                    </script>

                </div>
            </td>
        </tr>
    </table>
</body>
</html>
