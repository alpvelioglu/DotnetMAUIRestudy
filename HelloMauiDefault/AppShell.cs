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
        //public AppShell()
        //{
        //    Items.Add(new ListPage(new ListViewModel()));
        //    Routing.RegisterRoute(GetRoute<ListPage>(), typeof(DetailsPage));
        //    Routing.RegisterRoute(GetRoute<DetailsPage>(), typeof(DetailsPage));
        //}

        //public static string GetRoute<T>() where T : ContentPage
        //{
        //    if(typeof(T) == typeof(DetailsPage))
        //    {
        //        return $"//{nameof(ListPage)}/{nameof(DetailsPage)}";
        //    }
        //    else if(typeof(T) == typeof(ListPage))
        //    {
        //        return $"//{nameof(ListPage)}";
        //    }
        //    else
        //    {
        //        throw new ArgumentException("Invalid route type");
        //    }
        //}

        public AppShell()
        {
            Items.Add(new ListPageButXaml(new ListViewModel()));
            Routing.RegisterRoute(GetRoute<ListPageButXaml>(), typeof(DetailsPageButXaml));
            Routing.RegisterRoute(GetRoute<DetailsPageButXaml>(), typeof(DetailsPageButXaml));
        }

        public static string GetRoute<T>() where T : ContentPage
        {
            if (typeof(T) == typeof(DetailsPageButXaml))
            {
                return $"//{nameof(ListPageButXaml)}/{nameof(DetailsPageButXaml)}";
            }
            else if (typeof(T) == typeof(ListPageButXaml))
            {
                return $"//{nameof(ListPageButXaml)}";
            }
            else
            {
                throw new ArgumentException("Invalid route type");
            }
        }
    }
}
