// MailViewModel.cs
// (c) Copyright Christian Ruiz @_christian_ruiz
// MvvmCross - Controls Navigation Plugin is licensed using Microsoft Public License (Ms-PL)
// 

// MailViewModel.cs
// (c) Copyright Denis Vlasov, Maksim Vlasov
// MvvmCross - Controls Navigation Plugin is licensed using Microsoft Public License (Ms-PL)

using Cirrious.MvvmCross.ViewModels;
using MupApps.ControlsNavigation.Sample.Core.Model;
using MupApps.ControlsNavigation.Sample.Core.Services;

namespace MupApps.ControlsNavigation.Sample.Core.ViewModels
{
    public class MailViewModel : MvxViewModel
    {
        private readonly IMailBoxService _mailBoxService;

        public MailViewModel(IMailBoxService mailBoxService)
        {
            _mailBoxService = mailBoxService;
        }

        public async void Init(Mail mail)
        {
            Mail = await _mailBoxService.GetMailAsync(mail.Id);
        }

        private Mail _mail;
        public Mail Mail
        {
            get { return _mail; }
            set { _mail = value; RaisePropertyChanged(() => Mail); }
        }

        private MvxCommand _mailViewCommand;

        public MvxCommand MailViewCommand
        {
            get
            {
                _mailViewCommand = _mailViewCommand ?? new MvxCommand(DoMailViewCommand);
                return _mailViewCommand;
            }
        }

        private void DoMailViewCommand()
        {
            Mail = new Model.Mail() { From = "MailViewAppBar", Subject = "MailViewAppBar", Body = "MailViewAppBar" };
        }

        private MvxCommand _mailTapCommand;

        public MvxCommand MailTapCommand
        {
            get
            {
                _mailTapCommand = _mailTapCommand ?? new MvxCommand(DoMailTapCommand);
                return _mailTapCommand;
            }
        }

        private void DoMailTapCommand()
        {
            _mailBoxService.InformViewModel("MailViewModel");
        }

        private MvxCommand _mailRightTapCommand;

        public MvxCommand MailRightTapCommand
        {
            get
            {
                _mailRightTapCommand = _mailRightTapCommand ?? new MvxCommand(DoMailRightTapCommand);
                return _mailRightTapCommand;
            }
        }

        private void DoMailRightTapCommand()
        {

        }
    }
}
