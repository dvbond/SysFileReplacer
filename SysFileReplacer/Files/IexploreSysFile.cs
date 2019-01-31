using System;

namespace SysFileReplacer.Files
{
    internal sealed class IexploreSysFile : SysFileBase
    {
        public override string GetFileName()
        {
            return "iexplore.exe";
        }

        public override string GetFullFilePath()
        {
            return string.Concat(Environment.GetEnvironmentVariable("ProgramFiles"), "\\Internet Explorer\\", GetFileName());
        }
    }
}
