// FoldersViewModel.cs
// (c) Copyright Christian Ruiz @_christian_ruiz
// MvvmCross - Controls Navigation Plugin is licensed using Microsoft Public License (Ms-PL)
// 

// FoldersViewModel.cs
// (c) Copyright Denis Vlasov, Maksim Vlasov
// MvvmCross - Controls Navigation Plugin is licensed using Microsoft Public License (Ms-PL)

using System.Collections.Generic;
using Cirrious.MvvmCross.ViewModels;
using MupApps.ControlsNavigation.Sample.Core.Model;
using MupApps.ControlsNavigation.Sample.Core.Services;
using Cirrious.MvvmCross.Plugins.Messenger;
using System.Collections.ObjectModel;

namespace MupApps.ControlsNavigation.Sample.Core.ViewModels
{
    public class FoldersViewModel : MvxViewModel
    {
        private readonly IMailBoxService _mailBoxService;

        public FoldersViewModel(IMailBoxService mailBoxService, IMvxMessenger messenger)
        {
            _mailBoxService = mailBoxService;
        }

        public async void Init()
        {
            Folders = new ObservableCollection<Folder>(_mailBoxService.GetFolders());
        }

        private Folder _selectedFolder;
        public Folder SelectedFolder
        {
            get { return _selectedFolder; }
            set 
            { 
                _selectedFolder = value; 
                RaisePropertyChanged(() => SelectedFolder);
                if (_selectedFolder != null)
                { 
                    ShowViewModel<FolderViewModel>(_selectedFolder);
                }
            }
        }

        private ObservableCollection<Folder> _folders;
        public ObservableCollection<Folder> Folders
        {
            get { return _folders; }
            set { _folders = value; RaisePropertyChanged(() => Folders); }
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

        }

        private MvxCommand _foldersTapCommand;

        public MvxCommand FoldersTapCommand
        {
            get
            {
                _foldersTapCommand = _foldersTapCommand ?? new MvxCommand(DoFoldersTapCommand);
                return _foldersTapCommand;
            }
        }

        private void DoFoldersTapCommand()
        {
            _mailBoxService.InformViewModel("FoldersViewModel");
        }

        private MvxCommand _taskslistDeleteCommand;

        public MvxCommand TaskslistDeleteCommand
        {
            get
            {
                _taskslistDeleteCommand = _taskslistDeleteCommand ?? new MvxCommand(DoTaskslistDeleteCommand);
                return _taskslistDeleteCommand;
            }
        }

        private void DoTaskslistDeleteCommand()
        {
            Folders.RemoveAt(0);
        }
    }
}
