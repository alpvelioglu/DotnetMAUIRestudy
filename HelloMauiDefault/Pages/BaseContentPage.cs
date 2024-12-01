using HelloMauiDefault.ViewModels;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloMauiDefault.Pages
{
    public abstract class BaseContentPage<TViewModel> : ContentPage where TViewModel : BaseViewModel
    {
        public BaseContentPage(TViewModel viewModel)
        {
            On<iOS>().SetUseSafeArea(true);
            BindingContext = viewModel;
        }
    }
}
