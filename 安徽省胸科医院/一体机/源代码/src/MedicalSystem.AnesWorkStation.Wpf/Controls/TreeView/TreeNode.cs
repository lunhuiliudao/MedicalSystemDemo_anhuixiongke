using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.AnesWorkStation.Wpf.Controls.TreeView
{
    public class TreeNode
    {
        public string Label { get; set; }
        public TreeNode Parent { get; set; }
        public bool IsSelected { get; set; }
        public int Level { get; set; }

        public dynamic Tag { get; set; }

        private ObservableCollection<TreeNode> _ChildNodes = null;


        public IList<TreeNode> ChildNodes 
        { 
            get 
            { 
                return _ChildNodes ?? (_ChildNodes = new ObservableCollection<TreeNode>()); 
            } 
        }
    }
}
