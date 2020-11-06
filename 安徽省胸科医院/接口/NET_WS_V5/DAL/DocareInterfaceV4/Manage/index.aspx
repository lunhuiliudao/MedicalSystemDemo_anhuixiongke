<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Manage_index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查询数据主程序v3</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="float:none">
         <fieldset>
         <legend>连接DoCare数据信息</legend>
          <asp:Label ID="Label8" Text = "连接Docare服务器方式 :   " runat = "server"></asp:Label>
          <asp:Label ID="DocareAttendMode" Text = "0" runat = "server"></asp:Label>
          <br />
          <asp:Label ID="Label4" Text = "连接内容 :   " runat = "server"></asp:Label>
          <asp:Label ID="DocareConnInfo" Text = "0" runat = "server"></asp:Label>
          <br />
          <asp:Button ID="DocareTest" runat ="server" Text="DoCare连接测试" 
                     onclick="DocareTest_Click" Width="180px" />
          <br />
          <asp:Label ID="Label6" Text = "建议处理方式 :   " runat = "server"></asp:Label>
          <asp:Label ID="DocareAdviceMode" Text = "0" runat = "server"></asp:Label>
         </fieldset>
     </div>
     <div style="float:none">
         <fieldset>
         <legend>连接HIS数据信息</legend>
          <asp:Label ID="Label1" Text = "支持医院HIS服务器方式 :   " runat = "server"></asp:Label>
          <asp:Label ID="HISAttendMode" Text = " 1" runat = "server"></asp:Label>
          <br />
          <asp:Label ID="Label9" Text = "连接内容 :   " runat = "server"></asp:Label>
          <asp:Label ID="HISConnInfo" Text = "0" runat = "server"></asp:Label>
          <br />
          <asp:Button ID="HISTest" runat ="server" Text="HIS--连接测试" onclick="HISTest_Click" 
                     Width="180px" />
          <br />
          <asp:Label ID="Label15" Text = "建议处理方式 :   " runat = "server"></asp:Label>
          <asp:Label ID="HISAdviceMode" Text = "0" runat = "server"></asp:Label>
          </fieldset>
     </div>
     <div style="float:none">
         <fieldset>
         <legend>连接LIS数据信息</legend>
          <asp:Label ID="Label2" Text = "支持医院LIS服务器方式 :   " runat = "server"></asp:Label> 
          <asp:Label ID="LISAttendMode" Text = "2" runat = "server"></asp:Label>
          <br />
          <asp:Label ID="Label11" Text = "连接内容 :   " runat = "server"></asp:Label>
          <asp:Label ID="LISConnInfo" Text = "0" runat = "server"></asp:Label>
          <br />
          <asp:Button ID="LISTest" runat ="server" Text="LIS--连接测试" onclick="LISTest_Click" 
                     Width="180px"/>
          <br />
          <asp:Label ID="Label17" Text = "建议处理方式 :   " runat = "server"></asp:Label>
          <asp:Label ID="LISAdviceMode" Text = "0" runat = "server"></asp:Label>
          </fieldset>
     </div>
     <div style="float:none">
         <fieldset>
         <legend>连接PACS数据信息</legend>
          <asp:Label ID="Label3" Text = "支持医院PACS服务器方式 :   " runat = "server"></asp:Label>
          <asp:Label ID="PACSAttendMode" Text = "3" runat = "server"></asp:Label>
          <br />
          <asp:Label ID="Label13" Text = "连接内容 :   " runat = "server"></asp:Label>
          <asp:Label ID="PACSConnInfo" Text = "0" runat = "server"></asp:Label>
          <br />
          <asp:Button ID="PACSTest" runat ="server" Text="PACS连接测试" onclick="PACSTest_Click" 
                     Width="180px"/>
          <br />
          <asp:Label ID="Label19" Text = "建议处理方式 :   " runat = "server"></asp:Label>
          <asp:Label ID="PACSAdviceMode" Text = "0" runat = "server"></asp:Label>
         </fieldset>
     </div>
    </form>
</body>
</html>
