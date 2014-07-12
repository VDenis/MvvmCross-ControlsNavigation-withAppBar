// MvxControlsContainer.cs
// (c) Copyright Christian Ruiz @_christian_ruiz
// MvvmCross - Controls Navigation Plugin is licensed using Microsoft Public License (Ms-PL)
// 

// MvxControlsContainer.cs
// (c) Copyright Denis Vlasov, Maksim Vlasov
// MvvmCross - Controls Navigation Plugin is licensed using Microsoft Public License (Ms-PL)

using System;
using System.Collections.Generic;
using System.Linq;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;

namespace MupApps.MvvmCross.Plugins.ControlsNavigation
{
    public class MvxControlsContainer
    : IMvxControlsContainer
    {
        //TODO: Check if there are some constants defined in the framework for these names
        private const string VIEWMODEL_NAME_SUFFIX = "ViewModel";
        private const string CONTROL_NAME_SUFFIX = "Control";
        private const string APPBAR_CONTROL_NAME_SUFFIX = "AppbarControl";
        private const string VIEW_NAME_SUFFIX = "View";
        private readonly List<IMvxControl> _controls = new List<IMvxControl>();
        
        public List<IMvxControl> Controls
        {
            get { return _controls; }            
        }


        public void Add(IMvxControl control)
        {
            _controls.Add(control);
        }

        public void Remove(IMvxControl control)
        {
            _controls.Remove(control);
        }

        public void ClearAll()
        {
            _controls.Clear();
        }

        public void Reset(Type viewModelType)
        {
            var controlFinder = Mvx.Resolve<IMvxControlFinder>();
            var control = controlFinder.GetControl(viewModelType);
            if (control != null)
                control.ViewModel = null;
        }

        public List<IMvxControl> GetControls(IMvxViewModel viewModelType)
        {
            return GetControls(viewModelType.GetType());
        }

        public List<IMvxControl> GetControls(Type viewModelType)
        {
            var viewModelName = viewModelType.Name;
            if (!viewModelName.EndsWith(VIEWMODEL_NAME_SUFFIX))
                return null;

            var viewModelPrefix = viewModelName.Substring(0,
                viewModelName.LastIndexOf(VIEWMODEL_NAME_SUFFIX, StringComparison.CurrentCulture));
            var controlName = string.Format("{0}{1}", viewModelPrefix, CONTROL_NAME_SUFFIX);
            var appbarControlName = string.Format("{0}{1}", viewModelPrefix, APPBAR_CONTROL_NAME_SUFFIX);
            var viewName = string.Format("{0}{1}", viewModelPrefix, VIEW_NAME_SUFFIX);

            List<IMvxControl> controlList = new List<IMvxControl>();

            var control = _controls.FirstOrDefault
                (c =>
                {
                    var name = c.GetType().Name;
                    return
                        string.Equals(name, controlName, StringComparison.CurrentCulture) ||
                        string.Equals(name, viewName, StringComparison.CurrentCulture);
                });

            if (control != null)
            {
                controlList.Add(control);
            }


            if (true)
            {
                control = _controls.FirstOrDefault
                (c =>
                {
                    var name = c.GetType().Name;
                    return
                        string.Equals(name, appbarControlName, StringComparison.CurrentCulture);
                });
            }
            if (control !=null)
            {
                controlList.Add(control);
            }
            

            return controlList; 
        }

        public IMvxControl GetControl(IMvxViewModel viewModelType)
        {
            return GetControl(viewModelType.GetType());
        }

        public IMvxControl GetControl(Type viewModelType)
        {
            var viewModelName = viewModelType.Name;
            if (!viewModelName.EndsWith(VIEWMODEL_NAME_SUFFIX))
                return null;

            var viewModelPrefix = viewModelName.Substring(0,
                viewModelName.LastIndexOf(VIEWMODEL_NAME_SUFFIX, StringComparison.CurrentCulture));
            var controlName = string.Format("{0}{1}", viewModelPrefix, CONTROL_NAME_SUFFIX);
            var viewName = string.Format("{0}{1}", viewModelPrefix, VIEW_NAME_SUFFIX);

            var control = _controls.FirstOrDefault
                (c =>
                {
                    var name = c.GetType().Name;
                    return
                        string.Equals(name, controlName, StringComparison.CurrentCulture) ||
                        string.Equals(name, viewName, StringComparison.CurrentCulture);
                });

            return control;
        }
    }
}
