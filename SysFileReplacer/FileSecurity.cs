using System;
using System.Diagnostics;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using SysFileReplacer.Files;
using SysFileReplacer.Native;

namespace SysFileReplacer
{
    internal static class FileSecurity
    {
        private static readonly string _seTakeOwnershipPrivilege = "SeTakeOwnershipPrivilege";

        internal static void TakeFileOwnership(ISysFile sysFile)
        {
            var tempToken = Tokens.OpenToken(Process.GetCurrentProcess().Id);
            Tokens.SetTokenPrivilege(ref tempToken, _seTakeOwnershipPrivilege, TokenPrivilegesFlags.SePrivilegeEnabled);

            var currentUserIdentifier = WindowsIdentity.GetCurrent().User;

            if (currentUserIdentifier == null)
            {
                throw new InvalidOperationException();
            }

            var fileSecurity = File.GetAccessControl(sysFile.GetFullFilePath());
            fileSecurity.SetOwner(currentUserIdentifier);
            File.SetAccessControl(sysFile.GetFullFilePath(), fileSecurity);

            fileSecurity.SetAccessRule(new FileSystemAccessRule(currentUserIdentifier, FileSystemRights.FullControl, AccessControlType.Allow));
            File.SetAccessControl(sysFile.GetFullFilePath(), fileSecurity);
        }
    }
}
