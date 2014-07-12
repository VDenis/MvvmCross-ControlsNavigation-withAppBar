// SettingViewModel.cs
// (c) Copyright Denis Vlasov, Maksim Vlasov
// MvvmCross - Controls Navigation Plugin is licensed using Microsoft Public License (Ms-PL)

using Cirrious.MvvmCross.ViewModels;
using MupApps.ControlsNavigation.Sample.Core.Model;
using MupApps.ControlsNavigation.Sample.Core.Services;
using System.Collections.ObjectModel;

namespace MupApps.ControlsNavigation.Sample.Core.ViewModels
{
    public class SettingViewModel : MvxViewModel
    {
        public async void Init()
        {
           
        }

        private ObservableCollection<string> _listStrings = new ObservableCollection<string>();
        public ObservableCollection<string> ListStrings
        {
            get { return _listStrings; }
            set { _listStrings = value; RaisePropertyChanged(() => ListStrings); }
        }

        private ObservableCollection<int> _listInt = new ObservableCollection<int>();
        public ObservableCollection<int> ListInt
        {
            get { return _listInt; }
            set { if (_listInt == value) return; _listInt = value; RaisePropertyChanged(() => ListInt); }
        }

        private int _testInt = 0;
        public int TestInt
        {
            get { return _testInt; }
            set { if (_testInt == value) return; _testInt = value; RaisePropertyChanged(() => TestInt); RaisePropertyChanged(() => TestIntText); }
        }

        
        public string TestIntText
        {
            get { return _testInt.ToString(); }            
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
            TestInt = TestInt + 1;
            ListStrings.Add((TestInt).ToString());
        }
    }
}
