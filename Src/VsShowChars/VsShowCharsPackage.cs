using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using Microsoft.Win32;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.ComponentModelHost;

namespace VsShowChars
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(Constants.VsShowCharsPackageString)]
    public sealed class VsShowCharsPackage : Package
    {
        private IVsShowCharsOptions _options;

        public VsShowCharsPackage()
        {

        }

        protected override void Initialize()
        {
            base.Initialize();

            var componentModel = (IComponentModel)GetService(typeof(SComponentModel));
            var exportProvider = componentModel.DefaultExportProvider;
            _options = exportProvider.GetExportedValue<IVsShowCharsOptions>();

            // Add our command handlers for menu (commands must exist in the .vsct file)
            var mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (mcs != null)
            {
                // Create the command for the menu item.
                var viewControlCharsId = new CommandID(Constants.VsShowCharsCommandSetGuid, CommandList.ViewControlChars);
                var viewNewLinesId = new CommandID(Constants.VsShowCharsCommandSetGuid, CommandList.ViewNewLines);
                mcs.AddCommand(new MenuCommand(OnViewControlCharsClick, viewControlCharsId)); 
                mcs.AddCommand(new MenuCommand(OnViewNewLinesClick, viewNewLinesId));
            }
        }

        private void OnViewControlCharsClick(object sender, EventArgs e)
        {
            _options.EnableControlChars = !_options.EnableControlChars;
        }

        private void OnViewNewLinesClick(object sender, EventArgs e)
        {
            _options.EnableNewLines = !_options.EnableNewLines;
        }
    }
}
