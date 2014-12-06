using System;
using System.Windows.Media;

namespace VsShowChars
{
    internal static class Constants
    {
        internal const string VsShowCharsFormatDefinitionName = "vsshowchars.display";

        internal static readonly Color DefaultForegroundColor = Colors.Blue;

        internal static readonly SolidColorBrush DefaultForegroundBrush = new SolidColorBrush(DefaultForegroundColor);

        /// <summary>
        /// This value must be kept in sync with VsShowChars.vsct
        /// </summary>
        internal const string VsShowCharsPackageString = "b2e3f7e8-cf16-419f-bbe4-1abe95c4dd6a";

        /// <summary>
        /// This value must be kept in sync with VsShowChars.vsct
        /// </summary>
        internal const string VsShowCharsCommandSetString = "694a780c-9677-4c06-8f99-78347cb683ac";

        internal static readonly Guid VsShowCharsCommandSetGuid = new Guid(VsShowCharsCommandSetString);
    };
}