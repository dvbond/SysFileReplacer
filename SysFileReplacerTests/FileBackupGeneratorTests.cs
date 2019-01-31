using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SysFileReplacer;
using SysFileReplacer.Files;

namespace SysFileReplacerTests
{
    [TestClass]
    public class FileBackupGeneratorTests
    {
        private string _backupDirectoryPath;
        private TestSysFile _testSysFile;
        private FileBackupGenerator _backupGenerator;

        [TestInitialize]
        public void Init()
        {
            var pathRoot = Path.GetPathRoot(Environment.SystemDirectory);
            _backupDirectoryPath = string.Concat(pathRoot, "\\SysFileReplacerTestBackupFolder");
            _testSysFile = new TestSysFile();
            _backupGenerator = new FileBackupGenerator();
            _backupGenerator.SetBackupDirectoryPath(_backupDirectoryPath);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _testSysFile.Remove();

            DirectoryInfo di = new DirectoryInfo(_backupDirectoryPath);

            foreach (var file in di.GetFiles())
            {
                file.Delete();
            }

            Directory.Delete(_backupDirectoryPath);
        }

        [TestMethod]
        public void Backup_FolderNotExist_FileBackupSuccessfullyCompleted()
        {
            // Act
            _backupGenerator.BackupFiles(new []{ _testSysFile });

            // Assert
            Assert.IsTrue(Directory.Exists(_backupDirectoryPath));
            Assert.AreEqual(FileBackupStatus.BackupCreated, _testSysFile.GetBackupStatus());
            Assert.IsTrue(File.Exists(string.Concat(_backupDirectoryPath, "\\", _testSysFile.GetFileName())));
        }

        [TestMethod]
        public void Backup_FolderExists_FileBackupSuccessfullyCompleted()
        {
            // Arrange
            Directory.CreateDirectory(_backupDirectoryPath);

            // Act
            _backupGenerator.BackupFiles(new[] { _testSysFile });

            // Assert
            Assert.IsTrue(Directory.Exists(_backupDirectoryPath));
            Assert.AreEqual(FileBackupStatus.BackupCreated, _testSysFile.GetBackupStatus());
            Assert.IsTrue(File.Exists(string.Concat(_backupDirectoryPath, "\\", _testSysFile.GetFileName())));
        }

        [TestMethod]
        public void Backup_FileAlreadyExist_BackupSkipped()
        {
            // Arrange
            Directory.CreateDirectory(_backupDirectoryPath);
            var destinationPath = string.Concat(_backupDirectoryPath, "\\", _testSysFile.GetFileName());
            File.Copy(_testSysFile.GetFullFilePath(), destinationPath, true);

            // Act
            _backupGenerator.BackupFiles(new[] { _testSysFile });

            // Assert
            Assert.IsTrue(Directory.Exists(_backupDirectoryPath));
            Assert.AreEqual(FileBackupStatus.BackupAlreadyCreated, _testSysFile.GetBackupStatus());
            Assert.IsTrue(File.Exists(string.Concat(_backupDirectoryPath, "\\", _testSysFile.GetFileName())));
        }
    }
}
