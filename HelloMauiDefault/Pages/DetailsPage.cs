using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Markup;
using HelloMauiDefault.Models;
using HelloMauiDefault.ViewModels;

namespace HelloMauiDefault.Pages
{
    public class DetailsPage : BaseContentPage<DetailsViewModel>
    {
        public DetailsPage(DetailsViewModel viewModel) : base(viewModel)
        {
            this.Bind(DetailsPage.TitleProperty, (DetailsViewModel vm) => vm.LibraryTitle);

            Shell.SetBackButtonBehavior(this, new BackButtonBehavior
            {
#if ANDROID
                TextOverride = "< List"
#else
                TextOverride = "List"
#endif
            });
            Content = new VerticalStackLayout
            {
                Spacing = 12,

                Children =
                {
                    new Image()
                    .Center()
                    .Size(250)
                    .Bind(Image.SourceProperty, getter: (DetailsViewModel vm) => vm.LibraryImageSource),

                    new Label()
                    .TextCenter()
                    .Center()
                    .Font(bold: true, size: 24)
                    .Bind(Label.TextProperty, getter: (DetailsViewModel vm) => vm.LibraryTitle),

                    new Label()
                    .TextCenter()
                    .Center()
                    .Font(italic: true, size: 16)
                    //.Assign(out _libraryDescLabel) // Yanlışıkla title vermiştim. Null hatası fırlatıyordu aman dikkat.
                    .Bind(Label.TextProperty, getter: (DetailsViewModel vm) => vm.LibraryDescription),

                    new Button()
                    .Text("Back")
                    .Bind(Button.CommandProperty, getter: (DetailsViewModel vm) => vm.HandleButtonClickedCommand)
                }
            }.Center().Padding(12);
        }
    }
}
