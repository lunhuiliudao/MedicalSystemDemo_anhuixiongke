<%@ Page Language="C#" AutoEventWireup="true" CodeFile="configuration.aspx.cs" Inherits="Emr_bs.main.configuration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
<HEAD>
<TITLE>�޸�����</TITLE>
<style>
    .but{
	width:61px;
	height:24px;
	float:none;
	font-family: "����";
	font-size: 12px;
	font-weight: bold;
	color: #354f70;
	text-align:center;
	background-image: url(image/but.jpg);
	border:0px;
    }
</style>
<base target="_parent"/>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<meta http-equiv="Content-Language" content="zh-CN"/>
<meta content="all" name="robots" /> 
<meta name="author" content="sj" />
<meta name="Copyright" content="sj" />
<meta name="description" content="��������" />
<link rel="stylesheet" href="../css/pageStyle.css" type="text/css"/>
<script type="text/javascript" charset="gb2312" src="../public/date.js"></script>

<script>

	
	function checkPass()
	{
	  var oldPass = document.getElementById("TbOldPass").value;
	  var newPass = document.getElementById("TbNewPass").value;
	  var anewPass = ewPass = document.getElementById("TbAPass").value;
	  if(oldPass.length<1)
	  {
	  alert("Ը���벻��Ϊ��");
	  document.getElementById("TbOldPass").focus();
	  return false;
	  
	  }else if(newPass.length<3)
	  {
	  alert("�����볤�Ȳ�������3λ��");
	  document.getElementById("TbNewPass").focus();
	  return false;
	  }
	  else if(newPass!=anewPass)
	  {
	  alert("���������벻һ��");
	    document.getElementById("TbNewPass").focus();
	  return false;
	  }
	  return true;
	  
	  
	}
</script>
    <style type="text/css">
        .style1
        {
            width: 37%;
        }
        .style2
        {
            width: 16%;
        }
    </style>
</HEAD>
<body>
    <form id="form1" runat="server">
<table cellspacing="0" cellpadding="0" border="0" class="framePageTab">
	<tr>
		<td class="header">
			<span style="padding-left:30px; padding-top:0px; height :100%">�޸�����</span>
		</td>
	</tr>
	<tr>
		<td class="content" valign="top">
		<div style="width:100%;height:100%;overflow:auto;">
			<table style="width:100%;height:100%;" border="1" bordercolor="#93B6E3" cellspacing="0" cellpadding="0" class="fromTable">
				<tr>
					<td class="style2">Ը���룺</td>
					<td class="style1">
                        <asp:TextBox ID="TbOldPass" runat="server" Width="304px" TextMode="Password"></asp:TextBox>
                            </td>
					<td width="10%">&nbsp;</td>
				</tr>
				<tr>
					<td class="style2">�����룺</td>
					<td class="style1">
                        <asp:TextBox ID="TbNewPass" runat="server" Width="303px" TextMode="Password"></asp:TextBox>
                    </td>	
					<td width="10%">&nbsp;</td>
				</tr>
                <tr>
					<td class="style2">�ٴ����������룺</td>
					<td class="style1">
					    <asp:TextBox ID="TbAPass" runat="server" Width="301px" TextMode="Password"></asp:TextBox>
                    </td>	
                    <td width="10%"> &nbsp;</td>
				</tr>
				<tr>								
					<td align="center" valign="middle" colspan="3">
                        <asp:Button ID="BtUpdate" runat="server" Text="�޸�����" CssClass="but" 
                            onclick="BtUpdate_Click" />
                        <input id="Reset1" type="reset" value="����" class="but" /></td>
				</tr>
				<tr>								
                    <td align="center" valign="middle" colspan="3">
                        <a href="../ocx/PDF����ؼ�.rar" target="_blank">�ֶ����ص��Ӳ���PDF����ؼ�</a>
                    </td>
				</tr>
				<tr>								
                    <td class="style2">��ע��</td>
                    <td class="style2">ҽ�����������ʾ������,�����ʵ�ʴ�С�޸�main/chaKanBingLi.aspx �� main/Patient_history.aspx
                                        �޸������width="100%" height="100%" frameborder="0"  src="welcomePage.htm"
                                        width="2000" height="100%" frameborder="0"  src="welcomePage.htm" �����2000�������޸ĵĵط�
                    </td>
				</tr>
			</table>
		</div>
		</td>
			</tr>
			</table>		
			</form>
			

</BODY>
</HTML>
