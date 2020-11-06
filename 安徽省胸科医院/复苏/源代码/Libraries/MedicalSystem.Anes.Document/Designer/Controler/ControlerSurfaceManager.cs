using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Drawing.Design;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace MedicalSystem.Anes.Document.Designer
{
	public class ControlerSurfaceManager : DesignSurfaceManager
	{
        public ControlerSurfaceManager()
            : base()
		{
			this.AddService(typeof(INameCreationService), new NameCreationService());
           
            this.ActiveDesignSurfaceChanged += new ActiveDesignSurfaceChangedEventHandler(HostSurfaceManager_ActiveDesignSurfaceChanged);
		}

		protected override DesignSurface CreateDesignSurfaceCore(IServiceProvider parentProvider)
		{
            return new ControlerSurface(parentProvider);
		}

        public DesignerControler GetNewHost(Type rootComponentType)
		{
            ControlerSurface hostSurface = (ControlerSurface)this.CreateDesignSurface(this.ServiceContainer);
            IDesignerHost host = (IDesignerHost)hostSurface.GetService(typeof(IDesignerHost));

            BasicDesignerViewer basicHostLoader = new BasicDesignerViewer(rootComponentType);
            hostSurface.BeginLoad(basicHostLoader);
            hostSurface.Loader = basicHostLoader;
            return new DesignerControler(hostSurface);
		}

        public DesignerControler GetNewHost(string fileName)
		{
			if (fileName == null || !File.Exists(fileName))
				MessageBox.Show("FileName is incorrect: " + fileName);
            ControlerSurface hostSurface = (ControlerSurface)this.CreateDesignSurface(this.ServiceContainer);
			IDesignerHost host = (IDesignerHost)hostSurface.GetService(typeof(IDesignerHost));

            BasicDesignerViewer basicHostLoader = new BasicDesignerViewer(fileName);
            hostSurface.BeginLoad(basicHostLoader);
            hostSurface.Loader = basicHostLoader;
    		hostSurface.Initialize();
            return new DesignerControler(hostSurface);
		}

		public void AddService(Type type, object serviceInstance)
		{
			this.ServiceContainer.AddService(type, serviceInstance);
		}

		void HostSurfaceManager_ActiveDesignSurfaceChanged(object sender, ActiveDesignSurfaceChangedEventArgs e)
		{
            OutputWindow o = this.GetService(typeof(OutputWindow)) as OutputWindow;
            o.RichTextBox.Text += "New host added.\n";
		}
	}// class
}// namespace
