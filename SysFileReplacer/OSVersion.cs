using System;

namespace SysFileReplacer
{
    internal class OSVersion
    {
        internal virtual PlatformID Platform => Environment.OSVersion.Platform;

        internal virtual Version Version => Environment.OSVersion.Version;

        internal virtual string ServicePack => Environment.OSVersion.ServicePack;
    }
}
