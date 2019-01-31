namespace SysFileReplacer
{
    internal class Constants
    {
        internal const uint Delete = 0x00010000;
        internal const uint ReadControl = 0x00020000;
        internal const uint WriteDac = 0x00040000;
        internal const uint WriteOwner = 0x00080000;
        internal const uint ProcessQueryInformation = 0x0400;
        internal const uint StandardRightsRequired = (Delete | ReadControl | WriteDac | WriteOwner);
        internal const uint TokenAssignPrimary = 0x0001;
        internal const uint TokenDuplicate = 0x0002;
        internal const uint TokenImpersonate = 0x0004;
        internal const uint TokenQuery = 0x0008;
        internal const uint TokenQuerySource = 0x0010;
        internal const uint TokenAdjustPrivileges = 0x0020;
        internal const uint TokenAdjustGroups = 0x0040;
        internal const uint TokenAdjustDefault = 0x0080;
        internal const uint TokenAdjustSessionId = 0x0100;
        internal const uint TokenAllAccess = (StandardRightsRequired | TokenAssignPrimary | TokenDuplicate | TokenImpersonate | TokenQuery | TokenQuerySource | TokenAdjustPrivileges | TokenAdjustGroups | TokenAdjustDefault | TokenAdjustSessionId);
    }
}
