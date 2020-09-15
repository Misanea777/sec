using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sesiuriti
{
    class Label
    {
        public string Name { get; private set; }
        public string Value { get; private set; }


        public Label(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            if (Value.Length > 100)
            {
                Value = Value.Substring(0, 100);
                Value += "...";
            }
            return Name + "   :   " + Value;
        }
    }
}
