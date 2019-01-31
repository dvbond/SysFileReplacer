using SysFileReplacer.Files;
using SysFileReplacer.Native;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using SysFileReplacer.Resources;

namespace SysFileReplacer
{
    internal sealed class FileReplacer
    {
        private readonly string _currentAssemblyLoc = Assembly.GetExecutingAssembly().Location;

        internal void ReplaceFiles(IEnumerable<ISysFile> files)
        {
            Console.WriteLine("");
            Console.WriteLine(Strings.ReplacingFiles);

            foreach (var file in files)
            {
                Console.WriteLine("");
                Console.WriteLine("------------");

                var isCurrentExecutableFile = file.GetFullFilePath().Equals(_currentAssemblyLoc, StringComparison.OrdinalIgnoreCase);

                if (!isCurrentExecutableFile && (OSVersionValidator.IsWindowsXp(new OSVersion()) || TakeFileOwnership(file)))
                {
                    DisableWindowsFileProtection(file);
                    ReplaceFile(file);
                }
            }
        }

        private static bool TakeFileOwnership(ISysFile sysFile)
        {
            try
            {
                FileSecurity.TakeFileOwnership(sysFile);
                Console.WriteLine(Strings.OwnershipSuccesfullyChangedForFile, sysFile.GetFileName());

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(Strings.CannotGetOwnershipForFile, sysFile.GetFileName());
                Console.WriteLine(ex.Message);

                return false;
            }
        }

        private static void DisableWindowsFileProtection(ISysFile sysFile)
        {
            try
            {
                IntPtr p2 = Marshal.StringToHGlobalUni(sysFile.GetFullFilePath());
                NativeMethods.sfc_os(0, p2, -1);

                Console.WriteLine(Strings.WindowsFileProtectionSuccessfullyDisabledForFile, sysFile.GetFileName());
            }
            catch(Exception ex)
            {
                Console.WriteLine(Strings.CannotDisableWindowsFileProtectionForFile, sysFile.GetFileName());
                Console.WriteLine(ex.Message);
            }
        }

        private void ReplaceFile(ISysFile sysFile)
        {
            try
            {
                File.SetAttributes(sysFile.GetFullFilePath(), FileAttributes.Normal);
                File.Delete(sysFile.GetFullFilePath());
                File.Copy(_currentAssemblyLoc, sysFile.GetFullFilePath());

                Console.WriteLine(Strings.FileSuccessfullyReplaced, sysFile.GetFileName());
            }
            catch
            {
                Console.WriteLine(Strings.ReplaceFileActionCannotBeCompletedBecauseFileIsUsedByAnotherProcess, sysFile.GetFileName());
            }
        }
    }
}
