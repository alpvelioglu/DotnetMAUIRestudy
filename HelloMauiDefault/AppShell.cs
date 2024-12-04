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
            Routing.RegisterRoute(GetRoute<CalendarPage>(), typeof(CalendarPage));
        }

        public static string GetRoute<T>() where T : ContentPage
        {
            var pageType = typeof(T);

            if (pageType == typeof(ListPage))
            {
                return $"//{nameof(ListPage)}";
            }

            if (pageType == typeof(DetailsPage))
            {
                return $"//{nameof(ListPage)}/{nameof(DetailsPage)}";
            }

            if (pageType == typeof(CalendarPage))
            {
                return $"//{nameof(ListPage)}/{nameof(CalendarPage)}";
            }

            throw new NotSupportedException($"Page {pageType.FullName} Not Found in Routing Table");
        }
    }
}
