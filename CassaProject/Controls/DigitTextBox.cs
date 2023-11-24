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
    public class DigitTextBox : BaseNumDigTextBox
    {

        static private new readonly string allowedChars = "0123456789";

        public DigitTextBox() : base(allowedChars) { }
    }
}
