using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using SysFileReplacer.Files;
using SysFileReplacer.Resources;

namespace SysFileReplacer
{
    static class Program
    {
        static void Main(string[] args)
        {
            if (!OSVersionValidator.IsCurrentOsSupported(new OSVersion()))
            {
                Console.WriteLine(Strings.CurrentOperationSystemIsNotSupported);
                Console.WriteLine(Strings.PressAnyKeyToContinue);
                Console.ReadKey();
                return;
            }

            var guid = Marshal.GetTypeLibGuidForAssembly(Assembly.GetExecutingAssembly()).ToString();
            var mutex = new Mutex(true, guid, out bool noInstanceExist);

            if (noInstanceExist)
            {
                var files = FileProvider.GetSysFiles().ToArray();
                var fileBackupGenerator = new FileBackupGenerator();
                var fileReplacer = new FileReplacer();

                fileBackupGenerator.BackupFiles(files);
                fileReplacer.ReplaceFiles(files.Where(f => f.GetBackupStatus() != FileBackupStatus.BackupNotCreated));
            }
            else
            {
                Console.WriteLine(Strings.ApplicationIsAlreadyRuninng);
            }

            Console.WriteLine(Strings.PressAnyKeyToContinue);
            Console.ReadKey();
        }
    }
}
