function ShowHidLayer(str)
{
    var arr = new Array("MenuTopDesk","MenuTopBusiness");
    for(var i = 0 ;i < arr.length;i++)
    {
        if(arr[i].toString() != str)
        {
//            if(document.getElementById(arr[i].toString()).style.display !="none")
//            {
//                document.getElementById(arr[i].toString()).style.display = "none";
//            }
            if(document.getElementById(arr[i].toString() + "Href").style.backgroundImage !="url(./Images/digital_left.gif)")
            {
                document.getElementById(arr[i].toString() + "Href").style.backgroundImage = "url(./Images/digital_left.gif)";
                document.getElementById(arr[i].toString() + "Span").style.backgroundImage = "url(./Images/digital_side.gif)";
                document.getElementById(arr[i].toString() + "Span").className = "digitaltext";
            }
        }
        else
        {
            document.getElementById(str).style.display = "";
            document.getElementById(str+"Href").style.backgroundImage ="url(./Images/seg_left.gif)";
            document.getElementById(str+"Span").style.backgroundImage = "url(./Images/seg_side.gif)";
            document.getElementById(str+"Span").className = "segtext";
        }
    }
}

