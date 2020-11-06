namespace MedicalSystem.Anes.Document.Designer
{
    using System;
    using System.Collections;
    
    
    [Serializable()]
    public class DesignerContainerItemCollection : CollectionBase {
        
        ///  <summary>
        ///       Initializes a new instance of <see cref="ToolboxLibrary.DesignerContainerItemCollection"/>.
        ///  </summary>
        ///  <remarks></remarks>
        ///  <history>
        ///      [dineshc] 3/26/2003  Created
        ///  </history>
        public DesignerContainerItemCollection() {
        }
        
        ///  <summary>
        ///       Initializes a new instance of <see cref="ToolboxLibrary.DesignerContainerItemCollection"/> based on another <see cref="ToolboxLibrary.DesignerContainerItemCollection"/>.
        ///  </summary>
        ///  <param name="value">
        ///       A <see cref="ToolboxLibrary.DesignerContainerItemCollection"/> from which the contents are copied
        ///  </param>
        ///  <remarks></remarks>
        ///  <history>
        ///      [dineshc] 3/26/2003  Created
        ///  </history>
        public DesignerContainerItemCollection(DesignerContainerItemCollection value) {
            this.AddRange(value);
        }
        
        ///  <summary>
        ///       Initializes a new instance of <see cref="ToolboxLibrary.DesignerContainerItemCollection"/> containing any array of <see cref="ToolboxLibrary.DesignerContainerItem"/> objects.
        ///  </summary>
        ///  <param name="value">
        ///       A array of <see cref="ToolboxLibrary.DesignerContainerItem"/> objects with which to intialize the collection
        ///  </param>
        ///  <remarks></remarks>
        ///  <history>
        ///      [dineshc] 3/26/2003  Created
        ///  </history>
        public DesignerContainerItemCollection(DesignerContainerItem[] value)
        {
            this.AddRange(value);
        }
        
        ///  <summary>
        ///  Represents the entry at the specified index of the <see cref="ToolboxLibrary.DesignerContainerItem"/>.
        ///  </summary>
        ///  <param name="index">The zero-based index of the entry to locate in the collection.</param>
        ///  <value>
        ///  The entry at the specified index of the collection.
        ///  </value>
        ///  <remarks><exception cref="System.ArgumentOutOfRangeException"><paramref name="index"/> is outside the valid range of indexes for the collection.</exception></remarks>
        ///  <history>
        ///      [dineshc] 3/26/2003  Created
        ///  </history>
        public DesignerContainerItem this[int index] {
            get {
                return ((DesignerContainerItem)(List[index]));
            }
            set {
                List[index] = value;
            }
        }
        
        ///  <summary>
        ///    Adds a <see cref="ToolboxLibrary.DesignerContainerItem"/> with the specified value to the 
        ///    <see cref="ToolboxLibrary.DesignerContainerItemCollection"/> .
        ///  </summary>
        ///  <param name="value">The <see cref="ToolboxLibrary.DesignerContainerItem"/> to add.</param>
        ///  <returns>
        ///    The index at which the new element was inserted.
        ///  </returns>
        ///  <remarks><seealso cref="ToolboxLibrary.DesignerContainerItemCollection.AddRange"/></remarks>
        ///  <history>
        ///      [dineshc] 3/26/2003  Created
        ///  </history>
        public int Add(DesignerContainerItem value) {
            return List.Add(value);
        }
        
        ///  <summary>
        ///  Copies the elements of an array to the end of the <see cref="ToolboxLibrary.DesignerContainerItemCollection"/>.
        ///  </summary>
        ///  <param name="value">
        ///    An array of type <see cref="ToolboxLibrary.DesignerContainerItem"/> containing the objects to add to the collection.
        ///  </param>
        ///  <remarks><seealso cref="ToolboxLibrary.DesignerContainerItemCollection.Add"/></remarks>
        ///  <history>
        ///      [dineshc] 3/26/2003  Created
        ///  </history>
        public void AddRange(DesignerContainerItem[] value) {
            for (int i = 0; (i < value.Length); i = (i + 1)) {
                this.Add(value[i]);
            }
        }
        
        ///  <summary>
        ///     
        ///       Adds the contents of another <see cref="ToolboxLibrary.DesignerContainerItemCollection"/> to the end of the collection.
        ///    
        ///  </summary>
        ///  <param name="value">
        ///    A <see cref="ToolboxLibrary.DesignerContainerItemCollection"/> containing the objects to add to the collection.
        ///  </param>
        ///  <remarks><seealso cref="ToolboxLibrary.DesignerContainerItemCollection.Add"/></remarks>
        ///  <history>
        ///      [dineshc] 3/26/2003  Created
        ///  </history>
        public void AddRange(DesignerContainerItemCollection value) {
            for (int i = 0; (i < value.Count); i = (i + 1)) {
                this.Add(value[i]);
            }
        }
        
        ///  <summary>
        ///  Gets a value indicating whether the 
        ///    <see cref="ToolboxLibrary.DesignerContainerItemCollection"/> contains the specified <see cref="ToolboxLibrary.DesignerContainerItem"/>.
        ///  </summary>
        ///  <param name="value">The <see cref="ToolboxLibrary.DesignerContainerItem"/> to locate.</param>
        ///  <returns>
        ///  <see langword="true"/> if the <see cref="ToolboxLibrary.DesignerContainerItem"/> is contained in the collection; 
        ///   otherwise, <see langword="false"/>.
        ///  </returns>
        ///  <remarks><seealso cref="ToolboxLibrary.DesignerContainerItemCollection.IndexOf"/></remarks>
        ///  <history>
        ///      [dineshc] 3/26/2003  Created
        ///  </history>
        public bool Contains(DesignerContainerItem value) {
            return List.Contains(value);
        }
        
        ///  <summary>
        ///  Copies the <see cref="ToolboxLibrary.DesignerContainerItemCollection"/> values to a one-dimensional <see cref="System.Array"/> instance at the 
        ///    specified index.
        ///  </summary>
        ///  <param name="array">The one-dimensional <see cref="System.Array"/> that is the destination of the values copied from <see cref="ToolboxLibrary.DesignerContainerItemCollection"/> .</param>
        ///  <param name="index">The index in <paramref name="array"/> where copying begins.</param>
        ///  <remarks><exception cref="System.ArgumentException"><paramref name="array"/> is multidimensional. <para>-or-</para> <para>The number of elements in the <see cref="ToolboxLibrary.DesignerContainerItemCollection"/> is greater than the available space between <paramref name="arrayIndex"/> and the end of <paramref name="array"/>.</para></exception>
        ///  <exception cref="System.ArgumentNullException"><paramref name="array"/> is <see langword="null"/>. </exception>
        ///  <exception cref="System.ArgumentOutOfRangeException"><paramref name="arrayIndex"/> is less than <paramref name="array"/>"s lowbound. </exception>
        ///  <seealso cref="System.Array"/>
        ///  </remarks>
        ///  <history>
        ///      [dineshc] 3/26/2003  Created
        ///  </history>
        public void CopyTo(DesignerContainerItem[] array, int index) {
            List.CopyTo(array, index);
        }
        
        ///  <summary>
        ///    Returns the index of a <see cref="ToolboxLibrary.DesignerContainerItem"/> in 
        ///       the <see cref="ToolboxLibrary.DesignerContainerItemCollection"/> .
        ///  </summary>
        ///  <param name="value">The <see cref="ToolboxLibrary.DesignerContainerItem"/> to locate.</param>
        ///  <returns>
        ///  The index of the <see cref="ToolboxLibrary.DesignerContainerItem"/> of <paramref name="value"/> in the 
        ///  <see cref="ToolboxLibrary.DesignerContainerItemCollection"/>, if found; otherwise, -1.
        ///  </returns>
        ///  <remarks><seealso cref="ToolboxLibrary.DesignerContainerItemCollection.Contains"/></remarks>
        ///  <history>
        ///      [dineshc] 3/26/2003  Created
        ///  </history>
        public int IndexOf(DesignerContainerItem value) {
            return List.IndexOf(value);
        }
        
        ///  <summary>
        ///  Inserts a <see cref="ToolboxLibrary.DesignerContainerItem"/> into the <see cref="ToolboxLibrary.DesignerContainerItemCollection"/> at the specified index.
        ///  </summary>
        ///  <param name="index">The zero-based index where <paramref name="value"/> should be inserted.</param>
        ///  <param name=" value">The <see cref="ToolboxLibrary.DesignerContainerItem"/> to insert.</param>
        ///  <remarks><seealso cref="ToolboxLibrary.DesignerContainerItemCollection.Add"/></remarks>
        ///  <history>
        ///      [dineshc] 3/26/2003  Created
        ///  </history>
        public void Insert(int index, DesignerContainerItem value) {
            List.Insert(index, value);
        }
        
        ///  <summary>
        ///    Returns an enumerator that can iterate through 
        ///       the <see cref="ToolboxLibrary.DesignerContainerItemCollection"/> .
        ///  </summary>
        ///  <returns>An enumerator for the collection</returns>
        ///  <remarks><seealso cref="System.Collections.IEnumerator"/></remarks>
        ///  <history>
        ///      [dineshc] 3/26/2003  Created
        ///  </history>
        public new DesignerContainerItemEnumerator GetEnumerator() {
            return new DesignerContainerItemEnumerator(this);
        }
        
        ///  <summary>
        ///     Removes a specific <see cref="ToolboxLibrary.DesignerContainerItem"/> from the 
        ///    <see cref="ToolboxLibrary.DesignerContainerItemCollection"/> .
        ///  </summary>
        ///  <param name="value">The <see cref="ToolboxLibrary.DesignerContainerItem"/> to remove from the <see cref="ToolboxLibrary.DesignerContainerItemCollection"/> .</param>
        ///  <remarks><exception cref="System.ArgumentException"><paramref name="value"/> is not found in the Collection. </exception></remarks>
        ///  <history>
        ///      [dineshc] 3/26/2003  Created
        ///  </history>
        public void Remove(DesignerContainerItem value) {
            List.Remove(value);
        }
        
        public class DesignerContainerItemEnumerator : object, IEnumerator {
            
            private IEnumerator baseEnumerator;
            
            private IEnumerable temp;
            
            public DesignerContainerItemEnumerator(DesignerContainerItemCollection mappings) {
                this.temp = ((IEnumerable)(mappings));
                this.baseEnumerator = temp.GetEnumerator();
            }
            
            public DesignerContainerItem Current {
                get {
                    return ((DesignerContainerItem)(baseEnumerator.Current));
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
