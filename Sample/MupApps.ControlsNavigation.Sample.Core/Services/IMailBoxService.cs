// IMailBoxService.cs
// (c) Copyright Christian Ruiz @_christian_ruiz
// MvvmCross - Controls Navigation Plugin is licensed using Microsoft Public License (Ms-PL)
// 

// IMailBoxService.cs
// (c) Copyright Denis Vlasov, Maksim Vlasov
// MvvmCross - Controls Navigation Plugin is licensed using Microsoft Public License (Ms-PL)

using System.Collections.Generic;
using System.Threading.Tasks;
using MupApps.ControlsNavigation.Sample.Core.Model;
using System.Collections.ObjectModel;

namespace MupApps.ControlsNavigation.Sample.Core.Services
{
    public interface IMailBoxService
    {
        List<Folder> GetFolders();

        //Task<List<Mail>> GetMailsAsync(string folder);

        Task<ObservableCollection<Mail>> GetMailsAsync(string folder);

        Task<Mail> GetMailAsync(int mailId);

        Task<bool> InformViewModel(string viewModelName);
    }
}
