<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view.aspx.cs" Inherits="DoCareEmr.view" ResponseEncoding="gb2312"  %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
        <head id="Head1" runat="server">
        <title>��������ļ�</title>
        <style>
        body 
        {
        margin:0px;
        padding:0px;
        }
        html,body{
        height:100%;
        width:100%;
        }
        </style>
        <script type="text/javascript" charset="gb2312" src="../public/suggest.js"></script>
        </head>
        <body style="margin-left:0px;">

        <center>
        <table width="800" border="0" align="center" cellpadding="3" cellspacing="0" bgcolor="#D4D0C8">
		<tr style=" cursor:pointer; background:url(images/demo_line.jpg) top repeat-x"> 
          <td align="center" nowrap="nowrap" bgcolor="#ECE9D8">
          <img src="image/p1.png" border="0"  onClick=OpenPDF() alt="��" height=60></td>
          <td align="center" nowrap="nowrap" bgcolor="#ECE9D8">
          <img src="image/bt_print.jpg" border="0" onclick=YCanPDF.PrintPDF("","",3,40) alt="��ӡ" height=60/></td>
          <td align="center" nowrap="nowrap" bgcolor="#ECE9D8">
          <img src="image/p7.jpg" border="0" name="SaveAsDlg" onclick=YCanPDF.SaveAsDlg(0) alt="���Ϊ" height=60/></td>
          <td align="center" nowrap="nowrap" bgcolor="#ECE9D8">
          <img src="image/p3.png" border="0" onclick=zoomOut() name="Big" alt="�Ŵ�"  height=60/></td>
          <td align="center" nowrap="nowrap" bgcolor="#ECE9D8">
          <img src="image/p4.png" border="0" onclick=zoomIn() name="Small" alt="��С"  height=60/></td>
          <td align="center" nowrap="nowrap" bgcolor="#ECE9D8">
          <img src="image/p6.jpg" border="0" name="RotateRight" onclick=YCanPDF.RotateRight() alt="��ת90��"  height=60/></td>
          <td align="center" nowrap="nowrap" bgcolor="#ECE9D8">
          <img src="image/p5.jpg" border="0" name="RotateLeft" onclick=YCanPDF.RotateLeft() alt="��ת90��"  height=60/></td>
      </table>
      <div>
      ˵����PDF��ӡ���������鸽��ˮӡ�������ο�ʹ�á�������ʽ�鵵�������ȡ����Ϊ�������أ�Ȼ��ӱ��ش�ӡ��
      </div>
        <%--���ÿؼ�--%>
        <div>
        <object id="YCanPDF" classid="clsid:474C1AB2-EFA5-4A19-9267-BA38B685C74A" codebase="<%=WebServer_IP%>/ocx/pdfview.cab#version=1,7,6,2" width="1000" height="1500"></object>
        </div></center>
             <script type="text/javascript">
             var n="-1";
            function loadFiles()
            {	
            YCanPDF.Zoom=1;// ����PDFԭʼ�����С��ʾ
            n=YCanPDF.SetURL("<%=pdfpath%>","");// �������PDF�ļ���ֻ֧�־���·��
            //n=YCanPDF.SetURL("http://www.ycanpdf.cn/��ķ�Ծ.pdf","");
            YCanPDF.ShowOutline(false);
            YCanPDF.FitWidth();
            //document.getElementById("YCanPDF").AddWaterMark('<%=WebServer_IP %>/main/image/water.jpg', 0, 0, 950, 1200, 0,100 , 0);
            }
            var intervalID;
            function readyState()
            {
            if(document.readyState == "complete")
            {
            loadFiles();
            window.clearTimeout( intervalID );
            if(n=="0") 
            window.setTimeout("new  Ajax().getData('<%=Request.Path.ToString()%>','isAjax=true&pdfpath=<%=Session.SessionID+GetRequest("pdfpath")%>',function(obj){})",1600);
            }
            }
            intervalID=window.setInterval("readyState()",100);
            //function document.oncontextmenu(){
            //event.returnValue=false;
            //}


            function OpenPDF()
            {
                YCanPDF.SetRCURL("http://www.ycanpdf.cn/rc/rc.CAB",0);// ����������Դ��ֻ֧�־���·��
                var n=YCanPDF.OpenFileDlg(0);// �򿪱��ص�PDF�ļ�
                YCanPDF.FitWidth();
            }
             
            function OpenURL()
            {
                YCanPDF.SetRCURL("http://www.ycanpdf.cn/rc/rc.CAB",0);// ����������Դ��ֻ֧�־���·��
                var PDFLabels=window.prompt("������PDF��ַ��","http://www.ycanpdf.cn/��ķ�Ծ.pdf"); 
                if(PDFLabels){
	                YCanPDF.Zoom=1;// ����PDFԭʼ�����С��ʾ
	                var n=YCanPDF.SetURL(PDFLabels,"");// �������PDF�ļ���ֻ֧�־���·��
	                YCanPDF.FitWidth();
                }
            }
             
            function zoomOut()
            {
                if(YCanPDF.Zoom<3.5)
                  YCanPDF.Zoom=YCanPDF.Zoom+0.5;
            }
             
            function zoomIn()
            {
                if(YCanPDF.Zoom>1)
                  YCanPDF.Zoom=YCanPDF.Zoom-0.5;
            }
             
            function Search()
            {
                var key = document.getElementById("key").value;
                if(""==key)
                {
	                alert("������ؼ���!");
                }
                else
                {
	                YCanPDF.SearchStr(key, 0, 1);
                }
            }
            </script> 
         &nbsp;
        </body>
        </html>
