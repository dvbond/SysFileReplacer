using System;

namespace SysFileReplacer
{
    internal static class OSIdentifier
    {
        private const string SERVICE_PACK_3 = "Service Pack 3";

        internal static bool IsCurrentOsSupported()
        {
            var os = Environment.OSVersion;
            var vs = os.Version;

            if (os.Platform != PlatformID.Win32NT)
            {
                return false;
            }

            if (vs.Major == 5 && vs.Minor != 0 && os.ServicePack.Equals(SERVICE_PACK_3, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return vs.Major >= 6;
        }

        internal static bool IsWindowsXp()
        {
            return Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor != 0;
        }
    }
}
