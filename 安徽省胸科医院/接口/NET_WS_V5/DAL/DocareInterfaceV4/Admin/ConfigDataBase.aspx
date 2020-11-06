<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConfigDataBase.aspx.cs" Inherits="Admin_DataBaseConfig" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>��������HIS,LIS�����ݿ�����[�汾v3]</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
    <div>
    <div>
        <asp:UpdatePanel ID="uidData"  runat="server" UpdateMode="Conditional">
         <ContentTemplate>
         <div>
            <asp:Button ID="hisConn" runat ="server" Text="��ʾHIS����������Ϣ" onclick="hisConn_Click"/>
            <asp:Button ID="Button1" runat ="server" Text="��ʾHIS����URL��Ϣ" onclick="hisConnurl_Click"/>
            <asp:Button ID="lisConn" runat ="server" Text="��ʾLIS����������Ϣ" onclick="lisConn_Click"/>
            <asp:Button ID="pacsConn" runat ="server" Text="��ʾPACS����������Ϣ" onclick="pacsConn_Click"/>
            <asp:Button ID="pisConn" runat ="server" Text="��ʾPIS����������Ϣ" onclick="pisConn_Click"/>
            <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="uidData">
                <ProgressTemplate><asp:Label ID="Label1" runat="server" Text="���ڴ�������......"></asp:Label></ProgressTemplate>
            </asp:UpdateProgress>
         </div>
         <div style="float:none">
             <fieldset>
             <legend>��ʾ������Ϣ</legend>
             <div>
                <asp:TextBox id="datalogsHis" runat="server" TextMode="SingleLine" ForeColor="Red" Text="δ����,��ʾHIS����������Ϣ!"  BorderWidth="2" ReadOnly = "true" Enabled = "false" Width="512"></asp:TextBox><br />
                <asp:TextBox id="datalogsHisWebUrl" runat="server" TextMode="SingleLine" ForeColor="Red" Text="δ����,��ʾHIS����WebService������Ϣ!"  BorderWidth="2" ReadOnly = "true" Enabled = "false" Width="512"></asp:TextBox><br />
            </div>
            <div>
                <div class="style1">˵��: HIS��ַ���������ݿ����ú�WebServices����</div>
                <div class="style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;����ֻ��һ����Ч!(��ʱwebServices֧��HISΪ:�Ϻ����� ���������ϴ�)</div>
                <asp:TextBox id="datalogsLis" runat="server" TextMode="SingleLine" ForeColor="Red" Text="δ����,��ʾLIS����������Ϣ!"  BorderWidth="2" ReadOnly = "true" Enabled = "false" Width="512"></asp:TextBox><br />
                <asp:TextBox id="datalogsPacs" runat="server" TextMode="SingleLine" ForeColor="Red" Text="δ����,��ʾPACS����������Ϣ!"  BorderWidth="2" ReadOnly = "true" Enabled = "false" Width="512"></asp:TextBox><br />
                <asp:TextBox id="datalogsPis" runat="server" TextMode="SingleLine" ForeColor="Red" Text="δ����,��ʾPIS����������Ϣ!"  BorderWidth="2" ReadOnly = "true" Enabled = "false" Width="512"></asp:TextBox><br />
             </div>
             </fieldset>
         </div>
         </ContentTemplate>
         <Triggers>
                <%--<asp:PostBackTrigger  ControlID="textInfo" />--%>
         </Triggers>
     </asp:UpdatePanel>
    </div>
    
    </div>
    </form>
</body>
</html>
