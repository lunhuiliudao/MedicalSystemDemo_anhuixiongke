<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GuanYuVerion.aspx.cs" Inherits="Admin_GuanYuVerion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>���ڽӿڳ���汾</title>
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
        < <asp:LinkButton ID="forInfo1" runat="server" Text ="��̨ҵ�����ù���"  onclick="forInfo1_Click"></asp:LinkButton> >
        < <asp:LinkButton ID="dataConn1" runat="server" Text ="ϵͳ���ù���"  onclick="dataConn1_Click"></asp:LinkButton> >
        < <asp:LinkButton ID ="guanyu1" runat="server" Text ="�鿴HIS��ȡ��Ϣ" onclick="guanyu1_Click"></asp:LinkButton> >
    </div>
    <h1>�汾˵��-֧��ҽԺ��Ϣ</h1>
    <h2>Version 3.2.3 FINAL </h2>
    <ul>
       <li>�Ϻ����ҽԺv2 ���ڣ�2009-04-15</li> 
       <li>��������ʹ����һ��ѭ����ȡ�������Ч��</li>
       <li>HIS���Ϻ����� ��ʽ��WebServer����</li> 
       <li>LIS����Ч ��ʽ���м����ͼ����</li> 
       <li>PACS������ ��ʽ��PACS�ṩDLL��̬��</li>
    </ul>
    <h3>Version 3.2.2 FINAL </h3>
    <ul>
       <li>����ʡ��ҽԺ ���ڣ�2009-02-12</li> 
       <li>HIS�����������ϴ� ��ʽ��WebServer����</li> 
       <li>LIS�����������ϴ� ��ʽ��WebServer����</li> 
       <li>PACS�����������ϴ� ��ʽ��exe����</li> 
    </ul>
    <h4>Version 3.2.1 FINAL </h4>
    <ul>
       <li>�Ϻ����ҽԺ ���ڣ�2009-01-12</li> 
       <li>HIS���Ϻ����� ��ʽ��WebServer����</li> 
       <li>LIS����Ч ��ʽ���м����ͼ����</li> 
    </ul>
    <h5>Version 3.2.0 FINAL </h5>
    <ul>
       <li>252ҽԺ ���ڣ�2008-12-12</li> 
       <li>HIS������һ�� ��ʽ��ֱ�Ӿ��ݱ�ṹ���ʵ���</li> 
       <li>LIS������һ�� ��ʽ������������·ͬ��ʵ���</li> 
       <li>��飺����һ�� ��ʽ������������·ͬ��ʵ���</li> 
       <li>���Ӳ���������һ�� ��ʽ������������·ͬ��ʵ���</li> 
    </ul>
</form>
</body>
</html>
