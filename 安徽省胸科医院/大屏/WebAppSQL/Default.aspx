<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SQL到实体的转化</title>
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%">
        <tr>
            <td width="60px">SQL:</td>
            <td><asp:TextBox ID="txtSql" runat="server" TextMode="MultiLine" Width="100%" Rows="6"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnSave" runat="server" Text="生成" onclick="btnSave_Click" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
