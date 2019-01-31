namespace SysFileReplacer.Files
{
    internal interface ISysFile
    {
        string GetFileName();

        string GetFullFilePath();

        bool GetBackupExists();

        void SetBackupExists(bool backupExists);
    }
}
