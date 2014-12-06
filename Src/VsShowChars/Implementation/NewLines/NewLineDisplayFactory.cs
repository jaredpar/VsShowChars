using EditorUtils;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace VsShowChars.Implementation.NewLines
{
    [Export(typeof(IWpfTextViewCreationListener))]
    [ContentType("any")]
    [TextViewRole(PredefinedTextViewRoles.Editable)]
    internal sealed class NewLineDisplayFactory : IWpfTextViewCreationListener
    {
        internal const string AdornmentLayerName = "NewLineDisplayAdornment";

        private readonly IEditorFormatMapService _editorFormatMapService;
        private readonly IVsShowCharsOptions _options;

        /// <summary>
        /// Defines the adornment layer for the adornment. This layer is ordered 
        /// after the selection layer in the Z-order
        /// </summary>
        [Export(typeof(AdornmentLayerDefinition))]
        [Name(AdornmentLayerName)]
        [Order(After = PredefinedAdornmentLayers.Selection, Before = PredefinedAdornmentLayers.Text)]
        public AdornmentLayerDefinition NewLineDisplayAdornmentLayerDefinition = null;

        [ImportingConstructor]
        internal NewLineDisplayFactory(IEditorFormatMapService editorFormatMapService, IVsShowCharsOptions options)
        {
            _editorFormatMapService = editorFormatMapService;
            _options = options;
        }

        void IWpfTextViewCreationListener.TextViewCreated(IWpfTextView textView)
        {
            var editorFormatMap = _editorFormatMapService.GetEditorFormatMap(textView);
            new NewLineDisplay(textView, textView.GetAdornmentLayer(AdornmentLayerName), editorFormatMap, _options);
        }
    }
}
