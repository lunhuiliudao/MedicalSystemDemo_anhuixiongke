namespace MedicalSystem.Anes.Document.Designer
{
	using System;
	using System.ComponentModel;
	using System.ComponentModel.Design;
	using System.ComponentModel.Design.Serialization;
	using System.Collections;
	using System.Diagnostics;
	using System.Globalization;
	using System.IO;
	using System.Reflection;
	using System.Runtime.Serialization.Formatters.Binary;
	using System.Text;
	using System.Windows.Forms;
	using System.Xml;
    using System.Collections.Generic;
    using MedicalSystem.Anes.Document.Controls;

	public class BasicDesignerViewer: BasicDesignerLoader
	{
		private bool _dirty = true;
		private bool _unsaved;
		private string fileName;
		private IDesignerLoaderHost host;
		private XmlDocument xmlDocument;
		private static readonly Attribute[] propertyAttributes = new Attribute[] {
			DesignOnlyAttribute.No
		};
		private Type rootComponentType;
		
		#region Constructors

		public BasicDesignerViewer(Type rootComponentType)
		{
			this.rootComponentType = rootComponentType;
            this.Modified = true;
		}

        public BasicDesignerViewer(string fileName)
		{
			if (fileName == null)
			{
				throw new ArgumentNullException("fileName");
			}

			this.fileName = fileName;
		}
		#endregion

        public bool WantSave
        {
            get
            {
                return _dirty && _unsaved;
            }
        }

        public void NeedSave()
        {
            _unsaved = true;
        }

		#region Overriden methods of BasicDesignerLoader

		protected override void PerformLoad(IDesignerSerializationManager designerSerializationManager)
		{
			this.host = this.LoaderHost;

			if (host == null)
			{
				throw new ArgumentNullException("BasicHostLoader.BeginLoad: Invalid designerLoaderHost.");
			}

			ArrayList errors = new ArrayList();
			bool successful = true;
			string baseClassName;

			if (fileName == null)
			{
                if (rootComponentType == typeof(Form))
				{
                    IComponent component = host.CreateComponent(rootComponentType);
                    (component as Form).FormBorderStyle = FormBorderStyle.None;
                    (component as Form).Size = Screen.PrimaryScreen.Bounds.Size;
					baseClassName = "Form1";
				}
				else if (rootComponentType == typeof(UserControl))
				{
					host.CreateComponent(typeof(UserControl));
					baseClassName = "UserControl1";
				}
				else if (rootComponentType == typeof(Component))
				{
					host.CreateComponent(typeof(Component));
					baseClassName = "Component1";
				}
				else
				{
					throw new Exception("Undefined Host Type: " + rootComponentType.ToString());
				}
			}
			else
			{
				baseClassName = AssemblyHelper.ReadFile(fileName, errors, out xmlDocument,host);
			}

			IComponentChangeService cs = host.GetService(typeof(IComponentChangeService)) as IComponentChangeService;

			if (cs != null)
			{
				cs.ComponentChanged += new ComponentChangedEventHandler(OnComponentChanged);
				cs.ComponentAdded += new ComponentEventHandler(OnComponentAddedRemoved);
				cs.ComponentRemoved += new ComponentEventHandler(OnComponentAddedRemoved);
			}

			host.EndLoad(baseClassName, successful, errors);

			_dirty = true;
			_unsaved = false;
		}

        protected override void PerformFlush(IDesignerSerializationManager designerSerializationManager)
		{
            if (!_dirty)
			{
				return;
			}

            xmlDocument = AssemblyHelper.WriteXmlDocument(host);
        }
		public override void Dispose()
		{
			IComponentChangeService cs = host.GetService(typeof(IComponentChangeService)) as IComponentChangeService;

			if (cs != null)
			{
				cs.ComponentChanged -= new ComponentChangedEventHandler(OnComponentChanged);
				cs.ComponentAdded -= new ComponentEventHandler(OnComponentAddedRemoved);
				cs.ComponentRemoved -= new ComponentEventHandler(OnComponentAddedRemoved);
			}
		}
		
		#endregion

		#region Helper methods

        private bool GetConversionSupported(TypeConverter converter, Type conversionType)
		{
			return (converter.CanConvertFrom(conversionType) && converter.CanConvertTo(conversionType));
		}

        private void OnComponentChanged(object sender, ComponentChangedEventArgs ce)
		{
            _dirty = true;
			_unsaved = true;
		}

		private void OnComponentAddedRemoved(object sender, ComponentEventArgs ce)
		{
            _dirty = true;
			_unsaved = true;
		}

        internal bool PromptDispose()
		{
            if (WantSave)
			{
				switch (MessageBox.Show("Save changes to existing designer?", "Unsaved Changes", MessageBoxButtons.YesNoCancel))
				{
					case DialogResult.Yes :
						Save(false);
						break;

					case DialogResult.Cancel :
						return false;
				}
			}

			return true;
		}

		#endregion

		#region Serialize - Flush

		#endregion

		#region DeSerialize - Load

        private void ReadEvent(XmlNode childNode, object instance, ArrayList errors)
        {
            IEventBindingService bindings = host.GetService(typeof(IEventBindingService)) as IEventBindingService;

            if (bindings == null)
            {
                errors.Add("Unable to contact event binding service so we can't bind any events");
                return;
            }

            XmlAttribute nameAttr = childNode.Attributes["name"];

            if (nameAttr == null)
            {
                errors.Add("No event name");
                return;
            }

            XmlAttribute methodAttr = childNode.Attributes["method"];

            if (methodAttr == null || methodAttr.Value == null || methodAttr.Value.Length == 0)
            {
                errors.Add(string.Format("Event {0} has no method bound to it"));
                return;
            }

            EventDescriptor evt = TypeDescriptor.GetEvents(instance)[nameAttr.Value];

            if (evt == null)
            {
                errors.Add(string.Format("Event {0} does not exist on {1}", nameAttr.Value, instance.GetType().FullName));
                return;
            }

            PropertyDescriptor prop = bindings.GetEventProperty(evt);

            Debug.Assert(prop != null, "Bad event binding service");
            try
            {
                prop.SetValue(instance, methodAttr.Value);
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
            }
        }

		#endregion

		#region Public methods

		public void Save()
		{
			Save(false);
		}

        public void Save(bool forceFilePrompt)
		{
			try
			{
				Flush();

				if ((fileName == null) || forceFilePrompt)
				{
					SaveFileDialog dlg = new SaveFileDialog();

					dlg.DefaultExt = "xml";
					dlg.Filter = "XML Files|*.xml";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        fileName = dlg.FileName;
                    }
                    else
                    {
                        return;
                    }
				}

                if (AssemblyHelper.WriteFile(fileName,xmlDocument))
                {
                    _unsaved = false;
                }
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error during save: " + ex.ToString());
			}
		}

		#endregion

	}// class
}// namespace

