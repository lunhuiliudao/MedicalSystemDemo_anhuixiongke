<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view.aspx.cs" Inherits="DoCareEmr.view" ResponseEncoding="gb2312"  %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
        <head id="Head1" runat="server">
        <title>浏览病历文件</title>
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
          <img src="image/p1.png" border="0"  onClick=OpenPDF() alt="打开" height=60></td>
          <td align="center" nowrap="nowrap" bgcolor="#ECE9D8">
          <img src="image/bt_print.jpg" border="0" onclick=YCanPDF.PrintPDF("","",3,40) alt="打印" height=60/></td>
          <td align="center" nowrap="nowrap" bgcolor="#ECE9D8">
          <img src="image/p7.jpg" border="0" name="SaveAsDlg" onclick=YCanPDF.SaveAsDlg(0) alt="另存为" height=60/></td>
          <td align="center" nowrap="nowrap" bgcolor="#ECE9D8">
          <img src="image/p3.png" border="0" onclick=zoomOut() name="Big" alt="放大"  height=60/></td>
          <td align="center" nowrap="nowrap" bgcolor="#ECE9D8">
          <img src="image/p4.png" border="0" onclick=zoomIn() name="Small" alt="缩小"  height=60/></td>
          <td align="center" nowrap="nowrap" bgcolor="#ECE9D8">
          <img src="image/p6.jpg" border="0" name="RotateRight" onclick=YCanPDF.RotateRight() alt="右转90度"  height=60/></td>
          <td align="center" nowrap="nowrap" bgcolor="#ECE9D8">
          <img src="image/p5.jpg" border="0" name="RotateLeft" onclick=YCanPDF.RotateLeft() alt="左转90度"  height=60/></td>
      </table>
      <div>
      说明：PDF打印出来的文书附有水印，仅供参考使用。如有正式归档需求，请先“另存为”到本地，然后从本地打印。
      </div>
        <%--调用控件--%>
        <div>
        <object id="YCanPDF" classid="clsid:474C1AB2-EFA5-4A19-9267-BA38B685C74A" codebase="<%=WebServer_IP%>/ocx/pdfview.cab#version=1,7,6,2" width="1000" height="1500"></object>
        </div></center>
             <script type="text/javascript">
             var n="-1";
            function loadFiles()
            {	
            YCanPDF.Zoom=1;// 按照PDF原始界面大小显示
            n=YCanPDF.SetURL("<%=pdfpath%>","");// 打开网络的PDF文件，只支持绝对路径
            //n=YCanPDF.SetURL("http://www.ycanpdf.cn/书的飞跃.pdf","");
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
                YCanPDF.SetRCURL("http://www.ycanpdf.cn/rc/rc.CAB",0);// 加载字体资源，只支持绝对路径
                var n=YCanPDF.OpenFileDlg(0);// 打开本地的PDF文件
                YCanPDF.FitWidth();
            }
             
            function OpenURL()
            {
                YCanPDF.SetRCURL("http://www.ycanpdf.cn/rc/rc.CAB",0);// 加载字体资源，只支持绝对路径
                var PDFLabels=window.prompt("请输入PDF网址：","http://www.ycanpdf.cn/书的飞跃.pdf"); 
                if(PDFLabels){
	                YCanPDF.Zoom=1;// 按照PDF原始界面大小显示
	                var n=YCanPDF.SetURL(PDFLabels,"");// 打开网络的PDF文件，只支持绝对路径
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
	                alert("请输入关键字!");
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
