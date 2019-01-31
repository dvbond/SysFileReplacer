using System;

namespace SysFileReplacer.Native
{
    [Flags]
    internal enum TokenPrivilegesFlags : uint
    {
        SePrivilegeNone = 0x0,
        SePrivilegeEnabledByDefault = 0x1,
        SePrivilegeEnabled = 0x2,
        SePrivilegeRemoved = 0x4,
        SePrivilegeUsedForAccess = 0x3
    }
}
