namespace SysFileReplacer.Files
{
    internal abstract class SysFileBase : ISysFile
    {
        private FileBackupStatus _backupStatus = FileBackupStatus.BackupNotCreated;

        public abstract string GetFileName();

        public abstract string GetFullFilePath();

        public FileBackupStatus GetBackupStatus()
        {
            return _backupStatus;
        }

        public void SetBackupStatus(FileBackupStatus backupStatus)
        {
            _backupStatus = backupStatus;
        }
    }
}
