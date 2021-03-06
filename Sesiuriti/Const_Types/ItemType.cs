﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sesiuriti.Const_Types
{
    internal enum ItemType
    {
        NONE,
        PASSWORD_POLICY,
        LOCKOUT_POLICY,
        KERBEROS_POLICY,
        AUDIT_POLICY,
        AUDIT_POLICY_SUBCATEGORY,
        AUDIT_POWERSHELL,
        AUDIT_FILEHASH_POWERSHELL,
        AUDIT_IIS_APPCMD,
        AUDIT_ALLOWED_OPEN_PORTS,
        AUDIT_DENIED_OPEN_PORTS,
        AUDIT_PROCESS_ON_PORT,
        AUDIT_USER_TIMESTAMPS,
        BANNER_CHECK,
        CHECK_ACCOUNT,
        CHECK_LOCAL_GROUP,
        ANONYMOUS_SID_SETTING,
        SERVICE_POLICY,
        GROUP_MEMBERS_POLICY,
        USER_GROUPS_POLICY,
        USER_RIGHTS_POLICY,
        FILE_CHECK,
        FILE_VERSION,
        FILE_PERMISSIONS,
        FILE_AUDIT,
        FILE_CONTENT_CHECK,
        FILE_CONTENT_CHECK_NOT,
        REG_CHECK,
        REGISTRY_SETTING,
        REGISTRY_PERMISSIONS,
        REGISTRY_AUDIT,
        REGISTRY_TYPE,
        SERVICE_PERMISSIONS,
        SERVICE_AUDIT,
        WMI_POLICY,
    }
}
