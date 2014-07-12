// FoldersView.xaml.cs
// (c) Copyright Christian Ruiz @_christian_ruiz
// MvvmCross - Controls Navigation Plugin is licensed using Microsoft Public License (Ms-PL)
// 

// FoldersControl.xaml.cs
// (c) Copyright Denis Vlasov, Maksim Vlasov
// MvvmCross - Controls Navigation Plugin is licensed using Microsoft Public License (Ms-PL)

using MupApps.MvvmCross.Plugins.ControlsNavigation.WindowsStore;

namespace MupApps.ControlsNavigation.Sample.WindowsStore.Controls
{
    public sealed partial class FoldersControl : MvxStoreControl
    {
        public FoldersControl()
        {
            this.InitializeComponent();
        }

        //private void FoldersView_OnLoaded(object sender, RoutedEventArgs e)
        //{
        //    //As the folder is also showed on this view, we don't wait for the user to select one
        //    //((FoldersViewModel)ViewModel).SelectedFolder = ((FoldersViewModel)ViewModel).Folders.FirstOrDefault();
        //}
    }
}
