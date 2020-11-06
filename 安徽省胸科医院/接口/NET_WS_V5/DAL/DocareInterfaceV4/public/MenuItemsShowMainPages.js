
function ShowMain()
{
    if(FileName_Left != "")
    {
        var checkLeftUrl = CheckCurrentLeftUrl(FileName_Left);
        if(checkLeftUrl=="false")
        {
            document.getElementById("left").src = FileName_Left + GetUrlParm(FileName_Left);
        }
    }
    if(FileName_Right != "")
    {
        document.getElementById("main_right").src = FileName_Right + GetUrlParm(FileName_Right);
    }
} 
