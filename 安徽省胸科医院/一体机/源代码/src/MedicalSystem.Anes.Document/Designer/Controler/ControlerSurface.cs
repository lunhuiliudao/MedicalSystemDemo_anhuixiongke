using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using MedicalSystem.Anes.Document.Controls;

namespace MedicalSystem.Anes.Document.Designer 
{
    /// <summary>
    /// Inherits from DesignSurface and hosts the RootComponent and 
    /// all other designers. It also uses loaders (BasicDesignerLoader
    /// or CodeDomDesignerLoader) when required. It also provides various
    /// services to the designers. Adds MenuCommandService which is used
    /// for Cut, Copy, Paste, etc.
    /// </summary>
	public class ControlerSurface : DesignSurface
	{
		private BasicDesignerLoader _loader;
		private ISelectionService _selectionService; 

		public ControlerSurface() : base()
		{
            this.AddService(typeof(IMenuCommandService), new MenuCommandService(this));
            this.AddService(typeof(ComponentSerializationService), new CodeDomComponentSerializationService(this.ServiceContainer));
		}
        public ControlerSurface(IServiceProvider parentProvider)
            : base(parentProvider)
		{
            this.AddService(typeof(IMenuCommandService), new MenuCommandService(this));
            this.AddService(typeof(ComponentSerializationService), new CodeDomComponentSerializationService(this.ServiceContainer));
        }

		internal void Initialize()
		{

			Control control = null;
			IDesignerHost host = (IDesignerHost)this.GetService(typeof(IDesignerHost));

			if (host == null)
				return;

			try
			{
				// Set the backcolor
				Type hostType = host.RootComponent.GetType();
				if(hostType==typeof(Form))
				{
					control = this.View as Control;
					control.BackColor = Color.White;
                    
				}
				else if (hostType == typeof(UserControl))
				{
					control = this.View as Control;
					control.BackColor = Color.White;
				}
				else if (hostType == typeof(Component))
				{
					control = this.View as Control;
					control.BackColor = Color.FloralWhite;
				}
				else
				{
					throw new Exception("Undefined Host Type: " + hostType.ToString());
				}

				// Set SelectionService - SelectionChanged event handler
				_selectionService = (ISelectionService)(this.ServiceContainer.GetService(typeof(ISelectionService)));
				_selectionService.SelectionChanged += new EventHandler(selectionService_SelectionChanged);
			}
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }

		public BasicDesignerLoader Loader
		{
			get
			{
				return _loader;
			}
			set
			{
				_loader = value;
			}
		}

		/// <summary>
        /// When the selection changes this sets the PropertyGrid's selected component 
		/// </summary>
        private void selectionService_SelectionChanged(object sender, EventArgs e)
		{
			if (_selectionService != null)
			{
				ICollection selectedComponents = _selectionService.GetSelectedComponents();
				PropertyGrid propertyGrid = (PropertyGrid)this.GetService(typeof(PropertyGrid));


				object[] comps = new object[selectedComponents.Count];
				int i = 0;

				foreach (Object o in selectedComponents)
				{
					comps[i] = o;
					i++;
				}

				propertyGrid.SelectedObjects = comps;

                if (comps != null && comps.Length == 1)
                {
                    if (MyPasteHelper.IsPaste)
                    {
                        List<object> list = MyPasteHelper.PasteList;
                        if(list != null && list.Count > MyPasteHelper.PasteIndex)
                        {
                            if (comps[0].GetType().Equals(list[MyPasteHelper.PasteIndex].GetType()))
                            {
                                if (comps[0] is MedLabel)
                                {
                                    MyPasteHelper.CloneMedLabel(list[MyPasteHelper.PasteIndex] as MedLabel, (comps[0] as MedLabel));
                                }
                                if (comps[0] is MLabel)
                                {
                                    MyPasteHelper.CloneMLabel(list[MyPasteHelper.PasteIndex] as MLabel, (comps[0] as MLabel));
                                }
                                else if (comps[0] is MedTextBox)
                                {
                                    MyPasteHelper.CloneMedTextBox(list[MyPasteHelper.PasteIndex] as MedTextBox, (comps[0] as MedTextBox));
                                }
                                else if (comps[0] is MTextBox)
                                {
                                    MyPasteHelper.CloneMTextBox(list[MyPasteHelper.PasteIndex] as MTextBox, (comps[0] as MTextBox));
                                }
                                else if (comps[0] is MedMyLine)
                                {
                                    MyPasteHelper.CloneMedMyLine(list[MyPasteHelper.PasteIndex] as MedMyLine, (comps[0] as MedMyLine));
                                }
                                else if (comps[0] is CustomControl)
                                {
                                    MyPasteHelper.CloneCustomControl(list[MyPasteHelper.PasteIndex] as CustomControl, (comps[0] as CustomControl));
                                }
                                MyPasteHelper.PasteIndex++;
                                if (MyPasteHelper.PasteIndex < list.Count)
                                {
                                    MyPasteHelper.Paste();
                                }
                                else
                                {
                                    MyPasteHelper.IsPaste = false;
                                }
                            }
                        }
                    }
                }
			}
		}

		public void AddService(Type type, object serviceInstance)
		{
			this.ServiceContainer.AddService(type, serviceInstance);
		}
	}// class
}// namespace
