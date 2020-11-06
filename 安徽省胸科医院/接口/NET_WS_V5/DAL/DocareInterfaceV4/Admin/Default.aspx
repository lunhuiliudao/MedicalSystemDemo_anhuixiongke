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
<title>DoCare��Ϣ�ӿڹ���ƽ̨V4</title>
</head>
<body  id="Indexbody" onLoad ="inita()" style="font-size: 14px; font-family: ����; background-color: #F1F3F5; font-style: normal;"> 
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
    <legend>�û�������Ϣ</legend>
    <div>
        < <asp:LinkButton ID="forInfo" runat="server" Text ="�鿴HIS��ȡ��Ϣ"  onclick="forInfo_Click"></asp:LinkButton> >
        < <asp:LinkButton ID="dataConn" runat="server" Text ="����TRANS����"  
            onclick="dataConn_Click"></asp:LinkButton> >&lt; <asp:LinkButton ID="PZ_trans" 
            runat="server" Text ="����TRANS��Ϣ"  onclick="PZ_trans_Click"></asp:LinkButton> 
        &gt;
        < <asp:LinkButton ID="loginInEmr" runat="server" Text ="���Բ鿴���Ӳ���" onclick="loginInEmr_Click" ></asp:LinkButton> >
        < <asp:LinkButton ID="LinkButton1" runat="server" Text ="DoCareϵͳ�ṩWebServices"  onclick="WebServices_Click"></asp:LinkButton> >
        < <asp:LinkButton ID ="guanyu" runat="server" Text ="���ڰ汾V2.1.3" onclick="guanyu_Click"></asp:LinkButton> >
    </div>
    <div align="left" >
        <asp:Button runat="server" ID="zhuxiao" Text="�˳�" OnClick="zhuxiao_Click" />
        ��ǰDoCareϵͳ��¼ƽ̨�û�: <asp:Label runat="server" ID="loginName" Text="����Ա"></asp:Label>&nbsp;&nbsp;&nbsp;
        <asp:LinkButton runat="server" ID="password" Text="�޸�����" OnClick="password_Click"></asp:LinkButton>&nbsp;&nbsp;&nbsp;
    </div>
    </fieldset>

    <fieldset>
    <legend>����DoCare���ݿ�</legend>
    <div align="left" style="float:left;width:516; height: 100%;">
        <asp:DetailsView ID="DetailsView1" runat="server" Width="575px"  FieldHeaderStyle-Width="175px" FieldHeaderStyle-Height="20px" 
        GridLines="None" AutoGenerateRows="False"
        AutoGenerateEditButton="True"  OnModeChanging="DetailsView1_ModeChanging" 
        OnItemUpdated="DetailsView1_ItemUpdated"  OnItemCreated="DetailsView1_ItemCreated"
            OnItemUpdating ="DetailsView1_ItemUpdating" EnableViewState="False">
        <Fields>
        <asp:TemplateField>
                <HeaderTemplate>ѡ��HIS���ݿ�����</HeaderTemplate>
                <ItemTemplate><asp:Label runat="server" ID="HISDataServerType" Text='<%# Bind("HISDataServerType") %>'></asp:Label></ItemTemplate>
                <EditItemTemplate><asp:DropDownList runat="server" Width="80%" ID="DataServerType2" Text = '<%# Bind("HISDataServerType") %>' ></asp:DropDownList></EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>ѡ��Docare���ݿ�����</HeaderTemplate>
                <ItemTemplate><asp:Label runat="server" ID="DataServerType" Text='<%# Bind("DataServerType") %>'></asp:Label></ItemTemplate>
                <EditItemTemplate><asp:DropDownList runat="server" Width="80%" ID="DataServerType3" Text = '<%# Bind("DataServerType") %>' ></asp:DropDownList></EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>DoCare������</HeaderTemplate>
                <ItemTemplate><asp:Label runat="server" ID="serverName" Text='<%# Bind("ServerName") %>'></asp:Label></ItemTemplate>
                <EditItemTemplate><asp:TextBox runat="server" ReadOnly="false" Width="80%" ID="serverName2" Text='<% #Bind("ServerName") %>'></asp:TextBox></EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>����Ŀ¼</HeaderTemplate>
                <ItemTemplate><asp:Label runat="server" ID="Catalog" Text='<%# Bind("Catalog") %>'></asp:Label></ItemTemplate>
                <EditItemTemplate><asp:TextBox runat="server" ReadOnly="false" Width="80%" ID="Catalog2" Text='<% #Bind("Catalog") %>'></asp:TextBox></EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>��¼�û�</HeaderTemplate>
                <ItemTemplate><asp:Label runat="server" ID="ServerLogin" Text='<%# Bind("ServerLogin") %>'></asp:Label></ItemTemplate>
                <EditItemTemplate><asp:TextBox runat="server" ReadOnly="false" Width="80%" ID="ServerLogin2" Text='<% #Bind("ServerLogin") %>'></asp:TextBox></EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>��¼����</HeaderTemplate>
                <ItemTemplate><asp:Label runat="server" ID="ServerPwd" Text="********" ></asp:Label></ItemTemplate>
                <EditItemTemplate><asp:TextBox runat="server" Width="80%"  ID="ServerPwd2" TextMode ="Password" Text='<% # Bind("ServerPwd") %>' ></asp:TextBox></EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>�������</HeaderTemplate>
                <ItemTemplate><asp:Label runat="server" ID="Title" Text='<%# Bind("Title") %>'></asp:Label></ItemTemplate>
                <EditItemTemplate><asp:TextBox runat="server" ReadOnly="false" Width="80%" ID="Title2" Text='<% #Bind("Title") %>'></asp:TextBox></EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>����ƽ̨WebServices��ַ(��ȡ)</HeaderTemplate>
                <ItemTemplate><asp:Label runat="server" ID="wsurlGet" Text='<%# Bind("WebServerUrlGet") %>'></asp:Label></ItemTemplate>
                <EditItemTemplate><asp:TextBox runat="server" ReadOnly="false" Width="80%" ID="wsurlGet" Text='<% #Bind("WebServerUrlGet") %>'></asp:TextBox></EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>����ƽ̨WebServices��ַ(��д)</HeaderTemplate>
                <ItemTemplate><asp:Label runat="server" ID="wsurlSet" Text='<%# Bind("WebServerUrlSet") %>'></asp:Label></ItemTemplate>
                <EditItemTemplate><asp:TextBox runat="server" ReadOnly="false" Width="80%" ID="wsurlSet" Text='<% #Bind("WebServerUrlSet") %>'></asp:TextBox></EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>HIS��ַ(WebServices)</HeaderTemplate>
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
        <div class="style1">˵��: HIS��ַ����ֻΪHIS�����ṩWebServices����ʱʹ��,</div>
        <div class="style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;���HISδ�ṩ����Ϊ��</div>
    </div>
    
    <div align="left" style="float:left;width:516; height: 100%;">
     <asp:UpdatePanel ID="uid"  runat="server" UpdateMode="Conditional">
     <ContentTemplate>
     <div>
        <asp:Button ID="textInfo" runat ="server" Text="����RUN_CONFIG����" 
             onclick="textInfo_Click"/>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="uid">
            <ProgressTemplate><asp:Label ID="Label0" runat="server" Text="���ڴ�������......"></asp:Label></ProgressTemplate>
        </asp:UpdateProgress>
     </div>
     <div style="float:none">
         <fieldset>
         <legend>��ʾ������Ϣ</legend>
         <div>
            <asp:Label ID="Label91" Text = "ϵͳ1:" runat = "server"></asp:Label>
            <asp:TextBox id="system1" runat="server" TextMode="SingleLine" Text="ANESMGR"></asp:TextBox>
            <asp:Label ID="Label14" Text = "ϵͳ2:" runat = "server" ></asp:Label>
            <asp:TextBox id="system2" runat="server" TextMode="SingleLine" Text="ICUMGR"></asp:TextBox>
            <asp:Label ID="Label15" Text = "����XML:" runat = "server" ></asp:Label>
            <asp:TextBox id="systemXML" runat="server" TextMode="SingleLine" Text="ICUMGR"></asp:TextBox>
         </div>
         <div>
            <asp:TextBox id="datalogs" runat="server" TextMode="SingleLine" ForeColor="Red" Text="δ����,����[��ʾDoCare������Ϣ]�Ȱ�ť!"  BorderWidth="2" ReadOnly = "true" Enabled = "false" Width="512"></asp:TextBox>
         </div>
         </fieldset>
     </div>
     <div style="float:none">
        <div align="left" style="float:left;width:256;">
            <fieldset>
            <legend>DoCare-ϵͳ1��Ϣ</legend>
            <div>
                <asp:Label ID="Label8" Text = "֧��ҽԺHIS��Ϣ :" runat = "server"></asp:Label><br />
                <asp:TextBox id="aneshisSupply" runat="server" TextMode="SingleLine" BorderWidth="2" ReadOnly = "true" Enabled = "false" Width="256"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label10" Text = "֧��ҽ����Ϣ:" runat = "server"></asp:Label><br />
                <asp:TextBox id="anesorders" runat="server" TextMode="SingleLine" BorderWidth="2" ReadOnly = "true" Enabled = "false" Width="256"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label11" Text = "֧�ּ�����Ϣ :" runat = "server"></asp:Label><br />
                <asp:TextBox id="aneslis" runat="server" TextMode="SingleLine" BorderWidth="2" ReadOnly = "true" Enabled = "false" Width="256"></asp:TextBox>
            </div>
            </fieldset>
        </div>
        <div align="left" style="float:left;width:256;">
            <fieldset>
            <legend>DoCare-ϵͳ2��Ϣ</legend>
            <div>
                <asp:Label ID="Label7" Text = "֧��ҽԺHIS��Ϣ :" runat = "server"></asp:Label><br />
                <asp:TextBox id="icuhisSupply" runat="server" TextMode="SingleLine" BorderWidth="2" ReadOnly = "true" Enabled = "false" Width="256"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label12" Text = "֧��ҽ����Ϣ:" runat = "server"></asp:Label><br />
                <asp:TextBox id="icuorders" runat="server" TextMode="SingleLine" BorderWidth="2" ReadOnly = "true" Enabled = "false" Width="256"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label13" Text = "֧�ּ�����Ϣ :" runat = "server"></asp:Label><br />
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
    <legend>DoCareϵͳӦ�ù���--ϵͳ</legend>
    <div>
       <div align="left" style="float:left;width:516; height: 100%;">
         <div>
            <fieldset>
            <legend>DoCare�������ݿ��� :(������������Ӱ��)</legend>
            <div style="float:left;width:516;" >
                <div>
                    <input id="PtLogOn" type = "button" value ="����ƽ̨��½" onclick = "GetLogOn()"/>               
                </div>
                <div>
                    <input id="renyuan" type = "button" value ="����ͬ��HIS��Ա��Ϣ" onclick = "GetHisUsers()"/>
                    <input id="keshi" type = "button" value ="����ͬ��HIS������Ϣ" onclick = "GetDeptDict()"/>
                </div>
                <div>
                    <input id="renyuanICU" type = "button" value ="ICUͬ��HIS��Ա��Ϣ" onclick = "GetICUHisUsers()"/>
                    <input id="keshiICU" type = "button" value ="ICUͬ��HIS������Ϣ" onclick = "GetICUDeptDict()"/>
                </div>
                <div>
                    <input id="operaitonDict" type = "button" value ="����ͬ��HIS��������" onclick = "GetOperationDict()"/>
                    <input id="PriceDict" type = "button" value ="����ͬ��HIS����ֵ���Ϣ" onclick = "GetDiagnosis()"/>
                </div>
                <div>
                    <input id="Drugdict" type = "button" value ="����ͬ��HISҩƷ�ֵ�" onclick = "GetDrugdict()"/>
                    <input id="Mtrldict" type = "button" value ="����ͬ��HIS�Ĳ��ֵ�" onclick = "GetMtrldict()"/>
                </div>
                <div>
                    <input id="DrugNameDict" type = "button" value ="����ͬ��HISҩƷ����" onclick = "GetDrugNameDict()"/>
                    <input id="MtrlSupplierCatalog" type = "button" value ="����ͬ��HIS�ĲĹ�Ӧ��" onclick = "GetMtrlSupplierCatalog()"/>
                </div>
            </div>

            </fieldset>
            
         </div>
         
         
         
         <div align="left" style="float:left;width:256">
         <fieldset>
            <legend>����ҵ�����ݿ���:</legend>
            <div>
                <input id="DeptSchedules" type = "button" value ="ͬ������ԤԼ��Ϣ" onclick = "GetDeptOperationSchedules()"/>
            </div>
            <div>
                <input id="selectPatientID" type = "button" value ="ID��ͬ��������Ϣ" onclick = "GetPatientIDInfo()" />
            </div>
            <div>
                <input id="PatientInpNo" type = "button" value ="סԺ��ͬ��������Ϣ" onclick = "GetPatientInpNoInfo()" />
            </div>
            <div>
                <input id="selectPatientOrders" type = "button" value ="ID��ͬ������ҽ����Ϣ" onclick = "GetPatientOrdersInfo()"/>
            </div>
            <div>
                <input id="selectPatientOrdersDate" type = "button" value ="ID��ʱ���ҽ����Ϣ" onclick = "GetPatientOrdersInfoOnDate()"/>
            </div>
            <div>
                <input id="selectPatientLabMaster" type = "button" value ="ID��ͬ�����˼�����Ϣ" onclick = "GetLabMaster()"/>
            </div>
            <div>
                <input id="setOperationState" type = "button" value ="��д����״̬��Ϣ" onclick = "CopyBackOperationState()"/>
            </div>
            <div>
                <input id="CopyBackOperationChancelBtn" type = "button" value ="��д����ȡ����Ϣ" onclick = "CopyBackOperationChancel()"/>
            </div>
            <div>
                <input id="PatientUpdateOperSchedule" type = "button" value ="��д����������Ϣ" onclick = "GetPatientUpdateOperationSchedule()"/>
            </div>            
            <div>
                <input id="CopyBackOperationInformationBtn" type = "button" value ="��д����������Ϣ" onclick = "CopyBackOperationInformation()"/>
            </div>
            <div>
                <input id="patientChargesVerifyInfo214" type = "button" value ="�շ���Ȩ��Ϣ" onclick = "GetPatientChargesVerifyInfo()"/>
            </div>
            <div>
                <input id="PatientSchedulesInto" type = "button" value ="��д�����շ���Ϣ" onclick = "SetPatientSchedulesInto()"/>
            </div>
            <div>
                <input id="DeptMtrldocumentBT" type = "button" value ="���ҺĲ������Ϣ" onclick = "GetDeptMtrlDocument()"/>
            </div>
            <div>
                <input id="DeptDrugdocumentBT" type = "button" value ="����ҩƷ�����Ϣ" onclick = "GetDeptDrugDocument()"/>
            </div>
            <div>
                <input id="PatientNursingDataInfo" type = "button" value ="������ȡ�����¼" onclick = "GetPatientNursingDataInfo()"/>
            </div>
            <div>
                <input id="PatientEmrDocUpLoad" type = "button" value ="���˴�ӡ��������(����)" onclick = "GetPatientEmrDocUpLoad()"/>
            </div>
            <div>
                <input id="PatientAllEmrDocUpLoad" type = "button" value ="���˲����ύ(����)" onclick = "GetPatientAllEmrDocUpLoad()"/>
            </div>
            <div>
                <input id="Button1" type = "button" value ="һ���ͬ��" onclick = "yitiji()"/>
            </div>
            <br />
            <div>
                ����鿴��¼��־��Ϣ:<br />
                <input id="logsDate" type = "text" value ="" />
            </div>
            <div>
                <input id="logsTxt" type = "button" value ="�鿴������־��Ϣ" onclick = "GetLogsTxt()"/>
            </div>
         </fieldset>
         </div> 
         <div align="left" style="float:left;width:256">
            <fieldset>
            <legend> ICUҵ�����ݿ���:</legend>
            <div>
                <input id="ICUDeptPatientInfo" type = "button" value ="���Ҵ���ͬ����Ժ��Ϣ" onclick = "GetICUDeptPatientInfo()"/>
            </div>
            <div>
                <input id="ICUselectPatientID" type = "button" value ="ID��ͬ��������Ϣ" onclick = "GetICUPatientIDInfo()" />
            </div>
            <div>
                <input id="ICUPatientInpNo" type = "button" value ="סԺ��ͬ��������Ϣ" onclick = "GetICUPatientInpNoInfo()" />
            </div>
            <div>
                <input id="ICUselectPatientOrders" type = "button" value ="ID��ͬ������ҽ����Ϣ" onclick = "GetICUPatientOrdersInfo()"/>
            </div>
            <div>
                <input id="ICUselectPatientOrdersDate" type = "button" value ="ID��ʱ���ҽ����Ϣ" onclick = "GetICUPatientOrdersInfoOnDate()"/>
            </div>
            <div>
                <input id="ICUselectPatientLabMaster" type = "button" value ="ID��ͬ�����˼�����Ϣ" onclick = "GetICULabMaster()"/>
            </div>
            <div>
                <input id="ICUPatientEmrDocUpLoad" type = "button" value ="���˴�ӡ��������(����)" onclick = "GetICUPatientEmrDocUpLoad()"/>
            </div>
            <div>
                <input id="ICUPatientAllEmrDocUpLoad" type = "button" value ="���˲����ύ(����)" onclick = "GetICUPatientAllEmrDocUpLoad()"/>
            </div>
            <br />
            </fieldset>
            <fieldset>
            <legend> XML���ݿ���:</legend>
            <div>
                <input id="GetXMLUpdateDeptDictBT" type = "button" value ="XML���¿�����Ϣ����" onclick = "XMLUpdateDeptDict()"/>
            </div>
            <div>
                <input id="GetXMLUpdateUsersBT" type = "button" value ="XML���¹�����Ա��Ϣ����" onclick = "XMLUpdateUsers()"/>
            </div>
            <div>
                <input id="GetXMLUpdatePatMasterIndexBT" type = "button" value ="XML���²��˻�����Ϣ����" onclick = "XMLUpdatePatMasterIndex()" />
            </div>
            <div>
                <input id="GetXMLUpdatePatsInHospitalBT" type = "button" value ="XML���²���סԺ��Ϣ����" onclick = "XMLUpdatePatsInHospital()" />
            </div>
            <div>
                <input id="GetXMLUpdateOperationScheduleBT" type = "button" value ="XML��������ԤԼ��Ϣ����" onclick = "XMLUpdateOperationSchedule()"/>
            </div>
            <div>
                <input id="GetXMLDataPatientEmrArchiveDetialBT" type = "button" value ="XML��ȡ���Ӳ�����¼��Ϣ" onclick = "XMLGetDataPatientEmrArchiveDetial()"/>
            </div>
            <div>
                <input id="GetXMLDataPatientEmrArchiveDetialInfoBT" type = "button" value ="XML��ȡ���Ӳ�����ϸ��¼" onclick = "XMLGetDataPatientEmrArchiveDetialInfo()"/>
            </div>
            <div>
                <input id="GetAnesthesiaEventBT" type = "button" value ="XML��ȡ����ҩƷ�¼�" onclick = "XMLGetAnesthesiaEvent()"/>
            </div>
            <br />
            </fieldset>
         </div>
         <div align="left" style="float:left;width:256">
         <fieldset>
            <legend> ��������:</legend>
            <div>
                <asp:Label ID ="text1" runat ="server" Text ="����(���½ƽ̨)ID��:MED_PATIENT_ID"></asp:Label><br />
                <asp:TextBox id="patientId" runat="server" TextMode="SingleLine" BorderWidth="2"  Width="256"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID ="Label1" runat ="server" Text ="סԺ����(���ƽ̨����):MED_VISIT_ID"></asp:Label><br />
                <asp:TextBox id="visitId" runat="server" TextMode="SingleLine" BorderWidth="2" Width="256"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID ="Label2" runat ="server" Text ="סԺ��(���ƽ̨������):(����������R01)"></asp:Label><br />
                <asp:TextBox id="inpNo" runat="server" TextMode="SingleLine" BorderWidth="2" Width="256"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID ="Label3" runat ="server" Text ="��������:(���շ����R02[MRSUB])"></asp:Label><br />
                <asp:TextBox id="deptPatient" runat="server" TextMode="SingleLine" BorderWidth="2" Width="256"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID ="Label6" runat ="server" Text ="������:(BEGIN����R03[ARCHIVEKEY])"></asp:Label><br />
                <asp:TextBox id="reserved" runat="server" Text='2300' TextMode="SingleLine" BorderWidth="2" Width="256"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID ="Label9" runat ="server" Text ="������2:(Ԥ��R04[EMR����])"></asp:Label><br />
                <asp:TextBox id="reserved02" runat="server" TextMode="SingleLine" BorderWidth="2" Width="256"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID ="Label4" runat ="server" Text ="��ʼʱ������:[yyyy-MM-dd]"></asp:Label><br />
                <asp:TextBox id="startdatetime" runat="server" TextMode="SingleLine" BorderWidth="2" Width="256"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID ="Label5" runat ="server" Text ="����ʱ������:[yyyy-MM-dd]"></asp:Label><br />
                <asp:TextBox id="enddatetime" runat="server" TextMode="SingleLine" BorderWidth="2" Width="256"></asp:TextBox>
            </div>
         </fieldset>
         </div>
         
         
       </div>
       <div align="right" style="float:left;width:516; height: 100%;">
        </div>
        </div>
       <legend> XML��������:</legend>
       <div>
            <asp:TextBox id="xmlInput" runat="server" TextMode ="SingleLine" Width="516"></asp:TextBox>
       </div>
       <legend> ���÷�������:</legend>
        <div>
            <asp:TextBox id="rizhi" runat="server" TextMode="MultiLine" BorderWidth="2"  Height="451px" Width="516"></asp:TextBox>
        </div>
       
    </fieldset>
    </form>
</body>
</html>
