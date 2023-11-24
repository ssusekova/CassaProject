using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace CassaProject.Controls
{
    public class BaseNumDigTextBox : TextBox
    {
        protected readonly string allowedChars;

        public BaseNumDigTextBox(string allowedChars) : base()
        {
            this.allowedChars = allowedChars;
        }

        public string Format
        {
            get { return (string)this.GetValue(FormatProperty); }
            set { this.SetValue(FormatProperty, value); }
        }
        public static readonly DependencyProperty FormatProperty = DependencyProperty.Register(
          "Format", typeof(string), typeof(BaseNumDigTextBox), new PropertyMetadata("N2"));

        protected override void OnTextInput(TextCompositionEventArgs e)
        {
            if (!allowedChars.Contains(e.Text))
                e.Handled = true;

            base.OnTextInput(e);
        }


        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);
        }
    }
}
