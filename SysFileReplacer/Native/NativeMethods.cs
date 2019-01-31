using System;
using System.Runtime.InteropServices;

namespace SysFileReplacer.Native
{
    internal static class NativeMethods
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool CloseHandle(IntPtr hProcess);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, uint dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool OpenProcessToken(IntPtr hProcess, uint dwDesiredAccess, out IntPtr hToken);

        [DllImport("advapi32.dll", SetLastError = true)]
        internal static extern bool LookupPrivilegeValue(string lpSystemName, string lpName, ref Luid luid);

        [DllImport("advapi32.dll", SetLastError = true)]
        internal static extern bool AdjustTokenPrivileges(
            IntPtr tokenHandle,
            bool disableAllPrivileges,
            ref TokenPrivileges newState,
            uint bufferLengthInBytes,
            ref TokenPrivileges previousState,
            out uint returnLengthInBytes
        );

        [DllImport("sfc_os.dll", EntryPoint = "#5", SetLastError = true)]
        internal static extern int sfc_os(int p1, IntPtr p2, int p3);
    }
}
