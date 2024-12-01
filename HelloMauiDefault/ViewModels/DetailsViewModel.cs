using HelloMauiDefault.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace HelloMauiDefault.ViewModels
{
    public class DetailsViewModel : BaseViewModel, IQueryAttributable
    {
        public const string LibraryModelKey = nameof(LibraryModelKey);
        ImageSource? _libraryImageSource;
        string? _libraryTitle;
        string? _libraryDescription;

        public ICommand BackButtonCommand { get; }

        public DetailsViewModel()
        {
            BackButtonCommand = new AsyncRelayCommand(() => HandleButtonClicked());
        }

        public ImageSource? LibraryImageSource
        {
            get => _libraryImageSource;
            set => SetProperty(ref _libraryImageSource, value);
        }

        public string? LibraryTitle
        {
            get => _libraryTitle;
            set => SetProperty(ref _libraryTitle, value);
        }

        public string? LibraryDescription
        {
            get => _libraryDescription;
            set => SetProperty(ref _libraryDescription, value);
        }
        private async Task HandleButtonClicked()
        {
            await Shell.Current.GoToAsync("..", true);
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            //throw new NotImplementedException();
            var libraryModel = (LibraryModel)query[LibraryModelKey];

            LibraryImageSource = libraryModel.ImageSource;
            LibraryTitle = libraryModel.Title;
            LibraryDescription = libraryModel.Description;
        }
    }
}
