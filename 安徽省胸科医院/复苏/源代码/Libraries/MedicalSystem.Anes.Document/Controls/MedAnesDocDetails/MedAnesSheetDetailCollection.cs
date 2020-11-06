/*----------------------------------------------------------------
      // Copyright (C) 2008 ���˹��(����)ҽ�ƿƼ���չ���޹�˾
      // �ļ�����MedAnesSheetDetailCollection.cs
      // �ļ�����������������ϸ������
      //
      // 
      // ������ʶ��������-2008-10-24
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MedicalSystem.Anes.Document.Constants; 

namespace MedicalSystem.Anes.Document.Controls
{

    /// <summary>
    /// ������
    /// </summary>
    public enum CollectionType
    {
        /// <summary>
        /// �¼�
        /// </summary>
        Event,
        /// <summary>
        /// ��ҩ
        /// </summary>
        Drug,
        /// <summary>
        /// ����
        /// </summary>
        Total
    }

    /// <summary>
    /// ������ϸ������
    /// </summary>
    [Serializable]
    public class MedAnesSheetDetailCollection
    {

        #region ���췽��

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="text">�ı������ƣ�</param>
        /// <param name="color">��ɫ</param>
        /// <param name="type">����</param>
        public MedAnesSheetDetailCollection(string text, Color color, CollectionType type)
        {
            _text = text;
            _color = color;
            _collectionType = type;
        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="text">�ı������ƣ�</param>
        /// <param name="color">��ɫ</param>
        public MedAnesSheetDetailCollection(string text, Color color) : this(text, color, CollectionType.Event) { }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="text">�ı������ƣ�</param>
        /// <param name="color">��ɫ</param>
        public MedAnesSheetDetailCollection(string text) : this(text, Color.Black) { }

        #endregion ���췽��

        #region ����

        /// <summary>
        /// �ı������ƣ�
        /// </summary>
        private string _text;

        /// <summary>
        /// ��ɫ
        /// </summary>
        private Color _color;

        /// <summary>
        /// �㼯��
        /// </summary>
        private List<MedAnesSheetDetailPoint> _points = new List<MedAnesSheetDetailPoint>();

        /// <summary>
        /// ������
        /// </summary>
        private CollectionType _collectionType = CollectionType.Total;

        #endregion ����

        #region ����

        /// <summary>
        /// �ı������ƣ�
        /// </summary>
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }

        /// <summary>
        /// ��ɫ
        /// </summary>
        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        /// <summary>
        /// �㼯��
        /// </summary>
        public List<MedAnesSheetDetailPoint> Points
        {
            get
            {
                return _points;
            }
            set
            {
                _points = value;
            }
        }

        /// <summary>
        /// ������
        /// </summary>
        public CollectionType CollectionType
        {
            get
            {
                return _collectionType;
            }
            set
            {
                _collectionType = value;
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        public double TotalValue
        {
            get
            {
                double result = 0;
                if (_points != null && _points.Count > 0)
                {
                    foreach (MedAnesSheetDetailPoint point in _points)
                    {
                        result += point.Value;
                    }
                }
                return result;
            }
        }

        #endregion ����

        #region ����
        /// <summary>
        /// ��ʱ�������������
        /// </summary>
        public void Sort()
        {
            if (_points != null && _points.Count > 0)
            {
                _points.Sort(new Comparison<MedAnesSheetDetailPoint>(delegate(MedAnesSheetDetailPoint p1, MedAnesSheetDetailPoint p2)
                {
                    if (p1.StartTime < p2.StartTime) return -1;
                    else if (p1.StartTime > p2.StartTime) return 1;
                    else
                    {
                        if ((p1.Text.Contains("����") || p1.Text.Contains("��������")) && !(p2.Text.Contains("����") || p2.Text.Contains("��������")))
                        {
                            return -1;
                        }
                        else if ((p2.Text.Contains("����") || p2.Text.Contains("��������")) && !(p1.Text.Contains("����") || p1.Text.Contains("��������")))
                        {
                            return 1;
                        }
                        else if ((p1.Text.Contains(EventNames.INPACU) || p1.Text.Contains("�븴����")) && !(p2.Text.Contains(EventNames.INPACU) || p2.Text.Contains("�븴����")))
                        {
                            return -1;
                        }
                        else if ((p2.Text.Contains(EventNames.INPACU) || p2.Text.Contains("�븴����")) && !(p1.Text.Contains(EventNames.INPACU) || p1.Text.Contains("�븴����")))
                        {
                            return 1;
                        }
                        else
                        {
                            return p1.Text.CompareTo(p2.Text);
                        }
                    }
                }));
                for (int i = 0; i < _points.Count; i++)
                {
                    _points[i].Index = i + 1;
                }
            }
        }

        /// <summary>
        /// ������һ������ϸ����������е�
        /// </summary>
        /// <param name="collection"></param>
        public void Add(MedAnesSheetDetailCollection collection)
        {
            if (_points == null) _points = new List<MedAnesSheetDetailPoint>();
            if (collection != null && collection.Points != null & collection.Points.Count > 0)
            {
                foreach (MedAnesSheetDetailPoint point in collection.Points)
                {
                    point.Color = collection.Color;
                    _points.Add(point);
                }
            }
        }

        #endregion ����

    }
}
