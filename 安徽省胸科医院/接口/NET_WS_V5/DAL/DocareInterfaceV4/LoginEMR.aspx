<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginEMR.aspx.cs" Inherits="LoginEMR" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<HTML>
<HEAD>
<TITLE>电子病历管理检索平台</TITLE>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<meta http-equiv="Content-Language" content="zh-CN"/>
<meta content="all" name="robots" /> 
<meta name="author" content="sj" />
<meta name="Copyright" content="sj" />
<meta name="description" content="电子病历管理利用平台" />
<link rel="stylesheet" href="./css/loadcss.css" type="text/css"/>
<link href="main/css.css" rel="stylesheet" type="text/css" />
</HEAD>
<script>
	function goTarget(url){		
		window.location.href = url;
	}

</script>

<SCRIPT LANGUAGE="JavaScript">
<!--
function openFullWin(url) {
	var newWindow = window.open(url,("win"+Math.round(Math.random()*1000)), "menubar=0,toolbar=0,scrollbars=0,titlebar=0,location=0,status=0,resizable=1");
	opener=null;
	top.window.opener = null;
	if(typeof(newWindow.document)=="object"){
		top.window.close();
	}else{
		_alert("浏览器屏蔽了弹出窗口，请重新设置，允许本系统的打开新窗口！");
	}
}

var url="login.aspx";
function intro()
{
    if ((navigator.appVersion.indexOf("Mac")!=-1) &&
    		(navigator.userAgent.indexOf("MSIE")!=-1) &&
		(parseInt(navigator.appVersion)=4))
    {
    	skip()
    }
    else
    {
   	 popup()
    }
}
function skip()
{
    location.href=url;
}
function popup()
{
    version =parseFloat(navigator.appVersion.substring(navigator.appVersion.indexOf('.')-1,navigator.appVersion.length));
    if (version >=4)
    	version = parseFloat(navigator.appVersion.substring(navigator.appVersion.indexOf('.')-1,navigator.appVersion.length));
    if (version >= 4)
    {
            if (navigator.appName=="Netscape")
            {
    		Hello = window.open(url,"Hello","scrollbars");
      	 	Hello.focus();
              	window.opener =null;
    		window.close();
            }
            if (navigator.appName=="Microsoft Internet Explorer")
            {
              var sFeatures="channelmode=0,directories=0,fullscreen=0,left=0,location=0";
	sFeatures=sFeatures+",menubar=0,resizable=1,scrollbars=1,status=1";
	sFeatures=sFeatures+",titlebar=1,toolbar=0,top=0";
	sFeatures +=",height=" +String(screen.availHeight-40);
	sFeatures +=",width="+String(screen.availWidth-4);
        window.open(url,"_blank",sFeatures);
                window.opener =null;
    		window.close();
            }
    }
    else
    {
        location.href=url;
    }
}
function logintest()
{
 var TbUsername =document.getElementById("TbUsername").value;
 var TbUserpass =document.getElementById("TbUserpass").value;
 if(TbUsername.length<1)
 {
    alert("用户名不能为空！");
    document.getElementById("TbUsername").focus();
    return false; 
 }
 else if(TbUserpass.length<1)
 {
    alert("密码不能为空！");
    document.getElementById("TbUserpass").focus();
    return false;
 }
 return true;
}
window.setTimeout("document.getElementById('TbUsername').focus();",120);
//function document.onkeydown ()
//{
//if(event.keyCode==13)
//event.keyCode=9;

//}
//-->
</script>

<BODY style="border:5px solid buttonface;overflow:hidden" onkeypress="if(event.keyCode==13)loginButton.click();">

  
    <table width="100%"  height="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left"><table width="100%" height="667" border="0" cellpadding="0" cellspacing="0">
      <tr>
        <td width="661" align="left" background="main/image/login_bg.jpg"><table width="1003" height="667" border="0" cellpadding="0" cellspacing="0">
          <tr>
            <td width="598" rowspan="3">&nbsp;</td>
            <td height="237" colspan="3">&nbsp;</td>
          </tr>
          <tr>
            <td width="26" height="178">&nbsp;</td>
            <td width="310">
              <form id="form1" runat="server">
            <table width="293" height="143" border="0" align="left" cellpadding="0" cellspacing="0">
                <tr>
                  <td>&nbsp;</td>
                  <td colspan="4">&nbsp;</td>
                </tr>
                <tr>
                  <td>&nbsp;</td>
                  <td width="19%" class="write">用户名：</td>
                  <td width="43%"><asp:TextBox ID="TbUsername"  class="input_4" runat="server"></asp:TextBox>
                                                    </td>
                  <td width="28%"><%--<input name="button" type="submit" class="but_login" id="button" value="登录">--%><asp:Button 
                          ID="loginButton" class="but_login"  runat="server" Text="登录"  onclick="loginButton_Click"/>
                      <%--<asp:ImageButton ID="loginButton" runat="server" ImageUrl="img/ok.png" 
                                    onclick="loginButton_Click" Height="27px" Width="62px" />--%>
							                        </td>
                  <td width="3%">&nbsp;</td>
                </tr>
                <tr>
                  <td>&nbsp;</td>
                  <td valign="top" class="write">密　码：</td>
                  <td valign="top"><asp:TextBox ID="TbUserpass"  runat="server"  class="input_4" TextMode="Password"></asp:TextBox>
                                                    </td>
                  <td valign="top"><%--<input name="button2" type="submit" class="but_login" id="button2" value="取消">--%><%--<span class="button"><img src="./img/reset.png" onclick="goTarget('welcome.htm')"></span>--%><input 
                          id="Reset1" type="button" onclick='document.getElementById("TbUsername").value="";document.getElementById("TbUserpass").value="";' value="取消" class="but_login"/></td>
                  <td valign="top">&nbsp;</td>
                </tr>
                <tr>
                  <td>&nbsp;</td>
                  <td colspan="4" valign="top">&nbsp;</td>
                </tr>
                <tr>
                  <td width="7%">&nbsp;</td>
                  <td colspan="4" valign="top">&nbsp;</td>
                </tr>
            </table></form></td>
            <td width="54">&nbsp;</td>
          </tr>
          <tr>
            <td colspan="3">&nbsp;</td>
          </tr>
        </table></td>
        <td width="736" align="left" background="main/image/login_bg1.jpg">&nbsp;</td>
      </tr>
    </table></td>
  </tr>
</table>

<script type="text/javascript">
window.moveTo(0,0);
window.resizeTo(screen.width,screen.height);
</script>
</BODY>
</HTML>
