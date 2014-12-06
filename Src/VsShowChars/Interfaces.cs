using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsShowChars
{
    internal interface IVsShowCharsOptions
    {
        bool EnableNewLines
        {
            get; set;
        }

        bool EnableControlChars
        {
            get; set;
        }

        event EventHandler Changed;
    }
}
