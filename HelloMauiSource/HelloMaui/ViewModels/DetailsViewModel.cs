namespace HelloMaui;

public partial class DetailsViewModel : BaseViewModel, IQueryAttributable
{
	public const string LibraryQueryKey = nameof(LibraryQueryKey);
	
	[ObservableProperty]
	string? _libraryTitle, _libraryDescription;
	
	[ObservableProperty]
	ImageSource? _libraryImageSource;
	
	[RelayCommand]
	Task BackButtonTapped() => Shell.Current.GoToAsync("..", true);

	void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
	{
		var library = (LibraryModel)query[LibraryQueryKey];

		LibraryTitle = library.Title;
		LibraryImageSource = library.ImageSource;
		LibraryDescription = library.Description;
	}
}