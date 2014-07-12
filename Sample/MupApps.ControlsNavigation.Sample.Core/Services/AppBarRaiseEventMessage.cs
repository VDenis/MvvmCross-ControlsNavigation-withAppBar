// AppBarRaiseEventMessage.cs
// (c) Copyright Denis Vlasov, Maksim Vlasov
// MvvmCross - Controls Navigation Plugin is licensed using Microsoft Public License (Ms-PL)

using Cirrious.MvvmCross.Plugins.Messenger;

namespace MupApps.ControlsNavigation.Sample.Core.Services
{
    class AppBarRaiseEventMessage : MvxMessage
    {
        public AppBarRaiseEventMessage(object sender, string viewModelName)
            : base(sender)
        {
            ViewModelName = viewModelName;
            Sender = sender;
        }

        public string ViewModelName { get; private set; }
        public object Sender { get; private set; }
    }
}
