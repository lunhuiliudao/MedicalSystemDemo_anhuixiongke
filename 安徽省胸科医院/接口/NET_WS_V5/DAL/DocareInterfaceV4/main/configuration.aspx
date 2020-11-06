<%@ Page Language="C#" AutoEventWireup="true" CodeFile="configuration.aspx.cs" Inherits="Emr_bs.main.configuration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
<HEAD>
<TITLE>修改密码</TITLE>
<style>
    .but{
	width:61px;
	height:24px;
	float:none;
	font-family: "宋体";
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
<meta name="description" content="检索数据" />
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
	  alert("愿密码不能为空");
	  document.getElementById("TbOldPass").focus();
	  return false;
	  
	  }else if(newPass.length<3)
	  {
	  alert("新密码长度不能少于3位！");
	  document.getElementById("TbNewPass").focus();
	  return false;
	  }
	  else if(newPass!=anewPass)
	  {
	  alert("两次新密码不一致");
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
			<span style="padding-left:30px; padding-top:0px; height :100%">修改密码</span>
		</td>
	</tr>
	<tr>
		<td class="content" valign="top">
		<div style="width:100%;height:100%;overflow:auto;">
			<table style="width:100%;height:100%;" border="1" bordercolor="#93B6E3" cellspacing="0" cellpadding="0" class="fromTable">
				<tr>
					<td class="style2">愿密码：</td>
					<td class="style1">
                        <asp:TextBox ID="TbOldPass" runat="server" Width="304px" TextMode="Password"></asp:TextBox>
                            </td>
					<td width="10%">&nbsp;</td>
				</tr>
				<tr>
					<td class="style2">新密码：</td>
					<td class="style1">
                        <asp:TextBox ID="TbNewPass" runat="server" Width="303px" TextMode="Password"></asp:TextBox>
                    </td>	
					<td width="10%">&nbsp;</td>
				</tr>
                <tr>
					<td class="style2">再次输入新密码：</td>
					<td class="style1">
					    <asp:TextBox ID="TbAPass" runat="server" Width="301px" TextMode="Password"></asp:TextBox>
                    </td>	
                    <td width="10%"> &nbsp;</td>
				</tr>
				<tr>								
					<td align="center" valign="middle" colspan="3">
                        <asp:Button ID="BtUpdate" runat="server" Text="修改密码" CssClass="but" 
                            onclick="BtUpdate_Click" />
                        <input id="Reset1" type="reset" value="重置" class="but" /></td>
				</tr>
				<tr>								
                    <td align="center" valign="middle" colspan="3">
                        <a href="../ocx/PDF浏览控件.rar" target="_blank">手动下载电子病历PDF浏览控件</a>
                    </td>
				</tr>
				<tr>								
                    <td class="style2">备注：</td>
                    <td class="style2">医疗文书如果显示不清晰,请根据实际大小修改main/chaKanBingLi.aspx 和 main/Patient_history.aspx
                                        修改里面的width="100%" height="100%" frameborder="0"  src="welcomePage.htm"
                                        width="2000" height="100%" frameborder="0"  src="welcomePage.htm" 这里的2000就是你修改的地方
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
