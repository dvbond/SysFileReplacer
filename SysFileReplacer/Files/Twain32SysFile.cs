using System;

namespace SysFileReplacer.Files
{
    internal sealed class Twain32SysFile : SysFileBase
    {
        public override string GetFileName()
        {
            return "twain_32.dll";
        }

        public override string GetFullFilePath()
        {
            return string.Concat(Environment.GetEnvironmentVariable("SystemRoot"), "\\", GetFileName());
        }
    }
}
