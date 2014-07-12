// FoldersAppbarControl.xaml.cs
// (c) Copyright Denis Vlasov, Maksim Vlasov
// MvvmCross - Controls Navigation Plugin is licensed using Microsoft Public License (Ms-PL)

using Windows.UI.Xaml;
// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236
using MupApps.MvvmCross.Plugins.ControlsNavigation.WindowsStore;
using MupApps.ControlsNavigation.Sample.Core.ViewModels;

namespace MupApps.ControlsNavigation.Sample.WindowsStore.Controls
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FoldersAppbarControl : MvxStoreControl
    {
        public FoldersAppbarControl()
        {
            this.InitializeComponent();
        }        
    }
}
