/*----------------------------------------------------------------
      // Copyright (C) 2008 ���˹��(����)ҽ�ƿƼ���չ���޹�˾
      // �ļ�����AssemblyHelper.cs
      // �ļ��������������򼯸�����
      //
      // 
      // ������ʶ��������-2008-10-30
      //
----------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;

namespace MedicalSystem.AnesWorkStation.Model.DocControl
{
    /// <summary>
    /// ���򼯸�����
    /// </summary>
    public class AssemblyHelper
    {

        public static List<MemberDetail> GetEnumList(Type type)
        {
            return GetEnumList(type, false);
        }

        public static List<MemberDetail> GetEnumList(Type type, bool wantDescriptionAttribute)
        {
            List<MemberDetail> list = GetMemberList(type, MemberTypes.Field, wantDescriptionAttribute);
            foreach (MemberDetail member in list)
            {
                if (member.Value.Equals("value__"))
                {
                    list.Remove(member);
                    break;
                }
            }
            foreach (MemberDetail member in list)
            {
                member.Value = Enum.Parse(type, member.Value.ToString());
            }
            return list;
        }

        public static List<MemberDetail> GetMemberList(Type type, MemberTypes memberType, bool wantDescriptionAttribute)
        {
            MemberInfo[] memberInfos = type.GetMembers();
            List<MemberDetail> enumList = new List<MemberDetail>();
            foreach (MemberInfo memberInfo in memberInfos)
            {
                if (memberInfo.MemberType == memberType)
                {
                    object[] objs = memberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (objs != null && objs.Length > 0)
                    {
                        enumList.Add(new MemberDetail(((DescriptionAttribute)objs[0]).Description, memberInfo.Name, type));
                    }
                    else
                    {
                        if (!wantDescriptionAttribute)
                        {
                            enumList.Add(new MemberDetail(memberInfo.Name, memberInfo.Name, type));
                        }
                    }
                }
            }
            return enumList;
        }
    }
}
