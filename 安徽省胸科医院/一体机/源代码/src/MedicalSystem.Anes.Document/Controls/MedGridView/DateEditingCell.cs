using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MedicalSystem.Anes.Document.Controls
{
 

    class DateEditingCell : DataGridViewTextBoxCell
    {
        private string mask;
        private string displayFormat;
        private DataGridViewTriState includePrompt;
        private DataGridViewTriState includeLiterals;
        private Type validatingType;

        //=------------------------------------------------------------------=
        // MaskedTextBoxCell
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Initializes a new instance of this class.  Fortunately, there's
        ///   not much to do here except make sure that our base class is 
        ///   also initialized properly.
        /// </summary>
        /// 
        public DateEditingCell() : base()
        {
            //this.mask = "yyyy-MM-dd HH:mm";
            //this.displayFormat = "yyyy-MM-dd HH:mm";
            this.includePrompt = DataGridViewTriState.NotSet;
            this.includeLiterals = DataGridViewTriState.NotSet;
            this.validatingType = typeof(string);
        }

        ///   Whenever the user is to begin editing a cell of this type, the editing
        ///   control must be created, which in this column type's
        ///   case is a subclass of the MaskedTextBox control.
        /// 
        ///   This routine sets up all the properties and values
        ///   on this control before the editing begins.
        public override void InitializeEditingControl(int rowIndex,
                                                      object initialFormattedValue,
                                                      DataGridViewCellStyle dataGridViewCellStyle)
        {
            DateEditingControl dateEditingControl;
            DateEditingColumn dateEditingColumn;
            DataGridViewColumn dataGridViewColumn;

            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                                          dataGridViewCellStyle);

            dateEditingControl = DataGridView.EditingControl as DateEditingControl;

            //
            // set up props that are specific to the MaskedTextBox
            //

            dataGridViewColumn = this.OwningColumn;   // this.DataGridView.Columns[this.ColumnIndex];
            if (dataGridViewColumn is DateEditingColumn)
            {
                dateEditingColumn = dataGridViewColumn as DateEditingColumn;

                ////
                //// get the mask from this instance or the parent column.
                ////
                //if (string.IsNullOrEmpty(this.mask))
                //{
                //    dateEditingControl.Properties.Mask.EditMask = dateEditingColumn.Mask;
                //}
                //else
                //{
                //    dateEditingControl.Properties.Mask.EditMask = this.mask;
                //}

                ////
                //// displayFormat
                ////
                //if (string.IsNullOrEmpty(this.displayFormat))
                //{
                //    dateEditingControl.Properties.DisplayFormat.FormatString = dateEditingColumn.DisplayFormat;
                //}
                //else
                //{
                //    dateEditingControl.Properties.DisplayFormat.FormatString = this.mask;
                //}
                
                //dateEditingControl.EditValue = this.Value;
                if (this.Value != null)
                {
                    dateEditingControl.Text = this.Value.ToString();
                }
                else
                {
                    dateEditingControl.Text = "";
                }
              
               
            }
        }

        //  Returns the type of the control that will be used for editing
        //  cells of this type.  This control must be a valid Windows Forms
        //  control and must implement IDataGridViewEditingControl.
        public override Type EditType
        {
            get
            {
                return typeof(DateEditingControl);
            }
        }

        //   A string value containing the Mask against input for cells of
        //   this type will be verified.
        public virtual string Mask
        {
            get
            {
                return this.mask;
            }
            set
            {
                this.mask = value;
            }
        }

        public virtual string DisplayFormat
        {
            get
            {
                return this.displayFormat;
            }
            set
            {
                this.displayFormat = value;
            }
        }
        

        //  A boolean indicating whether to include prompt characters in
        //  the Text property's value.
        public virtual DataGridViewTriState IncludePrompt
        {
            get
            {
                return this.includePrompt;
            }
            set
            {
                this.includePrompt = value;
            }
        }

        //  A boolean value indicating whether to include literal characters
        //  in the Text property's output value.
        public virtual DataGridViewTriState IncludeLiterals
        {
            get
            {
                return this.includeLiterals;
            }
            set
            {
                this.includeLiterals = value;
            }
        }

        //  A Type object for the validating type.
        public virtual Type ValidatingType
        {
            get
            {
                return this.validatingType;
            }
            set
            {
                this.validatingType = value;
            }
        }

        //   Quick routine to convert from DataGridViewTriState to boolean.
        //   True goes to true while False and NotSet go to false.
        protected static bool BoolFromTri(DataGridViewTriState tri)
        {
            return (tri == DataGridViewTriState.True) ? true : false;
        }
    }
}
