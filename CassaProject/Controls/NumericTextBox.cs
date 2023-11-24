using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace CassaProject.Controls
{
    public class NumericTextBox : BaseNumDigTextBox
    {
        static private new readonly string allowedChars = "0123456789.,-";

        public NumericTextBox() : base(allowedChars) { }
    }
}
