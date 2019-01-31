namespace SysFileReplacer.Files
{
    internal abstract class SysFileBase : ISysFile
    {
        private bool _backupExists = false;

        public abstract string GetFileName();

        public abstract string GetFullFilePath();

        public bool GetBackupExists()
        {
            return _backupExists;
        }

        public void SetBackupExists(bool backupExists)
        {
            _backupExists = backupExists;
        }
    }
}
