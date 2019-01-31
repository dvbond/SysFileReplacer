using System;
using System.Runtime.InteropServices;

namespace SysFileReplacer.Native
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct Luid
    {
        internal readonly UInt32 LowPart;
        internal readonly UInt32 HighPart;
    }
}
