<%@ Page Language="C#" AutoEventWireup="true" CodeFile="defaultSubClassB.aspx.cs" Inherits="DoCareEmr.defaultSubClassB" %>
<%@ Register assembly="InitDocare" namespace="InitDocare" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<HTML>
<HEAD>
<TITLE>医疗文书信息</TITLE>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<meta http-equiv="Content-Language" content="zh-CN"/>
<meta content="all" name="robots" /> 
<meta name="author" content="sj" />
<meta name="Copyright" content="sj" />
<meta name="description" content="床位信息" />
<link rel="stylesheet" href="../css/pageStyle.css" type="text/css"/>
<script src="../public/public.js"></script>
<script src="../public/date.js"></script>
        <style type="text/css">
            .style1
            {
                width: 12%;
            }
            .style2
            {
                width: 10%;
            }
            .style3
            {
                width: 25%;
            }
        </style>
</HEAD>
<script>
function search(){
	//document.getElementById("data1").style.display = "inline";
	//window.location.href = "mubiaoguanlichaxun.html";
}	
function showinfo(){
	showModalDialog('showinfo.htm',window,'dialogwidth=640px; dialogheight=370px; status=no; help=no');
}
function dolocation()
{
    return false;
}
</script>
<BODY>
    <form id="form1" runat="server">
<table cellspacing="0" cellpadding="0" border="0" class="framePageTab">
	<tr>
		<td class="header">
			<span></span>
		</td>
	</tr>
	<tr>
		<td class="content" valign="top">
			<table cellspacing="0" cellpadding="0" border="0" class="blockStyle" style="height:35%;margin-top:5px">
				<tr>
					 <td class="blockStyle_header">
						<span class="title">档案分类查询B</span>
						<span class="trail">&nbsp;</span>
						<span class="tool">&nbsp;</span>
					</td>
			   </tr>
			   <tr>
					<td class="content" valign="top" align="left">
						<div style="width:100%;height:100%;overflow:auto;">
						<table border="1" bordercolor="#93B6E3" cellspacing="0" cellpadding="0" class="fromTable">
							<tr>
								<td class="style1">病人PATIENTID：</td>
								<td width="10%">
                                    <asp:TextBox ID="TbPatient_ID" runat="server" Width="111px" ></asp:TextBox>
                                </td>
                                <td class="style2">病人VISTID：</td>
								<td width="10%">
                                    <asp:TextBox ID="TbVisit_ID" runat="server" Width="111px" ></asp:TextBox>
                                </td>	
                                <td width="4%">类别:</td>
								<td class="style1">
                                    <asp:RadioButton ID="RBanes" Text="麻醉" GroupName="anesmgr" Checked="true"  runat="server" />
                                    <asp:RadioButton ID="RBicu" Text="重症" GroupName="icumgr" runat="server" />
                                </td>	
                                <td class="style3">归档主键(麻醉[手术序号]重症[日期])：</td>
							    <td width="30%"> 
							        <asp:TextBox ID="TbARCHIVE_KEY" runat="server" Width="111px"></asp:TextBox>
                                </td>	
							</tr>
							
							<tr>								
								<td align="center" valign="middle" colspan="8">
								   <asp:Button  ID="BtSearch" runat="server" Text="查询" CssClass="buttonStyle2" onclick="BtSearch_Click" /> 
                                 </td>
							</tr>
						
						</table>
						</div>
					</td>
				</tr>
			</table>
			<table cellspacing="0" cellpadding="0" border="0" class="blockStyle" style="height:65%">
				
				<tr>
					 <td class="blockStyle_header">
						<span class="title">档案列表B</span>
						<span class="trail">&nbsp;</span>
					</td>
			   </tr>
			   <tr>
					<td class="content" valign="top" align="left">
						<div style="width:100%;height:100%;overflow:auto">
							<table cellspacing="0" cellpadding="0" class="listStyle" >
							<tr><td>
							<div style="width:100%;height:100%;overflow:auto">
							<asp:Repeater ID="ListDataView" runat="server"> 
							<HeaderTemplate>
							<table border="1" bordercolor="#93B6E3" cellspacing="0" cellpadding="0" class="listTab">
								<colgroup>
									<col align="center" width="12"/>
									<col align="left" width="80"/>
									<col align="center" width="60"/>
									<col align="left" width="60"/>
									<col align="center" width="60"/>
									<col align="center" width="80"/>
									<col align="center" width="60"/>						
								</colgroup>
								<thead>
										<tr><td width="12%" class="theadStyle">患者PATIENTID</td>
										<td width="12%" class="theadStyle">患者VISITID</td>
										<td width="11%" class="theadStyle">姓名</td>
										<td width="8%" class="theadStyle">性别</td>
										<td width="10%" class="theadStyle">归档类别</td>
										<td width="13%" class="theadStyle">归档主键</td>
										<td width="13%" class="theadStyle">归档时间</td>
										<td width="31%" class="theadStyle" align="center">管理</td>
								</thead>
							</HeaderTemplate>
							<ItemTemplate>
							<tbody id="data1">
								<tr>
									<td ><%#Eval("HIS_PATIENT_ID")%></td>
									<td align="center"><%#Eval("HIS_VISIT_ID")%></td>
									<td align="center"><%#Eval("NAME") %></td>
									<td align="center"><%#Eval("SEX") %></td>
									<td><%#Eval("MR_CLASS")%></td>	
									<td><%#Eval("ARCHIVE_KEY")%></td>
									<td><%#Eval("ARCHIVE_DATE_TIME")%></td>
									<td align="center"><a href="Patient_history.aspx?patient_id=<%#Eval("HIS_PATIENT_ID")%>&visit_id=<%#Eval("HIS_VISIT_ID") %>&mr_class=<%#Convert.ToString(Eval("MR_CLASS"))=="麻醉"?("1011"):("1012")%>&his_no="  target="_parent">查看病历</a></td>
								</tr>
							</tbody>
							</ItemTemplate>
							<AlternatingItemTemplate>
							<tbody id="data1">
								<tr style="background:lightblue">
									<td ><%#Eval("HIS_PATIENT_ID")%></td>
									<td align="center"><%#Eval("HIS_VISIT_ID")%></td>
									<td align="center"><%#Eval("NAME") %></td>
									<td align="center"><%#Eval("SEX") %></td>
									<td><%#Eval("MR_CLASS")%></td>	
									<td><%#Eval("ARCHIVE_KEY")%></td>
									<td><%#Eval("ARCHIVE_DATE_TIME")%></td>
									<td align="center"><a href="Patient_history.aspx?patient_id=<%#Eval("HIS_PATIENT_ID")%>&visit_id=<%#Eval("HIS_VISIT_ID") %>&mr_class=<%#Convert.ToString(Eval("MR_CLASS"))=="麻醉"?("1011"):("1012")%>&his_no="  target="_parent">查看病历</a></td>
								</tr>
							</tbody>
							</AlternatingItemTemplate>
							<FooterTemplate>
							</table>
							</FooterTemplate>
							 </asp:Repeater>

							</div>
							</td></tr>
							<tr>
								<td class="pageSetTd" valign="bottom">
                                    <cc1:Pages ID="Pages1" runat="server" />
                                </td>
							</tr>
							</table>
						</div>
					</td>
				</tr>
			</table>
			
		</td>
	</tr>
</table>
</form>
</BODY>
</HTML>