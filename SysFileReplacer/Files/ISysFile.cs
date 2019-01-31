namespace SysFileReplacer.Files
{
    internal interface ISysFile
    {
        string GetFileName();

        string GetFullFilePath();

        FileBackupStatus GetBackupStatus();

        void SetBackupStatus(FileBackupStatus backupExists);
    }
}
