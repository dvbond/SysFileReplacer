﻿using SysFileReplacer.Files;
using System;
using System.Collections.Generic;
using System.IO;
using SysFileReplacer.Resources;

namespace SysFileReplacer
{
    internal sealed class FileBackupGenerator
    {
        private readonly string _backupDirectoryPath;

        internal FileBackupGenerator()
        {
            var pathRoot = Path.GetPathRoot(Environment.SystemDirectory);
            _backupDirectoryPath = string.Concat(pathRoot, "\\Bak");
        }

        internal void BackupFiles(IEnumerable<ISysFile> files)
        {
            CreateBackupDirectoryIfNotExist();

            Console.WriteLine("");
            Console.WriteLine(Strings.CreatingBackupForFiles);

            foreach (var file in files)
            {
                Console.WriteLine("");
                Console.WriteLine("------------");

                var destinationPath = string.Concat(_backupDirectoryPath, "\\", file.GetFileName());

                try
                {
                    if (!File.Exists(destinationPath))
                    {
                        File.Copy(file.GetFullFilePath(), destinationPath, true);
                        Console.WriteLine(Strings.BackupForFileCreated, file.GetFileName());
                    }
                    else
                    {
                        Console.WriteLine(Strings.BackupForFileIsAlreadyExist, file.GetFileName());
                    }

                    file.SetBackupExists(true);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(Strings.CannotCreateBackupForFile, file.GetFileName());
                    Console.WriteLine(ex.Message);

                    file.SetBackupExists(false);
                }
            }
        }

        private void CreateBackupDirectoryIfNotExist()
        {
            if (!Directory.Exists(_backupDirectoryPath))
            {
                Directory.CreateDirectory(_backupDirectoryPath);
                Console.WriteLine(Strings.CreatedBackupDirectory, _backupDirectoryPath);
            }
            else
            {
                Console.WriteLine(Strings.BackupDirectoryAlreadyCreated, _backupDirectoryPath);
            }
        }
    }
}
