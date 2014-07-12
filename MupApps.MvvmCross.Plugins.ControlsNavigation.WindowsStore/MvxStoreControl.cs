// MvxStoreControl.cs
// (c) Copyright Christian Ruiz @_christian_ruiz
// MvvmCross - Controls Navigation Plugin is licensed using Microsoft Public License (Ms-PL)
// 

// MvxStoreControl.cs
// (c) Copyright Denis Vlasov, Maksim Vlasov
// MvvmCross - Controls Navigation Plugin is licensed using Microsoft Public License (Ms-PL)

using System;
using Windows.ApplicationModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;

namespace MupApps.MvvmCross.Plugins.ControlsNavigation.WindowsStore
{
    public class MvxStoreControl
        : UserControl, IMvxControl
    {
        public IMvxViewModel ViewModel
        {
            get { return DataContext as IMvxViewModel; }
            set
            {
                DataContext = value;
                this.CheckEmptyControlBehaviour();
            }
        }

        private readonly IMvxControlsContainer _container;

        public MvxStoreControl()
        {
            DataContext = null;

            EmptyControlBehaviour = this.GetDefaultEmptyControlBehaviour();

            if (DesignMode.DesignModeEnabled)
                return;

            if (!Mvx.CanResolve<IMvxControlsContainer>())
                new Plugin().Load();
            
            _container = Mvx.Resolve<IMvxControlsContainer>();

            #region Comment
            //MvxControlsContainer temp3 = (MvxControlsContainer)_container;

            //bool temp4 = temp3.Controls.Contains(this);

            //if (!temp4)
            //{
            //    _container.Add(this);
            //}

            //bool temp4 = ((MvxControlsContainer)_container).Controls.Contains(this);
            #endregion

            if (!((MvxControlsContainer)_container).Controls.Contains(this))
            {
                _container.Add(this);
            }
            
            Loaded += MvxStoreControl_Loaded;
            Unloaded += MvxStoreControl_Unloaded;
        }

        void MvxStoreControl_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            #region Comment
            //MvxControlsContainer temp3 = (MvxControlsContainer)_container;

            //bool temp4 = temp3.Controls.Contains(this);
            #endregion

            if (!((MvxControlsContainer)_container).Controls.Contains(this))
            {
                _container.Add(this);
            }
        }

        void MvxStoreControl_Unloaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
           // if(e.OriginalSource.)
           // _container.Remove(this);
        }

        public void ResetControl(Type viewModelType)
        {
            _container.Reset(viewModelType);
        }

        private EmptyControlBehaviours? _emptyControlBehaviour;
        public EmptyControlBehaviours EmptyControlBehaviour
        {
            get
            {
                return _emptyControlBehaviour.HasValue
                    ? _emptyControlBehaviour.Value
                    : this.GetDefaultEmptyControlBehaviour();
            }
            set
            {
                var lastBehaviour = _emptyControlBehaviour;
                _emptyControlBehaviour = value;
                this.CheckEmptyControlBehaviour(lastBehaviour);    
            }
        }

        public void ChangeVisibility(bool visible)
        {
            Visibility = visible ? Visibility.Visible : Visibility.Collapsed;
        }

        public void ChangeEnabled(bool enabled)
        {
            IsEnabled = enabled;
        }
    }
}
