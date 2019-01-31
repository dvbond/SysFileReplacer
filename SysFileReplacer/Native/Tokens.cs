using System;
using System.Runtime.InteropServices;

namespace SysFileReplacer.Native
{
    internal static class Tokens
    {
        internal static IntPtr OpenToken(int processId)
        {
            var hProcess = NativeMethods.OpenProcess(Constants.ProcessQueryInformation, false, (uint)processId);

            if (hProcess == IntPtr.Zero)
            {
                throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());
            }

            if (!NativeMethods.OpenProcessToken(hProcess, Constants.TokenAllAccess, out var hToken))
            {
                if (!NativeMethods.OpenProcessToken(hProcess, (uint)AccessMask.MaximumAllowed, out hToken))
                {
                    throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());
                }
            }

            NativeMethods.CloseHandle(hProcess);

            return hToken;
        }

        public static void SetTokenPrivilege(ref IntPtr hToken, String privilege, TokenPrivilegesFlags attribute)
        {
            var luid = new Luid();

            if (!NativeMethods.LookupPrivilegeValue(null, privilege, ref luid))
            {
                throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());
            }

            var luidAndAttributes = new LuidAndAttributes { Luid = luid, Attributes = (uint)attribute };
            var newState = new TokenPrivileges { PrivilegeCount = 1, Privileges = luidAndAttributes };
            var previousState = new TokenPrivileges();

            if (!NativeMethods.AdjustTokenPrivileges(hToken, false, ref newState, (uint)Marshal.SizeOf(newState), ref previousState, out _))
            {
                throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());
            }
        }
    }
}
