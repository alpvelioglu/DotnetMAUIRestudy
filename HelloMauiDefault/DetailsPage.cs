using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Markup;

namespace HelloMauiDefault
{
    public class DetailsPage : BaseContentPage, IQueryAttributable
    {
        public const string LibraryModelKey = nameof(LibraryModelKey);
        readonly Image _libraryImage;
        readonly Label _libraryTitleLabel;
        readonly Label _libraryDescLabel;
        public DetailsPage()
        {
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
                    .Assign(out _libraryImage),

                    new Label()
                    .TextCenter()
                    .Center()
                    .Font(bold: true, size: 24)
                    .Assign(out _libraryTitleLabel),

                    new Label()
                    .TextCenter()
                    .Center()
                    .Font(italic: true, size: 16)
                    .Assign(out _libraryDescLabel), // Yanlışıkla title vermiştim. Null hatası fırlatıyordu aman dikkat.

                    new Button()
                    .Text("Back")
                    .Invoke(btn => btn.Clicked += HandleButtonClicked)
                }
            }.Center().Padding(12);
        }

        private async void HandleButtonClicked(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..", true);
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            //throw new NotImplementedException();
            var libraryModel = (LibraryModel)query[LibraryModelKey];

            Title = libraryModel.Title;

            _libraryImage.Source = libraryModel.ImageSource;
            _libraryTitleLabel.Text = libraryModel.Title;
            _libraryDescLabel.Text = libraryModel.Description;
        }
    }
}
