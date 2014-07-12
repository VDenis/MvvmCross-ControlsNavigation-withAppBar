// FirstViewModel.cs
// (c) Copyright Denis Vlasov, Maksim Vlasov
// MvvmCross - Controls Navigation Plugin is licensed using Microsoft Public License (Ms-PL)

using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;
using MupApps.ControlsNavigation.Sample.Core.Services;

namespace MupApps.ControlsNavigation.Sample.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private MvxSubscriptionToken _appBarRaiseEventSubscriptionToken;

        public FirstViewModel(IMvxMessenger messenger)
        {
            _appBarRaiseEventSubscriptionToken = messenger.Subscribe<AppBarRaiseEventMessage>(OnAppBarRaiseEvent);
        }

        public async void Init()
        {
            ShowViewModel<FoldersViewModel>();
        }

        private void OnAppBarRaiseEvent(AppBarRaiseEventMessage obj)
        {
            string viewModelName = obj.ViewModelName;

            switch (viewModelName)
            {
                case "FoldersViewModel":
                    {
                        FoldersAppbarControlVisibility = true;
                        FolderAppbarControlVisibility = false;
                        MailAppbarControlVisibility = false;
                        break;
                    }

                case "FolderViewModel":
                    {
                        FoldersAppbarControlVisibility = false;
                        FolderAppbarControlVisibility = true;
                        MailAppbarControlVisibility = false;
                        break;
                    }

                case "MailViewModel":
                    {
                        FoldersAppbarControlVisibility = false;
                        FolderAppbarControlVisibility = false;
                        MailAppbarControlVisibility = true;
                        break;
                    }

                default:
                    {
                        FoldersAppbarControlVisibility = false;
                        FolderAppbarControlVisibility = false;
                        MailAppbarControlVisibility = false;
                        break;
                    }
            }

        }

        private bool _foldersAppbarControlVisibility = false;
        public bool FoldersAppbarControlVisibility
        {
            get { return _foldersAppbarControlVisibility; }
            set { if (_foldersAppbarControlVisibility == value) return; _foldersAppbarControlVisibility = value; RaisePropertyChanged(() => FoldersAppbarControlVisibility); }
        }

        private bool _folderAppbarControlVisibility = false;
        public bool FolderAppbarControlVisibility
        {
            get { return _folderAppbarControlVisibility; }
            set { if (_folderAppbarControlVisibility == value) return; _folderAppbarControlVisibility = value; RaisePropertyChanged(() => FolderAppbarControlVisibility); }
        }

        private bool _mailAppbarControlVisibility = false;
        public bool MailAppbarControlVisibility
        {
            get { return _mailAppbarControlVisibility; }
            set { if (_mailAppbarControlVisibility == value) return; _mailAppbarControlVisibility = value; RaisePropertyChanged(() => MailAppbarControlVisibility); }
        }

        private bool _firstSettingStart = true;
        public bool FirstSettingStart
        {
            get { return _firstSettingStart; }
            set { if (_firstSettingStart == value) return; _firstSettingStart = value; RaisePropertyChanged(() => FirstSettingStart); }
        }

        private MvxCommand _settingTestCommand;

        public MvxCommand SettingTestCommand
        {
            get
            {
                _settingTestCommand = _settingTestCommand ?? new MvxCommand(DoSettingTestCommand);
                return _settingTestCommand;
            }
        }

        private void DoSettingTestCommand()
        {

        }

        private MvxCommand _openSettingCommand;

        public MvxCommand OpenSettingCommand
        {
          get
          {
            _openSettingCommand = _openSettingCommand ?? new MvxCommand(DoOpenSettingCommand);
            return _openSettingCommand;
          }
        }

        public void DoOpenSettingCommand()
        {
            if (FirstSettingStart)
            {
                ShowViewModel<SettingViewModel>();
            }
            //FirstSettingStart = false;
        }
    }
}
