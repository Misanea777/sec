using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sesiuriti.Const_Types.Item_Clases.DataTypes
{
    class DwordOrRange
    {
        private static Regex regex = new Regex("[(?<min1>(MIN)|(?<max1>MAX)|(?<num1>\\num+))..((?<min2>MIN)|(<max2>MAX)|(?<num2>\\num+))]");
        public List<uint> value = new List<uint>();

        public DwordOrRange(string value)
        {
            uint tmp;
            if(uint.TryParse(value, out tmp))
            {
                this.value.Add(tmp);
            }
         
            
        }

    }
}
