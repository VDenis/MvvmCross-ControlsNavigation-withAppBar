// IMvxControlFinder.cs
// (c) Copyright Christian Ruiz @_christian_ruiz
// MvvmCross - Controls Navigation Plugin is licensed using Microsoft Public License (Ms-PL)
// 

// IMvxControlFinder.cs
// (c) Copyright Denis Vlasov, Maksim Vlasov
// MvvmCross - Controls Navigation Plugin is licensed using Microsoft Public License (Ms-PL)

using System;
using Cirrious.MvvmCross.ViewModels;
using System.Collections.Generic;

namespace MupApps.MvvmCross.Plugins.ControlsNavigation
{
    public interface IMvxControlFinder
    {
        IMvxControl GetControl(Type viewModelType);

        IMvxControl GetControl(IMvxViewModel viewModelType);

        List<IMvxControl> GetControls(Type viewModelType);

        List<IMvxControl> GetControls(IMvxViewModel viewModelType);
    }
}
