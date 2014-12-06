using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows.Media;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace VsShowChars.Implementation
{
    [Export(typeof(EditorFormatDefinition))]
    [Name(VsShowCharsFormatDefinition.Name)]
    [UserVisible(true)]
    internal sealed class VsShowCharsFormatDefinition : EditorFormatDefinition
    {
        internal const string Name = Constants.VsShowCharsFormatDefinitionName;

        internal VsShowCharsFormatDefinition()
        {
            DisplayName = "VsShowChars Display";
            ForegroundColor = Constants.DefaultForegroundColor;
            BackgroundCustomizable = false;
        }
    }
}
