<%@ Page Language="C#" AutoEventWireup="true" ResponseEncoding="gb2312" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<link rel="shortcut icon" href="../favicon.ico" type="image/x-icon" /> 
<link href="./StyleSheet.css" rel="stylesheet" type="text/css" />
<script language="JavaScript" type="text/javascript" src="./JScript.js"></script>
<script language="JavaScript" type="text/javascript" src="./JScriptAnes.js"></script>
<script language="JavaScript" type="text/javascript" src="./JScriptIcu.js"></script>
<script language="JavaScript" type="text/javascript" src="./JScriptXML.js"></script>
<title>DoCare信息接口管理平台V4</title>
</head>
<body  id="Indexbody" onLoad ="inita()" style="font-size: 14px; font-family: 宋体; background-color: #F1F3F5; font-style: normal;"> 
    <form id="form1" runat="server" defaultbutton="textInfo" >
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Services>
            <asp:ServiceReference Path="../WebServices.asmx" />
        </Services>
        <Services>
            <asp:ServiceReference Path="../DocareTrunDataService.asmx" />
        </Services>
    </asp:ScriptManager>
    <fieldset>
    <legend>用户控制信息</legend>
    <div>
        < <asp:LinkButton ID="forInfo" runat="server" Text ="查看HIS提取信息"  onclick="forInfo_Click"></asp:LinkButton> >
        < <asp:LinkButton ID="dataConn" runat="server" Text ="测试TRANS配置"  
            onclick="dataConn_Click"></asp:LinkButton> >&lt; <asp:LinkButton ID="PZ_trans" 
            runat="server" Text ="配置TRANS信息"  onclick="PZ_trans_Click"></asp:LinkButton> 
        &gt;
        < <asp:LinkButton ID="loginInEmr" runat="server" Text ="测试查看电子病历" onclick="loginInEmr_Click" ></asp:LinkButton> >
        < <asp:LinkButton ID="LinkButton1" runat="server" Text ="DoCare系统提供WebServices"  onclick="WebServices_Click"></asp:LinkButton> >
        < <asp:LinkButton ID ="guanyu" runat="server" Text ="关于版本V2.1.3" onclick="guanyu_Click"></asp:LinkButton> >
    </div>
    <div align="left" >
        <asp:Button runat="server" ID="zhuxiao" Text="退出" OnClick="zhuxiao_Click" />
        当前DoCare系统登录平台用户: <asp:Label runat="server" ID="loginName" Text="管理员"></asp:Label>&nbsp;&nbsp;&nbsp;
        <asp:LinkButton runat="server" ID="password" Text="修改密码" OnClick="password_Click"></asp:LinkButton>&nbsp;&nbsp;&nbsp;
    </div>
    </fieldset>

    <fieldset>
    <legend>配置DoCare数据库</legend>
    <div align="left" style="float:left;width:516; height: 100%;">
        <asp:DetailsView ID="DetailsView1" runat="server" Width="575px"  FieldHeaderStyle-Width="175px" FieldHeaderStyle-Height="20px" 
        GridLines="None" AutoGenerateRows="False"
        AutoGenerateEditButton="True"  OnModeChanging="DetailsView1_ModeChanging" 
        OnItemUpdated="DetailsView1_ItemUpdated"  OnItemCreated="DetailsView1_ItemCreated"
            OnItemUpdating ="DetailsView1_ItemUpdating" EnableViewState="False">
        <Fields>
        <asp:TemplateField>
                <HeaderTemplate>选择HIS数据库类型</HeaderTemplate>
                <ItemTemplate><asp:Label runat="server" ID="HISDataServerType" Text='<%# Bind("HISDataServerType") %>'></asp:Label></ItemTemplate>
                <EditItemTemplate><asp:DropDownList runat="server" Width="80%" ID="DataServerType2" Text = '<%# Bind("HISDataServerType") %>' ></asp:DropDownList></EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>选择Docare数据库类型</HeaderTemplate>
                <ItemTemplate><asp:Label runat="server" ID="DataServerType" Text='<%# Bind("DataServerType") %>'></asp:Label></ItemTemplate>
                <EditItemTemplate><asp:DropDownList runat="server" Width="80%" ID="DataServerType3" Text = '<%# Bind("DataServerType") %>' ></asp:DropDownList></EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>DoCare服务名</HeaderTemplate>
                <ItemTemplate><asp:Label runat="server" ID="serverName" Text='<%# Bind("ServerName") %>'></asp:Label></ItemTemplate>
                <EditItemTemplate><asp:TextBox runat="server" ReadOnly="false" Width="80%" ID="serverName2" Text='<% #Bind("ServerName") %>'></asp:TextBox></EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>服务目录</HeaderTemplate>
                <ItemTemplate><asp:Label runat="server" ID="Catalog" Text='<%# Bind("Catalog") %>'></asp:Label></ItemTemplate>
                <EditItemTemplate><asp:TextBox runat="server" ReadOnly="false" Width="80%" ID="Catalog2" Text='<% #Bind("Catalog") %>'></asp:TextBox></EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>登录用户</HeaderTemplate>
                <ItemTemplate><asp:Label runat="server" ID="ServerLogin" Text='<%# Bind("ServerLogin") %>'></asp:Label></ItemTemplate>
                <EditItemTemplate><asp:TextBox runat="server" ReadOnly="false" Width="80%" ID="ServerLogin2" Text='<% #Bind("ServerLogin") %>'></asp:TextBox></EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>登录密码</HeaderTemplate>
                <ItemTemplate><asp:Label runat="server" ID="ServerPwd" Text="********" ></asp:Label></ItemTemplate>
                <EditItemTemplate><asp:TextBox runat="server" Width="80%"  ID="ServerPwd2" TextMode ="Password" Text='<% # Bind("ServerPwd") %>' ></asp:TextBox></EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>程序标题</HeaderTemplate>
                <ItemTemplate><asp:Label runat="server" ID="Title" Text='<%# Bind("Title") %>'></asp:Label></ItemTemplate>
                <EditItemTemplate><asp:TextBox runat="server" ReadOnly="false" Width="80%" ID="Title2" Text='<% #Bind("Title") %>'></asp:TextBox></EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>集成平台WebServices地址(获取)</HeaderTemplate>
                <ItemTemplate><asp:Label runat="server" ID="wsurlGet" Text='<%# Bind("WebServerUrlGet") %>'></asp:Label></ItemTemplate>
                <EditItemTemplate><asp:TextBox runat="server" ReadOnly="false" Width="80%" ID="wsurlGet" Text='<% #Bind("WebServerUrlGet") %>'></asp:TextBox></EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>集成平台WebServices地址(回写)</HeaderTemplate>
                <ItemTemplate><asp:Label runat="server" ID="wsurlSet" Text='<%# Bind("WebServerUrlSet") %>'></asp:Label></ItemTemplate>
                <EditItemTemplate><asp:TextBox runat="server" ReadOnly="false" Width="80%" ID="wsurlSet" Text='<% #Bind("WebServerUrlSet") %>'></asp:TextBox></EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>HIS地址(WebServices)</HeaderTemplate>
                <ItemTemplate><asp:Label runat="server" ID="wsurl" Text='<%# Bind("WebServerUrl") %>'></asp:Label></ItemTemplate>
                <EditItemTemplate><asp:TextBox runat="server" ReadOnly="false" Width="80%" ID="wsurl2" Text='<% #Bind("WebServerUrl") %>'></asp:TextBox></EditItemTemplate>
            </asp:TemplateField>
            
        </Fields>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />   
        <CommandRowStyle BackColor="#FFFFC0" Font-Bold="True" />   
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />   
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />   
        <FieldHeaderStyle BackColor="#FFFF99" Font-Bold="True" />   
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />   
        <AlternatingRowStyle BackColor="White" />  
        </asp:DetailsView>
        <div class="style1">说明: HIS地址配置只为HIS方面提供WebServices服务时使用,</div>
        <div class="style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;如果HIS未提供可以为空</div>
    </div>
    
    <div align="left" style="float:left;width:516; height: 100%;">
     <asp:UpdatePanel ID="uid"  runat="server" UpdateMode="Conditional">
     <ContentTemplate>
     <div>
        <asp:Button ID="textInfo" runat ="server" Text="测试RUN_CONFIG配置" 
             onclick="textInfo_Click"/>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="uid">
            <ProgressTemplate><asp:Label ID="Label0" runat="server" Text="正在处理数据......"></asp:Label></ProgressTemplate>
        </asp:UpdateProgress>
     </div>
     <div style="float:none">
         <fieldset>
         <legend>显示配置信息</legend>
         <div>
            <asp:Label ID="Label91" Text = "系统1:" runat = "server"></asp:Label>
            <asp:TextBox id="system1" runat="server" TextMode="SingleLine" Text="ANESMGR"></asp:TextBox>
            <asp:Label ID="Label14" Text = "系统2:" runat = "server" ></asp:Label>
            <asp:TextBox id="system2" runat="server" TextMode="SingleLine" Text="ICUMGR"></asp:TextBox>
            <asp:Label ID="Label15" Text = "发送XML:" runat = "server" ></asp:Label>
            <asp:TextBox id="systemXML" runat="server" TextMode="SingleLine" Text="ICUMGR"></asp:TextBox>
         </div>
         <div>
            <asp:TextBox id="datalogs" runat="server" TextMode="SingleLine" ForeColor="Red" Text="未测试,请点击[显示DoCare配置信息]等按钮!"  BorderWidth="2" ReadOnly = "true" Enabled = "false" Width="512"></asp:TextBox>
         </div>
         </fieldset>
     </div>
     <div style="float:none">
        <div align="left" style="float:left;width:256;">
            <fieldset>
            <legend>DoCare-系统1信息</legend>
            <div>
                <asp:Label ID="Label8" Text = "支持医院HIS信息 :" runat = "server"></asp:Label><br />
                <asp:TextBox id="aneshisSupply" runat="server" TextMode="SingleLine" BorderWidth="2" ReadOnly = "true" Enabled = "false" Width="256"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label10" Text = "支持医嘱信息:" runat = "server"></asp:Label><br />
                <asp:TextBox id="anesorders" runat="server" TextMode="SingleLine" BorderWidth="2" ReadOnly = "true" Enabled = "false" Width="256"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label11" Text = "支持检验信息 :" runat = "server"></asp:Label><br />
                <asp:TextBox id="aneslis" runat="server" TextMode="SingleLine" BorderWidth="2" ReadOnly = "true" Enabled = "false" Width="256"></asp:TextBox>
            </div>
            </fieldset>
        </div>
        <div align="left" style="float:left;width:256;">
            <fieldset>
            <legend>DoCare-系统2信息</legend>
            <div>
                <asp:Label ID="Label7" Text = "支持医院HIS信息 :" runat = "server"></asp:Label><br />
                <asp:TextBox id="icuhisSupply" runat="server" TextMode="SingleLine" BorderWidth="2" ReadOnly = "true" Enabled = "false" Width="256"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label12" Text = "支持医嘱信息:" runat = "server"></asp:Label><br />
                <asp:TextBox id="icuorders" runat="server" TextMode="SingleLine" BorderWidth="2" ReadOnly = "true" Enabled = "false" Width="256"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label13" Text = "支持检验信息 :" runat = "server"></asp:Label><br />
                <asp:TextBox id="iculis" runat="server" TextMode="SingleLine" BorderWidth="2" ReadOnly = "true" Enabled = "false" Width="256"></asp:TextBox>
            </div>
            </fieldset>
        </div>
     </div>

     </ContentTemplate>
     <Triggers>
            <asp:AsyncPostBackTrigger    ControlID="textInfo" />
            <%--<asp:PostBackTrigger  ControlID="textInfo" />--%>
     </Triggers>
     </asp:UpdatePanel>
    </div>
    
    </fieldset>

    <fieldset>
    <legend>DoCare系统应用功能--系统</legend>
    <div>
       <div align="left" style="float:left;width:516; height: 100%;">
         <div>
            <fieldset>
            <legend>DoCare基础数据控制 :(对运行数据有影响)</legend>
            <div style="float:left;width:516;" >
                <div>
                    <input id="PtLogOn" type = "button" value ="集成平台登陆" onclick = "GetLogOn()"/>               
                </div>
                <div>
                    <input id="renyuan" type = "button" value ="麻醉同步HIS人员信息" onclick = "GetHisUsers()"/>
                    <input id="keshi" type = "button" value ="麻醉同步HIS科室信息" onclick = "GetDeptDict()"/>
                </div>
                <div>
                    <input id="renyuanICU" type = "button" value ="ICU同步HIS人员信息" onclick = "GetICUHisUsers()"/>
                    <input id="keshiICU" type = "button" value ="ICU同步HIS科室信息" onclick = "GetICUDeptDict()"/>
                </div>
                <div>
                    <input id="operaitonDict" type = "button" value ="麻醉同步HIS手术名称" onclick = "GetOperationDict()"/>
                    <input id="PriceDict" type = "button" value ="麻醉同步HIS诊断字典信息" onclick = "GetDiagnosis()"/>
                </div>
                <div>
                    <input id="Drugdict" type = "button" value ="麻醉同步HIS药品字典" onclick = "GetDrugdict()"/>
                    <input id="Mtrldict" type = "button" value ="麻醉同步HIS耗材字典" onclick = "GetMtrldict()"/>
                </div>
                <div>
                    <input id="DrugNameDict" type = "button" value ="麻醉同步HIS药品名称" onclick = "GetDrugNameDict()"/>
                    <input id="MtrlSupplierCatalog" type = "button" value ="麻醉同步HIS耗材供应商" onclick = "GetMtrlSupplierCatalog()"/>
                </div>
            </div>

            </fieldset>
            
         </div>
         
         
         
         <div align="left" style="float:left;width:256">
         <fieldset>
            <legend>麻醉业务数据控制:</legend>
            <div>
                <input id="DeptSchedules" type = "button" value ="同步手术预约信息" onclick = "GetDeptOperationSchedules()"/>
            </div>
            <div>
                <input id="selectPatientID" type = "button" value ="ID号同步病人信息" onclick = "GetPatientIDInfo()" />
            </div>
            <div>
                <input id="PatientInpNo" type = "button" value ="住院号同步病人信息" onclick = "GetPatientInpNoInfo()" />
            </div>
            <div>
                <input id="selectPatientOrders" type = "button" value ="ID号同步病人医嘱信息" onclick = "GetPatientOrdersInfo()"/>
            </div>
            <div>
                <input id="selectPatientOrdersDate" type = "button" value ="ID号时间段医嘱信息" onclick = "GetPatientOrdersInfoOnDate()"/>
            </div>
            <div>
                <input id="selectPatientLabMaster" type = "button" value ="ID号同步病人检验信息" onclick = "GetLabMaster()"/>
            </div>
            <div>
                <input id="setOperationState" type = "button" value ="回写手术状态信息" onclick = "CopyBackOperationState()"/>
            </div>
            <div>
                <input id="CopyBackOperationChancelBtn" type = "button" value ="回写手术取消信息" onclick = "CopyBackOperationChancel()"/>
            </div>
            <div>
                <input id="PatientUpdateOperSchedule" type = "button" value ="回写手术安排信息" onclick = "GetPatientUpdateOperationSchedule()"/>
            </div>            
            <div>
                <input id="CopyBackOperationInformationBtn" type = "button" value ="回写术后手术信息" onclick = "CopyBackOperationInformation()"/>
            </div>
            <div>
                <input id="patientChargesVerifyInfo214" type = "button" value ="收费授权信息" onclick = "GetPatientChargesVerifyInfo()"/>
            </div>
            <div>
                <input id="PatientSchedulesInto" type = "button" value ="回写手术收费信息" onclick = "SetPatientSchedulesInto()"/>
            </div>
            <div>
                <input id="DeptMtrldocumentBT" type = "button" value ="科室耗材入库信息" onclick = "GetDeptMtrlDocument()"/>
            </div>
            <div>
                <input id="DeptDrugdocumentBT" type = "button" value ="科室药品入库信息" onclick = "GetDeptDrugDocument()"/>
            </div>
            <div>
                <input id="PatientNursingDataInfo" type = "button" value ="病人提取护理记录" onclick = "GetPatientNursingDataInfo()"/>
            </div>
            <div>
                <input id="PatientEmrDocUpLoad" type = "button" value ="病人打印病历文书(单项)" onclick = "GetPatientEmrDocUpLoad()"/>
            </div>
            <div>
                <input id="PatientAllEmrDocUpLoad" type = "button" value ="病人病历提交(所有)" onclick = "GetPatientAllEmrDocUpLoad()"/>
            </div>
            <div>
                <input id="Button1" type = "button" value ="一体机同步" onclick = "yitiji()"/>
            </div>
            <br />
            <div>
                输入查看记录日志信息:<br />
                <input id="logsDate" type = "text" value ="" />
            </div>
            <div>
                <input id="logsTxt" type = "button" value ="查看当天日志信息" onclick = "GetLogsTxt()"/>
            </div>
         </fieldset>
         </div> 
         <div align="left" style="float:left;width:256">
            <fieldset>
            <legend> ICU业务数据控制:</legend>
            <div>
                <input id="ICUDeptPatientInfo" type = "button" value ="科室代码同步在院信息" onclick = "GetICUDeptPatientInfo()"/>
            </div>
            <div>
                <input id="ICUselectPatientID" type = "button" value ="ID号同步病人信息" onclick = "GetICUPatientIDInfo()" />
            </div>
            <div>
                <input id="ICUPatientInpNo" type = "button" value ="住院号同步病人信息" onclick = "GetICUPatientInpNoInfo()" />
            </div>
            <div>
                <input id="ICUselectPatientOrders" type = "button" value ="ID号同步病人医嘱信息" onclick = "GetICUPatientOrdersInfo()"/>
            </div>
            <div>
                <input id="ICUselectPatientOrdersDate" type = "button" value ="ID号时间段医嘱信息" onclick = "GetICUPatientOrdersInfoOnDate()"/>
            </div>
            <div>
                <input id="ICUselectPatientLabMaster" type = "button" value ="ID号同步病人检验信息" onclick = "GetICULabMaster()"/>
            </div>
            <div>
                <input id="ICUPatientEmrDocUpLoad" type = "button" value ="病人打印病历文书(单项)" onclick = "GetICUPatientEmrDocUpLoad()"/>
            </div>
            <div>
                <input id="ICUPatientAllEmrDocUpLoad" type = "button" value ="病人病历提交(所有)" onclick = "GetICUPatientAllEmrDocUpLoad()"/>
            </div>
            <br />
            </fieldset>
            <fieldset>
            <legend> XML数据控制:</legend>
            <div>
                <input id="GetXMLUpdateDeptDictBT" type = "button" value ="XML更新科室信息数据" onclick = "XMLUpdateDeptDict()"/>
            </div>
            <div>
                <input id="GetXMLUpdateUsersBT" type = "button" value ="XML更新工作人员信息数据" onclick = "XMLUpdateUsers()"/>
            </div>
            <div>
                <input id="GetXMLUpdatePatMasterIndexBT" type = "button" value ="XML更新病人基本信息数据" onclick = "XMLUpdatePatMasterIndex()" />
            </div>
            <div>
                <input id="GetXMLUpdatePatsInHospitalBT" type = "button" value ="XML更新病人住院信息数据" onclick = "XMLUpdatePatsInHospital()" />
            </div>
            <div>
                <input id="GetXMLUpdateOperationScheduleBT" type = "button" value ="XML更新手术预约信息数据" onclick = "XMLUpdateOperationSchedule()"/>
            </div>
            <div>
                <input id="GetXMLDataPatientEmrArchiveDetialBT" type = "button" value ="XML获取电子病历记录信息" onclick = "XMLGetDataPatientEmrArchiveDetial()"/>
            </div>
            <div>
                <input id="GetXMLDataPatientEmrArchiveDetialInfoBT" type = "button" value ="XML获取电子病历详细记录" onclick = "XMLGetDataPatientEmrArchiveDetialInfo()"/>
            </div>
            <div>
                <input id="GetAnesthesiaEventBT" type = "button" value ="XML获取麻醉药品事件" onclick = "XMLGetAnesthesiaEvent()"/>
            </div>
            <br />
            </fieldset>
         </div>
         <div align="left" style="float:left;width:256">
         <fieldset>
            <legend> 输入区域:</legend>
            <div>
                <asp:Label ID ="text1" runat ="server" Text ="病人(或登陆平台)ID号:MED_PATIENT_ID"></asp:Label><br />
                <asp:TextBox id="patientId" runat="server" TextMode="SingleLine" BorderWidth="2"  Width="256"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID ="Label1" runat ="server" Text ="住院次数(或登平台密码):MED_VISIT_ID"></asp:Label><br />
                <asp:TextBox id="visitId" runat="server" TextMode="SingleLine" BorderWidth="2" Width="256"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID ="Label2" runat ="server" Text ="住院号(或登平台新密码):(另手术次数R01)"></asp:Label><br />
                <asp:TextBox id="inpNo" runat="server" TextMode="SingleLine" BorderWidth="2" Width="256"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID ="Label3" runat ="server" Text ="病区代码:(另收费序号R02[MRSUB])"></asp:Label><br />
                <asp:TextBox id="deptPatient" runat="server" TextMode="SingleLine" BorderWidth="2" Width="256"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID ="Label6" runat ="server" Text ="保留号:(BEGIN工号R03[ARCHIVEKEY])"></asp:Label><br />
                <asp:TextBox id="reserved" runat="server" Text='2300' TextMode="SingleLine" BorderWidth="2" Width="256"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID ="Label9" runat ="server" Text ="保留号2:(预留R04[EMR名称])"></asp:Label><br />
                <asp:TextBox id="reserved02" runat="server" TextMode="SingleLine" BorderWidth="2" Width="256"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID ="Label4" runat ="server" Text ="开始时间日期:[yyyy-MM-dd]"></asp:Label><br />
                <asp:TextBox id="startdatetime" runat="server" TextMode="SingleLine" BorderWidth="2" Width="256"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID ="Label5" runat ="server" Text ="结束时间日期:[yyyy-MM-dd]"></asp:Label><br />
                <asp:TextBox id="enddatetime" runat="server" TextMode="SingleLine" BorderWidth="2" Width="256"></asp:TextBox>
            </div>
         </fieldset>
         </div>
         
         
       </div>
       <div align="right" style="float:left;width:516; height: 100%;">
        </div>
        </div>
       <legend> XML输入区域:</legend>
       <div>
            <asp:TextBox id="xmlInput" runat="server" TextMode ="SingleLine" Width="516"></asp:TextBox>
       </div>
       <legend> 调用返回区域:</legend>
        <div>
            <asp:TextBox id="rizhi" runat="server" TextMode="MultiLine" BorderWidth="2"  Height="451px" Width="516"></asp:TextBox>
        </div>
       
    </fieldset>
    </form>
</body>
</html>
