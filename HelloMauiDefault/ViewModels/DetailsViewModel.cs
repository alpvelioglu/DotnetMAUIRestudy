using HelloMauiDefault.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace HelloMauiDefault.ViewModels
{
    public partial class DetailsViewModel : BaseViewModel, IQueryAttributable
    {
        public const string LibraryModelKey = nameof(LibraryModelKey);
        [ObservableProperty]
        ImageSource? _libraryImageSource;

        [ObservableProperty]
        string? _libraryTitle;

        [ObservableProperty]
        string? _libraryDescription;

        [RelayCommand]
        public async Task HandleButtonClicked()
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
