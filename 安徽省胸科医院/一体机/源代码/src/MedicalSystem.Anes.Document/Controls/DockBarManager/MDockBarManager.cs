using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraBars.Docking;
using System.Windows.Forms;
using System.ComponentModel;
using DevExpress.XtraBars.Docking.Helpers;

namespace MedicalSystem.Anes.Document.Controls
{
    [ToolboxItem(false)]
    public class MDockBarManager : DockManager
    {
        public MDockBarManager() : base() { }
        public MDockBarManager(ContainerControl form) : base(form) { }
        public MDockBarManager(IContainer container) : base(container) { }
        protected override DevExpress.XtraBars.Docking.Helpers.DockLayoutManager CreateLayoutManager()
        {
            return new MDockLayoutManager(this);
        }
    }
    public class MDockLayoutManager : DockLayoutManager
    {
        public MDockLayoutManager(DockManager manager) : base(manager) { }
        protected override CaptionMouseHoverHelper CreateCaptionMouseHoverHelper()
        {
            return new MCaptionMouseHoverHelper(this);
        }
    }

    public class MCaptionMouseHoverHelper : CaptionMouseHoverHelper
    {
        public MCaptionMouseHoverHelper(DockLayoutManager manager) : base(manager) { }
        public override bool CanShowCaption(DockPanel panel)
        {
            return panel.Name != "topPanel";
        }
    }

}
