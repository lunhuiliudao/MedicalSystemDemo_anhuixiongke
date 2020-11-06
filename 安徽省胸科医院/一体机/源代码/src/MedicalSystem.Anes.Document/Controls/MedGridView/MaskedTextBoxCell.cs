using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MedicalSystem.Anes.Document.Controls
{
    class MaskedTextBoxCell : DataGridViewTextBoxCell
    {
        private string mask;
        private char promptChar;
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
        public MaskedTextBoxCell()
            : base()
        {
            this.mask = "";
            this.promptChar = '_';
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
            MaskedTextBoxEditingControl mtbec;
            MaskedTextBoxColumn mtbcol;
            DataGridViewColumn dgvc;

            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                                          dataGridViewCellStyle);

            mtbec = DataGridView.EditingControl as MaskedTextBoxEditingControl;

            //
            // set up props that are specific to the MaskedTextBox
            //

            dgvc = this.OwningColumn;   // this.DataGridView.Columns[this.ColumnIndex];
            if (dgvc is MaskedTextBoxColumn)
            {
                mtbcol = dgvc as MaskedTextBoxColumn;

                //
                // get the mask from this instance or the parent column.
                //
                if (string.IsNullOrEmpty(this.mask))
                {
                    mtbec.Mask = mtbcol.Mask;
                }
                else
                {
                    mtbec.Mask = this.mask;
                }

                //
                // prompt char.
                //
                mtbec.PromptChar = this.PromptChar;

                //
                // IncludePrompt
                //
                if (this.includePrompt == DataGridViewTriState.NotSet)
                {
                    //mtbec.IncludePrompt = mtbcol.IncludePrompt;
                }
                else
                {
                    //mtbec.IncludePrompt = BoolFromTri(this.includePrompt);
                }

                //
                // IncludeLiterals
                //
                if (this.includeLiterals == DataGridViewTriState.NotSet)
                {
                    //mtbec.IncludeLiterals = mtbcol.IncludeLiterals;
                }
                else
                {
                    //mtbec.IncludeLiterals = BoolFromTri(this.includeLiterals);
                }

                //
                // Finally, the validating type ...
                //
                if (this.ValidatingType == null)
                {
                    mtbec.ValidatingType = mtbcol.ValidatingType;
                }
                else
                {
                    mtbec.ValidatingType = this.ValidatingType;
                }

                if (this.RowIndex >= 0)
                {
                    try
                    {
                        if (mtbec.Mask == "0000-00-00 00:00:00")
                        {
                            DateTime temp = (DateTime)this.Value;
                            string dateTime = temp.Year.ToString();
                            if (temp.Month > 10)
                                dateTime += temp.Month.ToString();
                            else
                                dateTime += "0" + temp.Month.ToString();
                            if (temp.Day > 10)
                                dateTime += temp.Day.ToString();
                            else
                                dateTime += "0" + temp.Day.ToString();
                            if (temp.Hour > 10)
                                dateTime += temp.Hour.ToString();
                            else
                                dateTime += "0" + temp.Hour.ToString();
                            if (temp.Minute > 10)
                                dateTime += temp.Minute.ToString();
                            else
                                dateTime += "0" + temp.Minute.ToString();
                            if (temp.Second > 10)
                                dateTime += temp.Second.ToString();
                            else
                                dateTime += "0" + temp.Second.ToString();
                            mtbec.Text = dateTime;
                        }
                        else if (this.Value.ToString().Length > 6)
                        {
                            DateTime temp = (DateTime)this.Value;
                            if (temp.Hour >= 10 && temp.Minute >= 10)
                                mtbec.Text = temp.Hour.ToString() + ":" + temp.Minute.ToString();
                            else if (temp.Hour >= 10 && temp.Minute < 10)
                                mtbec.Text = temp.Hour.ToString() + ":0" + temp.Minute.ToString();
                            else if (temp.Hour < 10 && temp.Minute >= 10)
                                mtbec.Text = "0" + temp.Hour.ToString() + ":" + temp.Minute.ToString();
                            else
                                mtbec.Text = "0" + temp.Hour.ToString() + ":0" + temp.Minute.ToString();
                        }
                        else
                            //mtbec.Text = (string)this.Value;
                            mtbec.Text = this.Value.ToString();
                    }
                    catch (Exception) { mtbec.Text = ""; }
                }
                else
                {
                    mtbec.Text = "";
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
                return typeof(MaskedTextBoxEditingControl);
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

        //  The character to use for prompting for new input.
        // 
        public virtual char PromptChar
        {
            get
            {
                return this.promptChar;
            }
            set
            {
                this.promptChar = value;
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
