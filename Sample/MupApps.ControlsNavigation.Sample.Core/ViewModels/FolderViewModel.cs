// FolderViewModel.cs
// (c) Copyright Christian Ruiz @_christian_ruiz
// MvvmCross - Controls Navigation Plugin is licensed using Microsoft Public License (Ms-PL)
// 

// FolderViewModel.cs
// (c) Copyright Denis Vlasov, Maksim Vlasov
// MvvmCross - Controls Navigation Plugin is licensed using Microsoft Public License (Ms-PL)

using System.Collections.Generic;
using Cirrious.MvvmCross.ViewModels;
using MupApps.ControlsNavigation.Sample.Core.Model;
using MupApps.ControlsNavigation.Sample.Core.Services;
using System.Collections.ObjectModel;

namespace MupApps.ControlsNavigation.Sample.Core.ViewModels
{
    public class FolderViewModel : MvxViewModel
    {
        private readonly IMailBoxService _mailBoxService;

        public FolderViewModel(IMailBoxService mailBoxService)
        {
            _mailBoxService = mailBoxService;
        }

        public async void Init(Folder folder)
        {
            Folder = folder;
            Mails = await _mailBoxService.GetMailsAsync(folder.Name);
        }

        private Folder _folder;
        public Folder Folder
        {
            get { return _folder; }
            set
            {
                _folder = value;
                RaisePropertyChanged(() => Folder);
            }
        }

        private Mail _selectedMail;
        public Mail SelectedMail
        {
            get { return _selectedMail; }
            set
            {
                _selectedMail = value; 
                RaisePropertyChanged(() => SelectedMail);
                if (_selectedMail != null)
                    ShowViewModel<MailViewModel>(_selectedMail);
            }
        }

        //private List<Mail> _mails;
        //public List<Mail> Mails
        //{
        //    get { return _mails; }
        //    set { _mails = value; RaisePropertyChanged(() => Mails); }
        //}

        private ObservableCollection<Mail> _mails;
        public ObservableCollection<Mail> Mails
        {
            get { return _mails; }
            set { _mails = value; RaisePropertyChanged(() => Mails); }
        }

        private MvxCommand _informViewModelCommand;

        public MvxCommand InformViewModelCommand
        {
            get
            {
                _informViewModelCommand = _informViewModelCommand ?? new MvxCommand(DoInformViewModelCommand);
                return _informViewModelCommand;
            }
        }

        private void DoInformViewModelCommand()
        {
            Mails.RemoveAt(0);
        }

        private MvxCommand _folderTapCommand;

        public MvxCommand FolderTapCommand
        {
            get
            {
                _folderTapCommand = _folderTapCommand ?? new MvxCommand(DoFolderTapCommand);
                return _folderTapCommand;
            }
        }

        private void DoFolderTapCommand()
        {
            _mailBoxService.InformViewModel("FolderViewModel");
        }

        private MvxCommand _folderRightTapCommand;

        public MvxCommand FolderRightTapCommand
        {
            get
            {
                _folderRightTapCommand = _folderRightTapCommand ?? new MvxCommand(DoFolderRightTapCommand);
                return _folderRightTapCommand;
            }
        }

        private void DoFolderRightTapCommand()
        {

        }
    }
}
