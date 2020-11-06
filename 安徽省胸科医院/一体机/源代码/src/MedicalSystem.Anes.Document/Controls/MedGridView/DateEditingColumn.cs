using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
namespace MedicalSystem.Anes.Document.Controls
{

    public class DateEditingColumn : DataGridViewColumn
    {
        private string mask;
        private string displayFormat;
        private bool includePrompt;
        private bool includeLiterals;
        private Type validatingType;


        public DateEditingColumn()
            : base(new DateEditingCell())
        {
        }


        private static DataGridViewTriState TriBool(bool value)
        {
            return value ? DataGridViewTriState.True
                         : DataGridViewTriState.False;
        }



        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }

            set
            {
                //  Only cell types that derive from DateEditingCell are supported as the cell template.
                if (value != null && !value.GetType().IsAssignableFrom(typeof(DateEditingCell)))
                {
                    string s = "Cell type is not based upon the DateEditingCell.";//CustomColumnMain.GetResourceManager().GetString("excNotMaskedTextBox");
                    throw new InvalidCastException(s);
                }

                base.CellTemplate = value;
            }
        }

        //  Indicates the Mask property that is used on the MaskedTextBox
        //  for entering new data into cells of this type.
        // 
        //  See the MaskedTextBox control documentation for more details.
        public virtual string Mask
        {
            get
            {
                return this.mask;
            }
            set
            {
                DateEditingCell dateEditingCell;
                DataGridViewCell dgvc;
                int rowCount;

                if (this.mask != value)
                {
                    this.mask = value;

                    //
                    // first, update the value on the template cell.
                    //
                    dateEditingCell = (DateEditingCell)this.CellTemplate;
                    dateEditingCell.Mask = value;

                    //
                    // now set it on all cells in other rows as well.
                    //
                    if (this.DataGridView != null && this.DataGridView.Rows != null)
                    {
                        rowCount = this.DataGridView.Rows.Count;
                        for (int x = 0; x < rowCount; x++)
                        {
                            dgvc = this.DataGridView.Rows.SharedRow(x).Cells[x];
                            if (dgvc is DateEditingCell)
                            {
                                dateEditingCell = (DateEditingCell)dgvc;
                                dateEditingCell.Mask = value;
                            }
                        }
                    }
                }
            }
        }


        //  By default, the MaskedTextBox uses the underscore (_) character
        //  to prompt for required characters.  This propertly lets you 
        //  choose a different one.
        // 
        //  See the MaskedTextBox control documentation for more details.
        public virtual string DisplayFormat
        {
            get
            {
                return this.displayFormat;
            }
            set
            {
                DateEditingCell dateEditingCell;
                DataGridViewCell dgvc;
                int rowCount;

                if (this.displayFormat != value)
                {
                    this.displayFormat = value;

                    //
                    // first, update the value on the template cell.
                    //
                    dateEditingCell = (DateEditingCell)this.CellTemplate;

                    //
                    // now set it on all cells in other rows as well.
                    //
                    if (this.DataGridView != null && this.DataGridView.Rows != null)
                    {
                        rowCount = this.DataGridView.Rows.Count;
                        for (int x = 0; x < rowCount; x++)
                        {
                            dgvc = this.DataGridView.Rows.SharedRow(x).Cells[x];
                            if (dgvc is DateEditingCell)
                            {
                                dateEditingCell = (DateEditingCell)dgvc;
                                dateEditingCell.DisplayFormat = value;
                            }
                        }
                    }
                }
            }
        }

        //   Indicates whether any unfilled characters in the mask should be
        //   be included as prompt characters when somebody asks for the text
        //   of the MaskedTextBox for a particular cell programmatically.
        // 
        //   See the MaskedTextBox control documentation for more details.
        public virtual bool IncludePrompt
        {
            get
            {
                return this.includePrompt;
            }
            set
            {
                DateEditingCell mtbc;
                DataGridViewCell dgvc;
                int rowCount;

                if (this.includePrompt != value)
                {
                    this.includePrompt = value;

                    //
                    // first, update the value on the template cell.
                    //
                    mtbc = (DateEditingCell)this.CellTemplate;
                    mtbc.IncludePrompt = TriBool(value);

                    //
                    // now set it on all cells in other rows as well.
                    //
                    if (this.DataGridView != null && this.DataGridView.Rows != null)
                    {
                        rowCount = this.DataGridView.Rows.Count;
                        for (int x = 0; x < rowCount; x++)
                        {
                            dgvc = this.DataGridView.Rows.SharedRow(x).Cells[x];
                            if (dgvc is DateEditingCell)
                            {
                                mtbc = (DateEditingCell)dgvc;
                                mtbc.IncludePrompt = TriBool(value);
                            }
                        }
                    }
                }
            }
        }

        //  Controls whether or not literal (non-prompt) characters should
        //  be included in the output of the Text property for newly entered
        //  data in a cell of this type.
        // 
        //  See the MaskedTextBox control documentation for more details.
        public virtual bool IncludeLiterals
        {
            get
            {
                return this.includeLiterals;
            }
            set
            {
                DateEditingCell mtbc;
                DataGridViewCell dgvc;
                int rowCount;

                if (this.includeLiterals != value)
                {
                    this.includeLiterals = value;

                    //
                    // first, update the value on the template cell.
                    //
                    mtbc = (DateEditingCell)this.CellTemplate;
                    mtbc.IncludeLiterals = TriBool(value);

                    //
                    // now set it on all cells in other rows as well.
                    //
                    if (this.DataGridView != null && this.DataGridView.Rows != null)
                    {

                        rowCount = this.DataGridView.Rows.Count;
                        for (int x = 0; x < rowCount; x++)
                        {
                            dgvc = this.DataGridView.Rows.SharedRow(x).Cells[x];
                            if (dgvc is DateEditingCell)
                            {
                                mtbc = (DateEditingCell)dgvc;
                                mtbc.IncludeLiterals = TriBool(value);
                            }
                        }
                    }
                }
            }
        }

        //  Indicates the type against any data entered in the MaskedTextBox
        //  should be validated.  The MaskedTextBox control will attempt to
        //  instantiate this type and assign the value from the contents of
        //  the text box.  An error will occur if it fails to assign to this
        //  type.
        //
        //  See the MaskedTextBox control documentation for more details.
        public virtual Type ValidatingType
        {
            get
            {
                return this.validatingType;
            }
            set
            {
                DateEditingCell dateEditingCell;
                DataGridViewCell dgvc;
                int rowCount;

                if (this.validatingType != value)
                {
                    this.validatingType = value;

                    //
                    // first, update the value on the template cell.
                    //
                    dateEditingCell = (DateEditingCell)this.CellTemplate;
                    dateEditingCell.ValidatingType = value;

                    //
                    // now set it on all cells in other rows as well.
                    //
                    if (this.DataGridView != null && this.DataGridView.Rows != null)
                    {
                        rowCount = this.DataGridView.Rows.Count;
                        for (int x = 0; x < rowCount; x++)
                        {
                            dgvc = this.DataGridView.Rows.SharedRow(x).Cells[x];
                            if (dgvc is DateEditingCell)
                            {
                                dateEditingCell = (DateEditingCell)dgvc;
                                dateEditingCell.ValidatingType = value;
                            }
                        }
                    }
                }
            }
        }

    }
}
