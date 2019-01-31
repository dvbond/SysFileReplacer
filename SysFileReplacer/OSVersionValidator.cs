using System;

namespace SysFileReplacer
{
    internal static class OSVersionValidator
    {
        private const string SERVICE_PACK_3 = "Service Pack 3";

        internal static bool IsCurrentOsSupported(OSVersion osVersion)
        {
            var vs = osVersion.Version;

            if (osVersion.Platform != PlatformID.Win32NT)
            {
                return false;
            }

            if (vs.Major == 5 && vs.Minor != 0 && osVersion.ServicePack.Equals(SERVICE_PACK_3, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return vs.Major >= 6;
        }

        internal static bool IsWindowsXp(OSVersion osVersion)
        {
            return osVersion.Platform == PlatformID.Win32NT && osVersion.Version.Major == 5 && osVersion.Version.Minor != 0;
        }
    }
}
