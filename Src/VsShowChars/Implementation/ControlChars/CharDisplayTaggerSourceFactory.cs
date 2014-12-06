using EditorUtils;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;

namespace VsShowChars.Implementation.ControlChars
{
    [Export(typeof(IViewTaggerProvider))]
    [ContentType("any")]
    [TextViewRole(PredefinedTextViewRoles.Editable)]
    [TagType(typeof(IntraTextAdornmentTag))]
    internal sealed class CharDisplayTaggerSourceFactory : IViewTaggerProvider
    {
        private readonly object _key = new object();
        private readonly IEditorFormatMapService _editorFormatMapService;
        private readonly IVsShowCharsOptions _options;

        [ImportingConstructor]
        internal CharDisplayTaggerSourceFactory(IEditorFormatMapService editorFormatMapService, IVsShowCharsOptions options)
        {
            _editorFormatMapService = editorFormatMapService;
            _options = options;
        }

        private CharDisplayTaggerSource CreateCharDisplayTaggerSource(ITextView textView)
        {
            var editorFormatMap = _editorFormatMapService.GetEditorFormatMap(textView);
            return new CharDisplayTaggerSource(textView, editorFormatMap, _options);
        }

        #region IViewTaggerProvider

        ITagger<T> IViewTaggerProvider.CreateTagger<T>(ITextView textView, ITextBuffer textBuffer)
        {
            return EditorUtilsFactory.CreateTagger(
                textView.Properties,
                _key,
                () => CreateCharDisplayTaggerSource(textView)) as ITagger<T>;
        }

        #endregion
    }
}
