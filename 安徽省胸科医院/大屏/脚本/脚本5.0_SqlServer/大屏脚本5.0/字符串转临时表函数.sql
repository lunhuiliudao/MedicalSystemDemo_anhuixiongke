CREATE FUNCTION [dbo].[GetTableFromString]   
(     
    -- Add the parameters for the function here  
    @sourceStr nvarchar(max)   
)  
RETURNS @Table_NameList table ( Name Varchar(max))  -- ���������   
AS  
BEGIN  
    Declare @Index_Param int   /*���� ��¼�ָ�����λ��*/  
    Declare @NeedParse varchar(max) /*���� û�д�����ַ���*/  
    if(@sourceStr is NULL OR Ltrim(Rtrim(@sourceStr))='')  
        return  
    Select  @Index_Param=CharIndex(',', @sourceStr)  
    if (@Index_Param=0)  
    begin        /*һ���������*/  
        insert into @Table_NameList (Name) values(@sourceStr)  
    end  
    else   /*���ڶ������*/  
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