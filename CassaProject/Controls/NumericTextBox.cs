using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace CassaProject.Controls
{
    public class NumericTextBox : TextBox
    {
        private readonly string allowedChars = "0123456789.,-";
        public NumericTextBox() : base()
        {

        }
        public string Format
        {
            get { return (string)this.GetValue(FormatProperty); }
            set { this.SetValue(FormatProperty, value); }
        }
        public static readonly DependencyProperty FormatProperty = DependencyProperty.Register(
          "Format", typeof(string), typeof(NumericTextBox), new PropertyMetadata("N2"));

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
