using System.Runtime.InteropServices;

namespace SysFileReplacer.Native
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct LuidAndAttributes
    {
        internal Luid Luid;
        internal uint Attributes;
    }
}
