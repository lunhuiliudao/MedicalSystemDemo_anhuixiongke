using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.AnesWorkStation.Wpf.Controls.TreeView
{
    public class TreeViewData
    {
        private ObservableCollection<TreeNode> _RootNodes = null;

        public IList<TreeNode> RootNodes 
        {
            get 
            { 
                return _RootNodes ?? (_RootNodes = new ObservableCollection<TreeNode>()); 
            } 
        }
    }
}
 