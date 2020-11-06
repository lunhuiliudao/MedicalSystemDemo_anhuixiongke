<%@ Page Language="C#" AutoEventWireup="true" CodeFile="chaKanBingLi.aspx.cs" Inherits="Emr_bs.main.chaKanBingLi"  %>
<%--<%@ OutputCache Location="Server" Duration="120" VaryByParam="none"%>--%>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
<TITLE>电子病历系统</TITLE>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<meta http-equiv="Content-Language" content="zh-CN"/>
<link rel="stylesheet" href="../css/frameStyle.css" type="text/css"/>
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
}
</script>


    <style type="text/css">
        .style1
        {
            width: 300px;
        }
    </style>


</head>

<body onload="MM_preloadImages('image/but_01a.png','image/but_02a.png','image/but_03a.png','image/but_04a.png','image/but_05a.png')">


<table style="width:100%;height:100%"  cellspacing="0" cellpadding="0" border="0">
<tr><td   height="25px" bgcolor="#00FF00" >
<table  style="width:100%;" border="0" cellspacing="0" cellpadding="0">

  <tr>
    <td width="46%" background="image/top_mid.jpg"><img src="image/top_left.jpg" width="463" height="100" /></td>
    <td width="54%" align="right" background="image/top_mid.jpg"><table width="407" height="100
    " border="0" align="right" cellpadding="0" cellspacing="0" background="image/top_right.jpg">
      <tr>
        <td valign="top">
        <table width="371" height="71" border="0" align="right" cellpadding="0" cellspacing="0">
          <tr>
            <td width="62" height="71" valign="middle" ><a href="mainFrame.htm" ><img src="image/but_01.jpg" border="0" ></a></td>
            <td width="17">&nbsp;</td>
            <%--<td width="78"><a href="javascript:return false;" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image29','','image/but_02a.jpg',1)"><img src="image/but_02.jpg" name="Image29" width="68" height="60" border="0" id="Image29" alt="帮助" style="cursor:pointer"  onclick="hiddenMenu();showPage()" /></a></td>--%>
            <td width="15">&nbsp;</td>
   <td width="35"><a href="configuration.aspx"  target="workAreaFame"  onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image33','','image/but_07a.jpg',1)"><img src="image/but_07.jpg" name="Image33" width="68" height="60" border="0" id="Image33"   alt="退出"/></a></td>
            <td width="36"></td>
                    
            <td width="35"><a href="#" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image32','','image/but_05a.jpg',1)"><img src="image/but_05.jpg" name="Image32" width="68" height="60" border="0" id="Image32"  onClick="if(confirm('确定退出么?'))new Ajax().getData('/ajax.ashx','isAjax=true&switch=101',function(obj){alert('成功退出系统！');window.opener=null;window.close();});" alt="退出"/></a></td>
            <td width="36">&nbsp;</td>
          </tr>
        </table>
          <br />
          <br />
          <br />
          <br />
          <br />
          <br /></td>
      </tr>
    </table></td>
  </tr>
</table></td></tr>
<tr><td valign="top">
<table cellspacing="0" cellpadding="0" border="0"  style="width:100%;height:100%">
<tr><td>
<form id="Form1" runat="server">
<table  border="0" cellspacing="0" cellpadding="0" style="margin-top:0px;width:100%;height:100%"><%--style="width:expression(document.body.clientWidth>350?'100%':'950px')"--%>
  <tr><td>
<table cellspacing="0" cellpadding="0" border="0" id="frame_middleTab">
				<tr>
					<td class="style1" valign="top" id="SysMenuBar" style="display:block">
						<div class="sigmaQQ" id="SigmaQQ">
							<div id="3"  >
							<table width="100%" border="0" cellpadding="0" cellspacing="0" background="image/tree_bg.gif">
          <tr>
            <td width="90%" class="blue1" style="padding-left:18px">病人病历文书信息</td>
            <td width="10%"><img src="image/tree_1.gif" width="22" height="27" /></td>
          </tr>
        </table></div>
							<!--mMenuEvent(this)-->
								<div id="sMenu3" class="sMenuBlock" style="height:100%;display:block;">	
								 <asp:TreeView ID="TreeView1" runat="server" Width="178px" 
                                        ImageSet="XPFileExplorer" NodeIndent="15" ShowLines="True" 
                                        CollapseImageUrl="~/main/image/folder2.gif" 
                                        ExpandImageUrl="~/main/image/folder1.gif"  >
                                     <ParentNodeStyle Font-Bold="False" />
                                     <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" 
                                         HorizontalPadding="0px" VerticalPadding="0px" />
                                     <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" 
                                         HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" />
                                        
                                    </asp:TreeView>
                                <br />   
                                <br />       
                                <br />		
							       
							</div>							

							
					  </div>
					</td>
					<td class="controller" id="SysMenuBar1" style="display:block">
						<img src="../img/controlNavTip_close.gif" width="7" style="position:relative;top:-50;" ondrag="return false" onMouseDown="this.style.marginTop=1" onMouseUp="this.style.marginTop=0" height="40" onMouseOver="this.src=this.src.replace(/.gif/ig,'')+'_hover.gif'" onMouseOut="this.src=this.src.replace(/_hover.gif/ig,'.gif',this)" onClick="document.all.SysMenuBar.show=show;document.all.SysMenuBar.hide=hide;(this.open=!this.open)?document.all.SysMenuBar.hide():document.all.SysMenuBar.show();this.src=!this.open?this.src.replace(/open/ig,'close'):this.src.replace(/close/ig,'open');"> 
					</td>
					<td >
					<iframe id="idBoard" width="100%" height="100%" frameborder="0"  src="welcomePage.htm" name="workAreaFame">&nbsp;</iframe>
					
					</td>
				</tr>
			</table>
			</td>
  </tr>
</table>
</form></td></tr>
</table>
</td></tr>
<tr><td  height="7px" ><div id="xia">
<table width="100%" border="0" cellpadding="0" cellspacing="0" class="xia">
  <tr style="background-image:url(image/bot.jpg);height:26px">
    <td width="69%" >欢迎你：<%=userInfo.UserName%></td>
    <td width="17%" >建议分辨率：1024*768</td>
    <td width="14%"   ><span id="loadDate">2009年11月16日</span></td>
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
</div></td></tr>
</table>





</BODY>

</HTML>

