using SysFileReplacer.Files;
using System.Collections.Generic;

namespace SysFileReplacer
{
    internal static class FileProvider
    {
        internal static IEnumerable<ISysFile> GetSysFiles()
        {
            return new ISysFile[]
            {
                new NsLookupSysFile(),
                new Twain32SysFile(),
                new IexploreSysFile()
            };
        }
    }
}
