<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConfigDataBase.aspx.cs" Inherits="Admin_DataBaseConfig" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>设置连接HIS,LIS等数据库配置[版本v3]</title>
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
            <asp:Button ID="hisConn" runat ="server" Text="显示HIS配置连接信息" onclick="hisConn_Click"/>
            <asp:Button ID="Button1" runat ="server" Text="显示HIS配置URL信息" onclick="hisConnurl_Click"/>
            <asp:Button ID="lisConn" runat ="server" Text="显示LIS配置连接信息" onclick="lisConn_Click"/>
            <asp:Button ID="pacsConn" runat ="server" Text="显示PACS配置连接信息" onclick="pacsConn_Click"/>
            <asp:Button ID="pisConn" runat ="server" Text="显示PIS配置连接信息" onclick="pisConn_Click"/>
            <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="uidData">
                <ProgressTemplate><asp:Label ID="Label1" runat="server" Text="正在处理数据......"></asp:Label></ProgressTemplate>
            </asp:UpdateProgress>
         </div>
         <div style="float:none">
             <fieldset>
             <legend>显示连接信息</legend>
             <div>
                <asp:TextBox id="datalogsHis" runat="server" TextMode="SingleLine" ForeColor="Red" Text="未测试,显示HIS配置连接信息!"  BorderWidth="2" ReadOnly = "true" Enabled = "false" Width="512"></asp:TextBox><br />
                <asp:TextBox id="datalogsHisWebUrl" runat="server" TextMode="SingleLine" ForeColor="Red" Text="未测试,显示HIS配置WebService连接信息!"  BorderWidth="2" ReadOnly = "true" Enabled = "false" Width="512"></asp:TextBox><br />
            </div>
            <div>
                <div class="style1">说明: HIS地址配置有数据库配置和WebServices配置</div>
                <div class="style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;两种只能一种有效!(暂时webServices支持HIS为:上海复高 北京东华合创)</div>
                <asp:TextBox id="datalogsLis" runat="server" TextMode="SingleLine" ForeColor="Red" Text="未测试,显示LIS配置连接信息!"  BorderWidth="2" ReadOnly = "true" Enabled = "false" Width="512"></asp:TextBox><br />
                <asp:TextBox id="datalogsPacs" runat="server" TextMode="SingleLine" ForeColor="Red" Text="未测试,显示PACS配置连接信息!"  BorderWidth="2" ReadOnly = "true" Enabled = "false" Width="512"></asp:TextBox><br />
                <asp:TextBox id="datalogsPis" runat="server" TextMode="SingleLine" ForeColor="Red" Text="未测试,显示PIS配置连接信息!"  BorderWidth="2" ReadOnly = "true" Enabled = "false" Width="512"></asp:TextBox><br />
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
