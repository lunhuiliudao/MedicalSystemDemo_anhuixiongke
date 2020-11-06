<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GuanYuVerion.aspx.cs" Inherits="Admin_GuanYuVerion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>关于接口程序版本</title>
    <style>
    body{font-family:Arial, Verdana;font-size:10pt;background-color: #F1F3F5;}
    h1{font-family:Arial, Verdana;font-size:10pt;font-weight:bold;color:maroon}
    h2{font-family:Arial, Verdana;font-size:10pt;font-weight:bold;text-decoration:underline}
    h3{font-family:Arial, Verdana;font-size:10pt;font-weight:bold;text-decoration:underline}
    h4{font-family:Arial, Verdana;font-size:10pt;font-weight:bold;text-decoration:underline}
    h5{font-family:Arial, Verdana;font-size:10pt;font-weight:bold;text-decoration:underline}
    </style>
</head>
<body>
<form id="form1" runat="server">
    <div>
        < <asp:LinkButton ID="forInfo1" runat="server" Text ="后台业务配置管理"  onclick="forInfo1_Click"></asp:LinkButton> >
        < <asp:LinkButton ID="dataConn1" runat="server" Text ="系统配置管理"  onclick="dataConn1_Click"></asp:LinkButton> >
        < <asp:LinkButton ID ="guanyu1" runat="server" Text ="查看HIS提取信息" onclick="guanyu1_Click"></asp:LinkButton> >
    </div>
    <h1>版本说明-支持医院信息</h1>
    <h2>Version 3.2.3 FINAL </h2>
    <ul>
       <li>上海曙光医院v2 日期：2009-04-15</li> 
       <li>程序里面使用了一个循环提取数据提高效率</li>
       <li>HIS：上海复高 方式：WebServer调用</li> 
       <li>LIS：奇效 方式：中间表试图调用</li> 
       <li>PACS：东软 方式：PACS提供DLL动态库</li>
    </ul>
    <h3>Version 3.2.2 FINAL </h3>
    <ul>
       <li>安徽省立医院 日期：2009-02-12</li> 
       <li>HIS：北京东华合创 方式：WebServer调用</li> 
       <li>LIS：北京东华合创 方式：WebServer调用</li> 
       <li>PACS：北京东华合创 方式：exe调用</li> 
    </ul>
    <h4>Version 3.2.1 FINAL </h4>
    <ul>
       <li>上海曙光医院 日期：2009-01-12</li> 
       <li>HIS：上海复高 方式：WebServer调用</li> 
       <li>LIS：奇效 方式：中间表试图调用</li> 
    </ul>
    <h5>Version 3.2.0 FINAL </h5>
    <ul>
       <li>252医院 日期：2008-12-12</li> 
       <li>HIS：军字一号 方式：直接军惠表结构访问调用</li> 
       <li>LIS：军字一号 方式：创建数据链路同义词调用</li> 
       <li>检查：军字一号 方式：创建数据链路同义词调用</li> 
       <li>电子病历：军字一号 方式：创建数据链路同义词调用</li> 
    </ul>
</form>
</body>
</html>
