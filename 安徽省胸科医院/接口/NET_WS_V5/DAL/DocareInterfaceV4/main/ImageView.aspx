<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImageView.aspx.cs" Inherits="main_ImageView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <script language="javascript" type="text/javascript">    
            var HKEY_Root,HKEY_Path,HKEY_Key;
            HKEY_Root="HKEY_CURRENT_USER";
            HKEY_Path="\\Software\\Microsoft\\Internet Explorer\\PageSetup\\";

            function doPrint() { 
               try
                {
                PageSetup_Null();
                }
               catch(e)
                {
                    var errorMsg = e.message+"\r"+"请设置:IE选项->安全->Internet->"+"ActiveX控件和插件"+"\r"+"对未标记为可安全执行脚本的ActiveX的控件初始化并执行脚本->允许/提示";
                    alert(errorMsg);
                    return;
                }
                bdhtml=window.document.body.innerHTML;    
                sprnstr="<!--startprint-->";    
                eprnstr="<!--endprint-->";    
                prnhtml=bdhtml.substr(bdhtml.indexOf(sprnstr)+17);    
                prnhtml=prnhtml.substring(0,prnhtml.indexOf(eprnstr));    
                window.document.body.innerHTML=prnhtml;    
                window.print();    
                window.document.body.innerHTML=bdhtml;    
                return false;
           }  
           
         
         function PageSetup_Null()
            {
                  var Wsh=new ActiveXObject("WScript.Shell");
                  HKEY_Key="header";
                  Wsh.RegWrite(HKEY_Root+HKEY_Path+HKEY_Key,"");
                  HKEY_Key="footer";
                  Wsh.RegWrite(HKEY_Root+HKEY_Path+HKEY_Key,"");
                  HKEY_Key="margin_left" 
                  Wsh.RegWrite(HKEY_Root+HKEY_Path+HKEY_Key,"0"); //键值设定--左边边界

                  HKEY_Key="margin_top" 
                  Wsh.RegWrite(HKEY_Root+HKEY_Path+HKEY_Key,"0"); //键值设定--上边边界

                  HKEY_Key="margin_right" 
                  Wsh.RegWrite(HKEY_Root+HKEY_Path+HKEY_Key,"0"); //键值设定--右边边界

                  HKEY_Key="margin_bottom" 
                  Wsh.RegWrite(HKEY_Root+HKEY_Path+HKEY_Key,"0"); //键值设定--下边边界
            }


            
        function DrawImage(ImgD,ffitWidth,ffitHeight,stats) 
        { 
            var FitWidth=ImgD.width;
            var FitHeight=ImgD.height;
          
           
           if(stats=="big")
           {  if(FitWidth>3000 )
            {
               alert("已经很大了,不能再放大了");
               return false;
            }
              FitWidth=FitWidth*1.2;
              FitHeight=FitHeight*1.2;
           }
           else if(stats=="small")
           { if(FitWidth<300)
            {
               alert("已经很小了,不能再缩小了");
               return false;
            }
              if(FitHeight<200)
              {
              }
              else
              {
              FitWidth=FitWidth*0.8
              FitHeight=FitHeight*0.8;
              }
          }
          var image=new Image(); 
          image.src=ImgD.src; 
          if(image.width>0 && image.height>0) 
          {    
              ImgD.width=FitWidth; 
              ImgD.height=(image.height*FitWidth)/image.width; 
          } 
       }
       //旋转
        function Rotate(sort)
           {
           alert(sort);
            if(sort=="left")
            {
            
              var i= document.getElementById("hidLeft").value;
              alert("before"+i);
               if(i=="")
               {
                   i==3;
               }
               else
               {
                 i=(i==0)?3:(parseInt(i)+parseInt(1))
               }
               document.getElementById("hidLeft").value= i--;
            }
            else if(sort=="right")
            {
               
               var i= document.getElementById("hidRight").value;
               alert("before"+i);
               if(i=="")
               {
                   i==0;
               }
               else
               {
                 i=(i==3)?0:(parseInt(i)+parseInt(1))
               }
               i=i+1;
               document.getElementById("hidRight").value= i;
               alert("later"+i);
               alert(document.getElementById("hidRight").value);
            }
           
//            var i=document.getElementById("divPrint").style.filter.match(/\d/)[0]
//            i=(i==3)?0:(parseInt(i)+parseInt(1))
            document.getElementById("divPrint").style.filter='progid:DXImageTransform.Microsoft.BasicImage(Rotation='+i+')'
            }
            
            function saveas()
            {
               var btnsave= document.getElementById("btnSaveAs");
               btnsave.click();
            }
      </script> 
</head>
<body>
   <form id="form1" runat="server">
        <asp:HiddenField ID="hidLeft" runat ="server" />
        <asp:HiddenField ID="hidRight" runat="server" />
        <asp:Button ID="btnSaveAs" runat="server" style=" display:none"  />
        <table width="400" border="0" align="center" cellpadding="3" cellspacing="0" bgcolor="#D4D0C8">
		<tr style=" cursor:pointer; background:url(images/demo_line.jpg) top repeat-x"> 
         <%-- <td align="center" nowrap="nowrap" bgcolor="#ECE9D8">
          <img src="image/p1.png" border="0"   alt="打开" height=60></td>--%>
          <td align="center" nowrap="nowrap" bgcolor="#ECE9D8">
          <img src="image/bt_print.jpg" border="0" onclick="doPrint()"; alt="打印" height=60/></td>
          <td align="center" nowrap="nowrap" bgcolor="#ECE9D8">
          <img src="image/p7.jpg" border="0" name="SaveAsDlg" onclick="saveas()" title="另存为"   alt="另存为" height=60/></td> 
          <td align="center" nowrap="nowrap" bgcolor="#ECE9D8">
          <img src="image/p3.png" border="0" onclick="DrawImage(imgEmr,200,200,'big')" name="Big" alt="放大"  height=60/></td>
          <td align="center" nowrap="nowrap" bgcolor="#ECE9D8">
          <img src="image/p4.png" border="0" onclick="DrawImage(imgEmr,200,200,'small')" name="Small" alt="缩小"  height=60/></td>
        <%-- <td align="center" nowrap="nowrap" bgcolor="#ECE9D8">
          <img src="image/p6.jpg" border="0" name="RotateRight" onclick="Rotate('right')" alt="右转90度"  height=60/></td>
          <td align="center" nowrap="nowrap" bgcolor="#ECE9D8">
          <img src="image/p5.jpg" border="0" name="RotateLeft" onclick="Rotate('left')" alt="左转90度"  height=60/></td>  --%>
          </tr>
      </table>
       <!--startprint-->
    <div id="divPrint" style=" padding-left:80px; padding-top:30px; text-align:center" > 
       <asp:Image  runat="server" ID="imgEmr"  />
    </div><!--endprint-->
    </form>
</body>
</html>
