using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_Team
{
    public class clsComboBoxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }
        string test;

        public override string ToString() //Override is need because Text has a new behavior on this class. Right?
        {
            return Text;
        }
    }
}
