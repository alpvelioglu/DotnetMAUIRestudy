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
            Items.Add(new CollectionViewDemo_Markup());
            Routing.RegisterRoute(GetRoute<CollectionViewDemo_Markup>(), typeof(DetailsPage));
            Routing.RegisterRoute(GetRoute<DetailsPage>(), typeof(DetailsPage));
        }

        public static string GetRoute<T>() where T : class
        {
            if(typeof(T) == typeof(DetailsPage))
            {
                return $"//{nameof(CollectionViewDemo_Markup)}/{nameof(DetailsPage)}";
            }
            else if(typeof(T) == typeof(CollectionViewDemo_Markup))
            {
                return $"//{nameof(CollectionViewDemo_Markup)}";
            }
            else
            {
                throw new ArgumentException("Invalid route type");
            }
        }
    }
}
