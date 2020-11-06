<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Password.aspx.cs" Inherits="Admin_Password" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>修改SSCJ登录用户密码[版本v3]</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="480" align="center" border="1" cellpadding="0">
    <tr>
    <td colspan="2"align="center">修改密码界面</td>
    </tr>
    <tr>
    <td align="right">&nbsp;用 户：</td>
    <td><asp:Label ID="user" runat="server" Text=""></asp:Label></td>
    </tr>
    <tr>
    <td align="right">&nbsp;原密码：</td>
    <td><asp:TextBox ID="oldPwd" runat="server" TextMode="Password"></asp:TextBox></td>
    </tr>
    <tr>
    <td align="right">&nbsp;密 码：</td>
    <td><asp:TextBox ID="pwd" runat="server" TextMode="Password"></asp:TextBox></td>
    </tr>
    <tr>
    <td align="right">&nbsp;确认密码：</td>
    <td><asp:TextBox ID="pwd2" runat="server" TextMode="Password"></asp:TextBox></td>
    </tr>
    <tr>
    <td colspan="2" align="center"><asp:Button ID="save" runat="server" Text="保存" OnClick="save_Click" />&nbsp;&nbsp;<asp:Button ID="cannel" runat="server" Text="取消" OnClick="cannel_Click" /></td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
