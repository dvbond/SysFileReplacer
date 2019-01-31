using System;

namespace SysFileReplacer.Files
{
    internal sealed class NsLookupSysFile : SysFileBase
    {
        public override string GetFileName()
        {
            return "nslookup.exe";
        }

        public override string GetFullFilePath()
        {
            return string.Concat(Environment.GetEnvironmentVariable("SystemRoot"), "\\System32\\", GetFileName());
        }
    }
}
