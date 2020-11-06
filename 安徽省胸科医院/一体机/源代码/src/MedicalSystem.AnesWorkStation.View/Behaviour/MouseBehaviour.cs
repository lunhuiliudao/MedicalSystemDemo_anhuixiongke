using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace MedicalSystem.AnesWorkStation.View.Behaviour
{
    public class MouseBehaviour : Behavior<UIElement>
    {
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(MouseBehaviour), new PropertyMetadata(null));
        

        public double MouseY { get; set; }


        public double MouseX { get; set; }
        
        protected override void OnAttached()
        {
            AssociatedObject.MouseMove += AssociatedObjectOnMouseMove;
            AssociatedObject.PreviewMouseDown += AssociatedObject_MouseDown;
        }

        void AssociatedObject_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Command != null)
            {
                Command.Execute(string.Empty);
            }
        }

        private void AssociatedObjectOnMouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            var pos = AssociatedObject.PointToScreen(mouseEventArgs.GetPosition(AssociatedObject));
            MouseX = pos.X;
            MouseY = pos.Y;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseMove -= AssociatedObjectOnMouseMove;
            AssociatedObject.MouseDown -= AssociatedObject_MouseDown;
        }
        
    }
}
