using System;

namespace MedicalSystem.Anes.Document.Designer
{
	/// <summary>
	/// DesignerContainerTabs.
	/// </summary>
	public class DesignerContainerTab
	{
		private string m_name = null;
		private DesignerContainerItemCollection m_DesignerContainerItemCollection = null;

		public DesignerContainerTab()
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

		public DesignerContainerItemCollection DesignerContainerItems
		{
			get
			{
				return m_DesignerContainerItemCollection;
			}
			set
			{
				m_DesignerContainerItemCollection = value;
			}
		}
	}
}
