/*�޸��ϴ�������ʽ*/
function fclick(obj){
	obj.style.left = calculateSumOffset(event.srcElement, 'offsetLeft');
}
function changeFileValue(obj,thick){
	obj.value=thick.value;
}

function calculateSumOffset(idItem, offsetName)
{
	var totalOffset = 0;
	var item = idItem;
	do
	{
		totalOffset += eval('item.'+offsetName);
		item = eval('item.offsetParent');
	} while (item != null);

	return totalOffset;
}


/*SigmaQQ�˵�*/
var currentMMenu = null;     //��ǰ���˵�
function mMenuEvent(thick){
try
{
	var total=0;             //����QQ�Ĳ˵�����
	var maxHeight = 0; 
	if(document.body.readyState=="complete"){
		maxHeight = eval("SigmaQQ").offsetHeight;
		for(var j=0;j<eval("SigmaQQ").childNodes.length;j++){
			if(eval("SigmaQQ").childNodes[j].className == "mMenu"){
				total++;
			}
		}
		
		var fatHeight = maxHeight - thick.offsetHeight*total;
		
		if(currentMMenu!=null && currentMMenu!=thick){
			var tempSMenu = currentMMenu.nextSibling;
			currentMMenu.childNodes[0].innerText = "4";
			tempSMenu.style.display='none';
		}

		var lastActiveMMenu = thick;	
		currentMMenu = thick;	
		var lastActiveSMenu = thick.nextSibling;
		lastActiveSMenu.style.pixelHeight	=fatHeight;
		lastActiveSMenu.style.display		=lastActiveSMenu.currentStyle.display=='none'?'block':'none';
		thick.childNodes[0].innerText		=lastActiveSMenu.currentStyle.display=='none'?'4':'6';

	}
	}
	catch(e)
	{
	alert(e.message);
	}
	
}

var currentSMenu = null; //��ǰ�Ӳ˵�
function sMenuEvent(thick){
	if(document.body.readyState=="complete"){
		if(currentSMenu!==null){
			currentSMenu.runtimeStyle.cssText=""
		}
		thick.runtimeStyle.cssText="background-color:#052C59;color:#FFF;font-weight:bold;"
		currentSMenu = thick;

	}
}
//����js���� 
function ResumeError() { 
return true; 
} 