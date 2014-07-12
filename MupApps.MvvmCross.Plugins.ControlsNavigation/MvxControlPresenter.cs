// MvxControlPresenter.cs
// (c) Copyright Christian Ruiz @_christian_ruiz
// MvvmCross - Controls Navigation Plugin is licensed using Microsoft Public License (Ms-PL)
// 

// MvxControlPresenter.cs
// (c) Copyright Denis Vlasov, Maksim Vlasov
// MvvmCross - Controls Navigation Plugin is licensed using Microsoft Public License (Ms-PL)

using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;
using System.Collections.Generic;

namespace MupApps.MvvmCross.Plugins.ControlsNavigation
{
    public class MvxControlPresenter : IMvxViewPresenter
    {
        protected readonly IMvxViewPresenter _viewPresenter;

        public MvxControlPresenter(IMvxViewPresenter viewPresenter)
        {
            _viewPresenter = viewPresenter;
        }

        public virtual void Show(MvxViewModelRequest request)
        {
            IMvxControlFinder finder;

            if (Mvx.TryResolve(out finder))
            {
                List<IMvxControl> controlList = finder.GetControls(request.ViewModelType);

                var loaderService = Mvx.Resolve<IMvxViewModelLoader>();
                var viewModel = loaderService.LoadViewModel(request, new MvxBundle());

                foreach (var control in controlList)
                {
                    if (control != null)
                    {
                        control.ViewModel = viewModel;
                    }
                }

                return;

            }

            _viewPresenter.Show(request);
        }

        public virtual void ChangePresentation(MvxPresentationHint hint)
        {
            if (hint is MvxClosePresentationHint)
            {
                var finder = Mvx.Resolve<IMvxControlFinder>();
                var control = finder.GetControl((hint as MvxClosePresentationHint).ViewModelToClose);
                if (control != null)
                    control.ViewModel = null;
                else
                    _viewPresenter.ChangePresentation(hint);
            }
            else
                _viewPresenter.ChangePresentation(hint);
        }
    }
}
