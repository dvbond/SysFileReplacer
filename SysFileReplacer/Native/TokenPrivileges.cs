using System.Runtime.InteropServices;

namespace SysFileReplacer.Native
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct TokenPrivileges
    {
        internal uint PrivilegeCount;
        internal LuidAndAttributes Privileges;
    }
}
