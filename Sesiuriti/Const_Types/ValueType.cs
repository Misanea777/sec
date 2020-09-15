﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sesiuriti.Const_Types
{
    internal enum ValueType
    {
        NONE,
        POLICY_DWORD,
        POLICY_SET,
        TIME_MINUTE,
        TIME_HOUR,
        TIME_DAY,
        AUDIT_SET,
        POLICY_TEXT,
        POLICY_PORTS,
        POLICY_DAY,
        SERVICE_SET,
        POLICY_MULTI_TEXT,
        USER_RIGHT,
        POLICY_FILE_VERSION,
        FILE_ACL,
        POLICY_BINARY,
        REG_ACL,
        SERVICE_ACL,
        LAUNCH_ACL,
        ACCESS_ACL,
        DRIVER_SET,
        LDAP_SET,
        LOCKEDID_SET,
        SMARTCARD_SET,
        LOCALACCOUNT_SET,
        NTLMSSP_SET,
        CRYPTO_SET,
        OBJECT_SET,
        DASD_SET,
        LANMAN_SET,
        LDAPCLIENT_SET,
        EVENT_METHOD,
        POLICY_KBYTE,
    }
}
