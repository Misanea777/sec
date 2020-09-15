using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sesiuriti.Const_Types.Item_Clases
{
    abstract class CustomItem
    {
        ItemType itemType { get { return itemType; } set { itemType = value; } }
        ValueType valueType { get { return valueType; } set { valueType = value; } }
        string description { get { return description; } set { description = value; } }

        public CustomItem(ItemType itemType, ValueType valueType, string description)
        {
            this.itemType = itemType;
            this.valueType = valueType;
            this.description = description;
        }


    }
}
