// FirstView.xaml.cs
// (c) Copyright Denis Vlasov, Maksim Vlasov
// MvvmCross - Controls Navigation Plugin is licensed using Microsoft Public License (Ms-PL)

using Cirrious.MvvmCross.WindowsStore.Views;
using MupApps.ControlsNavigation.Sample.Core.ViewModels;
using Windows.UI.ApplicationSettings;
using Windows.UI.Xaml.Navigation;

namespace MupApps.ControlsNavigation.Sample.WindowsStore.Views
{
    public sealed partial class FirstView : MvxStorePage
    {
        public FirstView()
        {
            this.InitializeComponent();
        }

        SettingsFlyout1 sf = new SettingsFlyout1();

        private void FirstViewButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            sf.ShowIndependent();
            
            ((FirstViewModel)ViewModel).DoOpenSettingCommand();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            SettingsPane.GetForCurrentView().CommandsRequested += FirstView_CommandsRequested;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            SettingsPane.GetForCurrentView().CommandsRequested -= FirstView_CommandsRequested;
        }

        void FirstView_CommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs e)
        {
            SettingsCommand defaultsCommand = new SettingsCommand("defaults", "Defaults",
            (handler) =>
            {
                sf.Show();

                ((FirstViewModel)ViewModel).DoOpenSettingCommand();
            });
            e.Request.ApplicationCommands.Add(defaultsCommand);
        }
    }
}
