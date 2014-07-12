using Windows.UI.Xaml;
// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236
using MupApps.MvvmCross.Plugins.ControlsNavigation.WindowsStore;
using MupApps.ControlsNavigation.Sample.Core.ViewModels;

namespace MupApps.ControlsNavigation.Sample.WindowsStore.Controls
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AppbarControl : MvxStoreControl
    {
        public AppbarControl()
        {
            this.InitializeComponent();
        }

        private void MvxStoreControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void MvxStoreControl_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        private void MvxStoreControl_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {

        }

        private void MvxStoreControl_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void MvxStoreControl_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void MvxStoreControl_ManipulationStarted(object sender, Windows.UI.Xaml.Input.ManipulationStartedRoutedEventArgs e)
        {

        }
    }
}
