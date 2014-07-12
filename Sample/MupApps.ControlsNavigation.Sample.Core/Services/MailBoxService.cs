// MailBoxService.cs
// (c) Copyright Christian Ruiz @_christian_ruiz
// MvvmCross - Controls Navigation Plugin is licensed using Microsoft Public License (Ms-PL)
// 

// MailBoxService.cs
// (c) Copyright Denis Vlasov, Maksim Vlasov
// MvvmCross - Controls Navigation Plugin is licensed using Microsoft Public License (Ms-PL)

using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MupApps.ControlsNavigation.Sample.Core.Model;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using Cirrious.MvvmCross.Plugins.Messenger;

namespace MupApps.ControlsNavigation.Sample.Core.Services
{
    /// <summary>
    /// Based on the Knockout tutorial http://learn.knockoutjs.com/#/?tutorial=webmail
    /// </summary>
    public class MailBoxService : IMailBoxService
    {
        private const string ServiceUrl = "http://learn.knockoutjs.com/mail";
        private const string FolderParam = "?folder=";
        private const string MailIdParam = "?mailId=";

        private readonly IMvxMessenger _messenger;

        public MailBoxService(IMvxMessenger messenger)
        {
            _messenger = messenger;
        }

        public async Task<bool> InformViewModel(string viewModelName)
        {
            _messenger.Publish(new AppBarRaiseEventMessage(this, viewModelName));
            return true;
        }

        public List<Folder> GetFolders()
        {
            return new List<Folder>()
            {
                new Folder { Name= "Inbox" }, 
                new Folder { Name= "Archive" },
                new Folder { Name= "Sent" },
                new Folder { Name= "Spam" }
            };
        }

        //public async Task<List<Mail>> GetMailsAsync(string folder)
        public async Task<ObservableCollection<Mail>> GetMailsAsync(string folder)
        {
            var client = new HttpClient();
            var url = string.Format("{0}{1}{2}", ServiceUrl, FolderParam, folder);
            var json = await client.GetStringAsync(url);
            var mails = new ObservableCollection<Mail>(JObject.Parse(json)["mails"].Select(ParseMail).ToList());
            return mails;
        }

        public async Task<Mail> GetMailAsync(int mailId)
        {
            var client = new HttpClient();
            var url = string.Format("{0}{1}{2}", ServiceUrl, MailIdParam, mailId);
            var json = await client.GetStringAsync(url);
            var mail = ParseMail(JObject.Parse(json));
            return mail;
        }

        private static Mail ParseMail(JToken m)
        {
            return new Mail
            {
                Id = m.Value<int>("id"),
                From = m.Value<string>("from"),
                To = m.Value<string>("to"),
                Date = m.Value<string>("date"),
                Subject = m.Value<string>("subject"),
                Body = m.Value<string>("messageContent")
            };
        }
    }
}
