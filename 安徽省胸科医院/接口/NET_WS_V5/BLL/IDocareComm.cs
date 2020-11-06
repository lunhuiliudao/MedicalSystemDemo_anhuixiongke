using System;
using System.Collections.Generic;
using System.Text;
using Init;
using System.Data.Common;
using MedicalSytem.Soft.Model;

namespace BLL
{
    public interface IDocareComm
    {

        DbParameter[] GetPara(EnumDataBase database);

        /// <summary>
        /// 数据库同步，试图，存储过程，function，表，直连等等
        /// </summary>
        /// <param name="config"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        string PreDataBase(InitDocare.Config2 config, ParamInputDomain domain);

        /// <summary>
        /// web 服务同步，包括XML，json,HL7,cdr 等等
        /// </summary>
        /// <param name="config"></param>
        /// <param name="domain"></param> 
        /// <returns></returns>
        string PreWebServices(InitDocare.Config2 config, ParamInputDomain domain);

        /// <summary>
        /// 接受推送信息，包括xml,json,hl7,cdr 等等
        /// </summary>
        /// <param name="config"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        string PreReceiveMsg(InitDocare.Config2 config, ParamInputDomain domain);

        /// <summary>
        /// 处理消息值，mess 可能是xml ,josn, HL7 ,cdr 
        /// </summary>
        /// <param name="config"></param>
        /// <param name="xml"></param>
        /// <returns></returns>
        string DoExecute(InitDocare.Config2 config, ParamInputDomain domain, ModelBase obj);
    }
}
