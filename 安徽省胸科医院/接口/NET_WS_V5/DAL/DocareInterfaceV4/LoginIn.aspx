<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginIn.aspx.cs" Inherits="LoginIn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>DoCare接口集成平台登录系统v4</title>
    <link rel="shortcut icon" href="./favicon.ico" type="image/x-icon" /> 
    <style type="text/css">
        body 
        {
	        font-family: Arial, Verdana;
        }
        #load 
        {
	        position:absolute;left:300px;top:110px;width:214px;height:15px;z-index:1;display:none;
        }
        .lanyubk
        {
        	BORDER-RIGHT: #ffffff 1px solid;BORDER-TOP: #ffffff 1px solid;BORDER-LEFT: #ffffff 1px solid;BORDER-BOTTOM: #ffffff 1px solid;
        }
        .lanyuss
        {
        	background-image:url(Admin/admin_bg_1.gif);height:22px;border-color:#FFFFFF;color:#FFFFFF;text-align:center;font-size: 12px;font-style: normal;font-weight:bold;
        }
        .lanyuds
        {
	        background-color: #F1F3F5;
	        height:30px;
        }
        .lanyuqs
        {
        	background-color: #E4EDF9;height:22px;
        }
        .style1
        {
            background-color: #F1F3F5;
            height: 30px;
            width: 165px;
        }
        
        .btn 
        {
            BORDER-RIGHT: #7b9ebd 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #7b9ebd 1px solid; PADDING-LEFT: 2px; FONT-SIZE: 12px; 
            FILTER: progid:DXImageTransform.Microsoft.Gradient(GradientType=0, StartColorStr=#ffffff, EndColorStr=#cecfde); 
            BORDER-LEFT: #7b9ebd 1px solid; CURSOR: hand; COLOR: black; PADDING-TOP: 2px; BORDER-BOTTOM: #7b9ebd 1px solid
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" defaultbutton="loginServer" defaultfocus="loginName">
    <div>
    <table width="480" align="center" class="lanyubk" border="1" cellpadding="0" style="border-collapse: collapse">
    <tr>
        <td  class="lanyuss" align="center" colspan="2">DoCare信息接口管理平台V4</td>
    </tr>
    <tr class="lanyuds">
        <td class="style1" align="right">&nbsp;用 户：</td>
        <td class="lanyuds" width="400" align="left"><asp:TextBox runat="server" ID="loginName"  Width="169px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="requiredName" runat="server" ControlToValidate="loginName" ErrorMessage="用户名不能为空"></asp:RequiredFieldValidator>
                <script language="javascript" type="text/javascript">document.getElementById('loginName').focus();</script></td>
    </tr>
    <tr class="lanyuds">
        <td class="style1" align="right">&nbsp;密 码：</td>
        <td class="lanyuds" width="400" align="left"><asp:TextBox runat="server" ID="loginPwd" 
                TextMode="Password" Width="168px"></asp:TextBox><asp:RequiredFieldValidator ID="requiredPwd" runat="server" ControlToValidate="loginPwd" ErrorMessage="密码不能为空" ></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td class="lanyuqs" align="center" colspan="2">
            <asp:Button runat="server" CssClass = "btn" Text="登录管理平台" ID="loginServer"  OnClick="loginServer_Click" />
            <asp:Button runat="server" CssClass = "btn" Text="登录[WS]服务"   ID="Button2" OnClick="lookWebService_Click" />
        </td>
    </tr>
    <tr>
        <td class="lanyuqs" align="center" colspan="2">
            <asp:Button runat="server" CssClass = "btn" Text="登录电子病历平台" ID="Login_emr" onclick="Login_emr_Click" /> 
            <asp:Button runat="server" CssClass = "btn" Text="查询数据管理平台" ID="Button3" OnClick="MainServer_Click" /> 
        </td>
    </tr>
    </table>
    </form>
</body>
</html>
