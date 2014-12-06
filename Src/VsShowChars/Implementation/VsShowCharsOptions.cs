using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsShowChars.Implementation
{
    [Export(typeof(IVsShowCharsOptions))]
    internal sealed class VsShowCharsOptions : IVsShowCharsOptions
    {
        private bool _enableNewLines;
        private bool _enableControlChars;
        private event EventHandler _changed = delegate { };

        internal bool EnableNewLines
        {
            get { return _enableNewLines; }
            set
            {
                if ( value != _enableNewLines)
                {
                    _enableNewLines = value;
                    RaiseChanged();
                }
            }
        }

        internal bool EnableControlChars
        {
            get { return _enableControlChars; }
            set
            {
                if ( value != _enableControlChars)
                {
                    _enableControlChars = value;
                    RaiseChanged();
                }
            }
        }

        private void RaiseChanged()
        {
            _changed(this, EventArgs.Empty);
        }

        #region IVsShowCharsOptions

        bool IVsShowCharsOptions.EnableNewLines
        {
            get { return EnableNewLines; }
            set { EnableNewLines = value; }
        }

        bool IVsShowCharsOptions.EnableControlChars
        {
            get { return EnableControlChars; }
            set { EnableControlChars = value; }
        }

        event EventHandler IVsShowCharsOptions.Changed
        {
            add { _changed += value; }
            remove { _changed -= value; }
        }

        #endregion
    }
}
