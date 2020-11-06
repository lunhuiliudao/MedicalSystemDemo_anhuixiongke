namespace MedicalSystem.Anes.Document.Designer
{
    using System;
    using System.Collections;
    
    
     [Serializable()]
    public class DesignerContainerTabCollection : CollectionBase {
        
        public DesignerContainerTabCollection() {
        }
        
        public DesignerContainerTabCollection(DesignerContainerTabCollection value) {
            this.AddRange(value);
        }
        
        public DesignerContainerTabCollection(DesignerContainerTab[] value) {
            this.AddRange(value);
        }
        
         public DesignerContainerTab this[int index] {
            get {
                return ((DesignerContainerTab)(List[index]));
            }
            set {
                List[index] = value;
            }
        }
        
        public int Add(DesignerContainerTab value) {
            return List.Add(value);
        }
        
       public void AddRange(DesignerContainerTab[] value) {
            for (int i = 0; (i < value.Length); i = (i + 1)) {
                this.Add(value[i]);
            }
        }
        
        public void AddRange(DesignerContainerTabCollection value) {
            for (int i = 0; (i < value.Count); i = (i + 1)) {
                this.Add(value[i]);
            }
        }
        
        public bool Contains(DesignerContainerTab value) {
            return List.Contains(value);
        }
        
        public void CopyTo(DesignerContainerTab[] array, int index) {
            List.CopyTo(array, index);
        }
        
        public int IndexOf(DesignerContainerTab value) {
            return List.IndexOf(value);
        }
        
        public void Insert(int index, DesignerContainerTab value) {
            List.Insert(index, value);
        }
        
        public new ToolboxTabEnumerator GetEnumerator() {
            return new ToolboxTabEnumerator(this);
        }
        
        public void Remove(DesignerContainerTab value) {
            List.Remove(value);
        }
        
        public class ToolboxTabEnumerator : object, IEnumerator {
            
            private IEnumerator baseEnumerator;
            
            private IEnumerable temp;
            
            public ToolboxTabEnumerator(DesignerContainerTabCollection mappings) {
                this.temp = ((IEnumerable)(mappings));
                this.baseEnumerator = temp.GetEnumerator();
            }
            
            public DesignerContainerTab Current {
                get {
                    return ((DesignerContainerTab)(baseEnumerator.Current));
                }
            }
            
            object IEnumerator.Current {
                get {
                    return baseEnumerator.Current;
                }
            }
            
            public bool MoveNext() {
                return baseEnumerator.MoveNext();
            }
            
            bool IEnumerator.MoveNext() {
                return baseEnumerator.MoveNext();
            }
            
            public void Reset() {
                baseEnumerator.Reset();
            }
            
            void IEnumerator.Reset() {
                baseEnumerator.Reset();
            }
        }
    }
}
