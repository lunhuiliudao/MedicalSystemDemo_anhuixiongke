using System;

namespace MedicalSystem.Anes.Document.Designer
{
	/// <summary>
    /// DesignerContainerItem.
	/// </summary>
	public class DesignerContainerItem
	{
		private string m_name = null;
		private Type m_type = null;

        public DesignerContainerItem()
		{
		}

		public string Name
		{
			get
			{
				return m_name;
			}
			set
			{
				m_name = value;
			}
		}

		public Type Type
		{
			get
			{
				return m_type;
			}
			set
			{
				m_type = value;
			}
		}

	}
}
