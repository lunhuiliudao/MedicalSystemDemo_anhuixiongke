using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace MedicalSystem.AnesWorkStation.Wpf.Controls
{
    /// <summary>
    ///     A column that displays a DateSelector.
    /// </summary>
    public class DataGridDateSelectorColumn : DataGridBoundColumn
    {

        #region Element Generation

        /// <summary>
        ///     Creates the visual tree for boolean based cells.
        /// </summary>
        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            return GenerateDateSelector(/* isEditing = */ false, cell);
        }

        /// <summary>
        ///     Creates the visual tree for boolean based cells.
        /// </summary>
        protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
        {
            return GenerateDateSelector(/* isEditing = */ true, cell);
        }

        private DateSelector GenerateDateSelector(bool isEditing, DataGridCell cell)
        {
            DateSelector dateSelector = (cell != null) ? (cell.Content as DateSelector) : null;
            if (dateSelector == null)
            {
                dateSelector = new DateSelector();
            }

            dateSelector.ConsumerFontSize = 13;
            dateSelector.InputTextWidth = 15;
            dateSelector.HorizontalAlignment = HorizontalAlignment.Center;
            ApplyBinding(dateSelector, DateSelector.SelectedDateProperty);
            ApplyBinding(dateSelector, DateSelector.CommandProperty);
            ApplyBinding(dateSelector, DateSelector.CommandParameterProperty);

            if (isEditing)
            {
                // 变换焦点才可以获取。
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    dateSelector.Focusable = true;
                    dateSelector.Focus();
                }), System.Windows.Threading.DispatcherPriority.Input);
            }

            return dateSelector;
        }

        internal void ApplyBinding(DependencyObject target, DependencyProperty property)
        {
            BindingBase binding = Binding;
            if (binding != null)
            {
                BindingOperations.SetBinding(target, property, binding);
            }
            else
            {
                BindingOperations.ClearBinding(target, property);
            }
        }

        #endregion

        #region Editing

        /// <summary>
        ///     Called when a cell has just switched to edit mode.
        /// </summary>
        /// <param name="editingElement">A reference to element returned by GenerateEditingElement.</param>
        /// <param name="editingEventArgs">The event args of the input event that caused the cell to go into edit mode. May be null.</param>
        /// <returns>The unedited value of the cell.</returns>
        protected override object PrepareCellForEdit(FrameworkElement editingElement, RoutedEventArgs editingEventArgs)
        {
            DateSelector dateSelector = editingElement as DateSelector;
            if (dateSelector != null)
            {
                // 变换焦点才可以获取。
                dateSelector.Focusable = false;

                return dateSelector.SelectedDate;
            }

            return (DateTime?)null;
        }

        #endregion

    }
}
