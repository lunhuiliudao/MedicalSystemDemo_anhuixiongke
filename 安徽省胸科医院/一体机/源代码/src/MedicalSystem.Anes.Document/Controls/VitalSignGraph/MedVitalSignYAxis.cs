/*----------------------------------------------------------------
      // Copyright (C) 2008 ���˹��(����)ҽ�ƿƼ���չ���޹�˾
      // �ļ�����MedVitalSignYAxis.cs
      // �ļ�������������������Y������
      //
      // 
      // ������ʶ��������-2008-10-21
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MedicalSystem.Anes.Document.Controls
{

    [Serializable]
    public class MedVitalSignYAxisScaleValueList : List<MedVitalSignYAxisScaleValue>
    {
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (MedVitalSignYAxisScaleValue scale in this)
            {
                stringBuilder.AppendLine(scale.Value + "," + scale.ShowText);
            }
            return stringBuilder.ToString();
        }

        public static MedVitalSignYAxisScaleValueList Parse(string listStrings)
        {
            MedVitalSignYAxisScaleValueList result = new MedVitalSignYAxisScaleValueList();
            if (listStrings != null)
            {
                string[] lists = listStrings.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string list in lists)
                {
                    string[] ls = list.Split(',');
                    MedVitalSignYAxisScaleValue scale = new MedVitalSignYAxisScaleValue();
                    scale.Value = double.Parse(ls[0]);
                    scale.ShowText = ls[1];
                    result.Add(scale);
                }
            }
            return result;
        }
    }

    [Serializable]
    public class MedVitalSignYAxisScaleValue
    {
        private string _showText;
        private double _value;
        [Description("�̶�ֵ")]
        public double Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }
        [Description("��ʾ�ı�")]
        public string ShowText
        {
            get
            {
                return _showText;
            }
            set
            {
                _showText = value;
            }
        }

        public override string ToString()
        {
            return _showText + "[" + _value.ToString() + "]";
        }
    }

    /// <summary>
    /// ��������Y������
    /// </summary>
    [Serializable]
    public class MedVitalSignYAxis
    {
        #region ���췽��

        public MedVitalSignYAxis() { }

        public MedVitalSignYAxis(MedVitalSignYAxisScaleValueList scaleValues, string unit)
        {
            _scaleValues = scaleValues;
            _unit = unit;
        }

        public MedVitalSignYAxis(double[] scaleValues, string unit)
        {
            MedVitalSignYAxisScaleValueList scales = new MedVitalSignYAxisScaleValueList();
            for (int i = 0; i < scaleValues.Length; i++)
            {
                scales.Add(new MedVitalSignYAxisScaleValue());
                scales[i].Value = scaleValues[i];
            }
            _scaleValues = scales;
            _unit = unit;
        }

        #endregion ���췽��

        #region ����

        /// <summary>
        /// �̶�ֵ
        /// </summary>
        private MedVitalSignYAxisScaleValueList _scaleValues;

        /// <summary>
        /// ��λ
        /// </summary>
        private string _unit;

        #endregion ����

        #region ����

        /// <summary>
        /// �̶�ֵ
        /// </summary>
        [Description("�̶�ֵ")]
        public MedVitalSignYAxisScaleValueList ScaleValues
        {
            get
            {
                return _scaleValues;
            }
            set
            {
                _scaleValues = value;
            }
        }

        private string _axisName = "Y������";
        /// <summary>
        /// �̶�ֵ
        /// </summary>
        [Description("����������")]
        public string AxisName
        {
            get
            {
                return _axisName;
            }
            set
            {
                _axisName = value;
            }
        }

        /// <summary>
        /// ��λ
        /// </summary>
        [Description("��λ")]
        public string Unit
        {
            get
            {
                return _unit;
            }
            set
            {
                _unit = value;
            }
        }

        #endregion ����

        public override string ToString()
        {
            return _axisName;
        }
    }
}
