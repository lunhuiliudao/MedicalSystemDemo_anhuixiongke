CREATE FUNCTION [dbo].[GetTableFromString]   
(     
    -- Add the parameters for the function here  
    @sourceStr nvarchar(max)   
)  
RETURNS @Table_NameList table ( Name Varchar(max))  -- 建立表变量   
AS  
BEGIN  
    Declare @Index_Param int   /*参数 记录分隔符的位置*/  
    Declare @NeedParse varchar(max) /*参数 没有处理的字符串*/  
    if(@sourceStr is NULL OR Ltrim(Rtrim(@sourceStr))='')  
        return  
    Select  @Index_Param=CharIndex(',', @sourceStr)  
    if (@Index_Param=0)  
    begin        /*一个名字组成*/  
        insert into @Table_NameList (Name) values(@sourceStr)  
    end  
    else   /*存在多个名字*/  
    begin  
        set @NeedParse =@sourceStr  
        while (CharIndex(',', @NeedParse)>0)  
        begin  
            insert into @Table_NameList (Name) values(SubString(@NeedParse,1,CharIndex(',',@NeedParse)-1))  
            set @NeedParse =SubString(@NeedParse,CharIndex(',', @NeedParse)+1,len(@NeedParse)-CharIndex(',', @NeedParse))  
        end  
        if(len(@NeedParse)>0)  
            insert into @Table_NameList (Name) values(@NeedParse)  
    end  
    return  
END  