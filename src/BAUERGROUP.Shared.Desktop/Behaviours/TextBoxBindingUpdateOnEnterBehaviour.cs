using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfTextBox = System.Windows.Controls.TextBox;

namespace BAUERGROUP.Shared.Desktop.Behaviours
{
    public class TextBoxBindingUpdateOnEnterBehaviour : Behavior<WpfTextBox>
    {
        protected override void OnAttached()
        {
            AssociatedObject.KeyUp += OnTextBoxKeyUp;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.KeyUp -= OnTextBoxKeyUp;
        }

        private void OnTextBoxKeyUp(Object sender, System.Windows.Input.KeyEventArgs arguments)
        {
            if (arguments.Key == Key.Enter)
            {
                var textBox = sender as WpfTextBox;
                textBox?.GetBindingExpression(WpfTextBox.TextProperty)?.UpdateSource();
            }
        }
    }
}
