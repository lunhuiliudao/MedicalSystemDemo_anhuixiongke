<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Manage_index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>��ѯ����������v3</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="float:none">
         <fieldset>
         <legend>����DoCare������Ϣ</legend>
          <asp:Label ID="Label8" Text = "����Docare��������ʽ :   " runat = "server"></asp:Label>
          <asp:Label ID="DocareAttendMode" Text = "0" runat = "server"></asp:Label>
          <br />
          <asp:Label ID="Label4" Text = "�������� :   " runat = "server"></asp:Label>
          <asp:Label ID="DocareConnInfo" Text = "0" runat = "server"></asp:Label>
          <br />
          <asp:Button ID="DocareTest" runat ="server" Text="DoCare���Ӳ���" 
                     onclick="DocareTest_Click" Width="180px" />
          <br />
          <asp:Label ID="Label6" Text = "���鴦��ʽ :   " runat = "server"></asp:Label>
          <asp:Label ID="DocareAdviceMode" Text = "0" runat = "server"></asp:Label>
         </fieldset>
     </div>
     <div style="float:none">
         <fieldset>
         <legend>����HIS������Ϣ</legend>
          <asp:Label ID="Label1" Text = "֧��ҽԺHIS��������ʽ :   " runat = "server"></asp:Label>
          <asp:Label ID="HISAttendMode" Text = " 1" runat = "server"></asp:Label>
          <br />
          <asp:Label ID="Label9" Text = "�������� :   " runat = "server"></asp:Label>
          <asp:Label ID="HISConnInfo" Text = "0" runat = "server"></asp:Label>
          <br />
          <asp:Button ID="HISTest" runat ="server" Text="HIS--���Ӳ���" onclick="HISTest_Click" 
                     Width="180px" />
          <br />
          <asp:Label ID="Label15" Text = "���鴦��ʽ :   " runat = "server"></asp:Label>
          <asp:Label ID="HISAdviceMode" Text = "0" runat = "server"></asp:Label>
          </fieldset>
     </div>
     <div style="float:none">
         <fieldset>
         <legend>����LIS������Ϣ</legend>
          <asp:Label ID="Label2" Text = "֧��ҽԺLIS��������ʽ :   " runat = "server"></asp:Label> 
          <asp:Label ID="LISAttendMode" Text = "2" runat = "server"></asp:Label>
          <br />
          <asp:Label ID="Label11" Text = "�������� :   " runat = "server"></asp:Label>
          <asp:Label ID="LISConnInfo" Text = "0" runat = "server"></asp:Label>
          <br />
          <asp:Button ID="LISTest" runat ="server" Text="LIS--���Ӳ���" onclick="LISTest_Click" 
                     Width="180px"/>
          <br />
          <asp:Label ID="Label17" Text = "���鴦��ʽ :   " runat = "server"></asp:Label>
          <asp:Label ID="LISAdviceMode" Text = "0" runat = "server"></asp:Label>
          </fieldset>
     </div>
     <div style="float:none">
         <fieldset>
         <legend>����PACS������Ϣ</legend>
          <asp:Label ID="Label3" Text = "֧��ҽԺPACS��������ʽ :   " runat = "server"></asp:Label>
          <asp:Label ID="PACSAttendMode" Text = "3" runat = "server"></asp:Label>
          <br />
          <asp:Label ID="Label13" Text = "�������� :   " runat = "server"></asp:Label>
          <asp:Label ID="PACSConnInfo" Text = "0" runat = "server"></asp:Label>
          <br />
          <asp:Button ID="PACSTest" runat ="server" Text="PACS���Ӳ���" onclick="PACSTest_Click" 
                     Width="180px"/>
          <br />
          <asp:Label ID="Label19" Text = "���鴦��ʽ :   " runat = "server"></asp:Label>
          <asp:Label ID="PACSAdviceMode" Text = "0" runat = "server"></asp:Label>
         </fieldset>
     </div>
    </form>
</body>
</html>
