using System.Collections.Generic;
using Cirrious.MvvmCross.ViewModels;
using MupApps.ControlsNavigation.Sample.Core.Model;
using MupApps.ControlsNavigation.Sample.Core.Services;

namespace MupApps.ControlsNavigation.Sample.Core.ViewModels
{
    class FolderViewModelAppbarViewModel : MvxViewModel
    {
        public void Init()
        {

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
    }
}
