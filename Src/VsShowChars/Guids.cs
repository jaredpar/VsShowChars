using System;

namespace VsShowChars
{
    internal static class GuidList
    {
        /// <summary>
        /// This value must be kept in sync with VsShowChars.vsct
        /// </summary>
        public const string VsShowCharsPackageString = "b2e3f7e8-cf16-419f-bbe4-1abe95c4dd6a";

        /// <summary>
        /// This value must be kept in sync with VsShowChars.vsct
        /// </summary>
        public const string VsShowCharsCommandSetString = "694a780c-9677-4c06-8f99-78347cb683ac";

        public static readonly Guid VsShowCharsCommandSetGuid = new Guid(VsShowCharsCommandSetString);
    };
}