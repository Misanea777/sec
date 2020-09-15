using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sesiuriti.Const_Types.Item_Clases
{
    internal enum PasswordPolicyType
    {
        ENFORCE_PASSWORD_HISTORY,
        MAXIMUM_PASSWORD_AGE,
        MINIMUM_PASSWORD_AGE,
        MINIMUM_PASSWORD_LENGTH,
        COMPLEXITY_REQUIREMENTS,
        REVERSIBLE_ENCRYPTION,
        FORCE_LOGOFF,
    }
    class PASSWORD_POLICY : CustomItem
    {
        PasswordPolicyType passwordPolicy;
        string valueData;
        string checkType;
        public PASSWORD_POLICY(string description, ValueType valueType, string valueData, PasswordPolicyType passwordPolicy)
            : base(ItemType.PASSWORD_POLICY, valueType, description)
        {
            this.passwordPolicy = passwordPolicy;
            this.valueData = valueData;
        }
    }

}
