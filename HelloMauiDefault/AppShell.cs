using HelloMauiDefault.Pages;
using HelloMauiDefault.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloMauiDefault
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            Items.Add(new ListPage(new ListViewModel()));
            Routing.RegisterRoute(GetRoute<ListPage>(), typeof(DetailsPage));
            Routing.RegisterRoute(GetRoute<DetailsPage>(), typeof(DetailsPage));
        }

        public static string GetRoute<T>() where T : ContentPage
        {
            if(typeof(T) == typeof(DetailsPage))
            {
                return $"//{nameof(ListPage)}/{nameof(DetailsPage)}";
            }
            else if(typeof(T) == typeof(ListPage))
            {
                return $"//{nameof(ListPage)}";
            }
            else
            {
                throw new ArgumentException("Invalid route type");
            }
        }
    }
}
