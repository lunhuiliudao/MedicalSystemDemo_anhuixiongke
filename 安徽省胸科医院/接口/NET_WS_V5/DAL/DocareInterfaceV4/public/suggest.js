
         function Ajax(){
    
             //    doc.innerHTML='<span><img src="image/load.gif"/>Loading...</span>';
            ////创造对象 
            var xmlhttp;
            try
            {
                if (window.ActiveXObject){
                    /* 不要删除以下注释，这部分不是注释 */
                    /*@cc_on @*/
                    /*@if (@_jscript_version >= 5)
                    try {
                      xmlhttp = new ActiveXObject("Msxml2.xmlhttp");
                    } catch (e) {
                      try {
                        xmlhttp = new ActiveXObject("Microsoft.xmlhttp");
                      } catch (e) {
                        xmlhttp = false;
                      }
                    }
                    @end @*/
                }else{
                    xmlhttp=new XMLHttpRequest();
                }
                if (!xmlhttp && typeof XMLHttpRequest != 'undefined') {
                  xmlhttp = new XMLHttpRequest();
                }
            }
            catch(e)
            {
            alert(e.message);
            }
            //alert(xmlhttp);
            if(!xmlhttp)
            {
            alert("你的浏览器不支持xmlhttp对象,所以一些功能无法使用,建议使用高版本的浏览器!!");
            return;
            }

//     
            ///函数主题
                this.getData=function(url,data,dodata)
                {
                    var verbs =data;
                   // alert(data);
                    xmlhttp.open("POST", url,true);

                        xmlhttp.onreadystatechange=function(){
                            if (xmlhttp.readyState==4){
                                dodata(xmlhttp);                  
                            }
                        }
                    xmlhttp.setRequestHeader("Content-Length",verbs.length);
                    xmlhttp.setRequestHeader("CONTENT-TYPE","application/x-www-form-urlencoded");
                    xmlhttp.send(verbs);
                }
                /////
                this.getUrlData=function(url,data,dodata)
                {
                    xmlhttp.open("GET",url,true); 

                    xmlhttp.onreadystatechange = function() { 

                    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) { 
                      dodata(xmlhttp); 
                     Status.setStatusShow(false);
                    } 
                    else
                    {
                      Status.showInfo("加载中...");
                    }
                  
                    }
                     xmlhttp.setRequestHeader("CONTENT-TYPE","application/x-www-form-urlencoded"); 
                    xmlhttp.send(null); 
                }
                this.getFormData=function(demo)
                {
                alert(demo);
                }
            ///函数主题
}
/**
 * @author zxub 2006-06-01
 * 状态信息显示类，用var Status=new function()定义，可以静态引用其中的方法
 * 一般情况下为function Status()，这样不能静态引用其中的方法，需要通过对象来引用
 */
var Status=new function()
{
    this.statusDiv=null;
    
    /**
     * 初始化状态显示层
     */
 this.init=function()
 {
     if (this.statusDiv!=null)
     {
         return;
     }
  var body = document.getElementsByTagName("body")[0];
  var div = document.createElement("div");
  div.style.position = "absolute";
  div.style.top = "50%";
  div.style.left = "50%";
  div.style.width = "280px";
  div.style.margin = "-50px 0 0 -100px";  
  div.style.padding = "15px";
  div.style.backgroundColor = "#353555";
  div.style.border = "1px solid #CFCFFF";
  div.style.color = "#CFCFFF";
  div.style.fontSize = "14px";
  div.style.textAlign = "center";
  div.id = "idstatus";
  body.appendChild(div);
  div.style.display="none";
  this.statusDiv=document.getElementById("idstatus");
 }
 this.init=function(obj)
 {
     if (this.statusDiv!=null)
     {
         return;
     }
     var postion=GetPosition(obj);
  var body = document.getElementsByTagName("body")[0];
  var div = document.createElement("div");
  div.style.position = "absolute";
  div.style.top = ((postion.y+postion.height)+"px");
  div.style.left = postion.x+"px";
  div.style.width = "280px";
  div.style.height = "120px";
  div.style.margin = "0 0 0 0";  
  div.style.padding = "15px";
  div.style.backgroundColor = "#FFFFCC";
  div.style.border = "1px solid #CFCFFF";
  div.style.color = "#000000";
  div.style.fontSize = "14px";
  div.style.textAlign = "left";
  div.style.overFlowX = "scroll";
   var randomName = Math.ceil(Math.random()*1000);

  div.id = "id"+randomName;
  body.appendChild(div);
  div.style.display="none";
  this.statusDiv=document.getElementById(div.id);
 }
 /**
  * 设置状态信息
  * @param _message:要显示的信息
  */ 
 this.showInfo=function(_message)
 {   
     if (this.statusDiv==null)
     {
         this.init();
     }  
     this.setStatusShow(true);
     this.statusDiv.innerHTML = _message;     
 }
   this.showInfo=function(_message,obj)
 {   

     if (this.statusDiv==null)
     {
         this.init(obj);
     }  
   
     this.setStatusShow(true,obj);
     this.statusDiv.innerHTML = _message;     
 }
  
 /**
  * 设置状态层是否显示
  * @param _show:boolean值，true为显示，false为不显示
  */ 
 this.setStatusShow=function(_show)
 {   
     if (this.statusDiv==null)
     {
         this.init();
     } 
     if (_show)
     {
         this.statusDiv.style.display="";
     }
     else
     {
         this.statusDiv.innerHTML="";
         this.statusDiv.style.display="none";
        
     }
     
 }
  this.setStatusShow=function(_show,obj)
 {   

   if (this.statusDiv==null)
     {
     this.init(obj);
     }
     if (_show)
     {
         this.statusDiv.style.display="";
     }
     else
     {
      
         this.statusDiv.innerHTML="";
         this.statusDiv.style.display="none";
         this.statusDiv=null;
     }
 }
}
function GetPosition(element) {
    var result = new Object();
    result.x = 0;
    result.y = 0;
    result.width = 0;
    result.height = 0;
    if (element.offsetParent) {
        result.x = element.offsetLeft;
        result.y = element.offsetTop;
        var parent = element.offsetParent;
        while (parent) {
            result.x += parent.offsetLeft;
            result.y += parent.offsetTop;
            var parentTagName = parent.tagName.toLowerCase();
            if (parentTagName != "table" &&
                parentTagName != "body" && 
                parentTagName != "html" && 
                parentTagName != "div" && 
                parent.clientTop && 
                parent.clientLeft) {
                result.x += parent.clientLeft;
                result.y += parent.clientTop;
            }
            parent = parent.offsetParent;
        }
    }
    else if (element.left && element.top) {
        result.x = element.left;
        result.y = element.top;
    }
    else {
        if (element.x) {
            result.x = element.x;
        }
        if (element.y) {
            result.y = element.y;
        }
    }
    if (element.offsetWidth && element.offsetHeight) {
        result.width = element.offsetWidth;
        result.height = element.offsetHeight;
    }
    else if (element.style && element.style.pixelWidth && element.style.pixelHeight) {
        result.width = element.style.pixelWidth;
        result.height = element.style.pixelHeight;
    }
    return result;
} 
//屏蔽js错误 
function ResumeError() { 
return true; 
} 