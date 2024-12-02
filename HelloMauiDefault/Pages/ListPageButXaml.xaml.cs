using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Markup;
using CommunityToolkit.Maui.Views;
using HelloMauiDefault.Pages;
using HelloMauiDefault.ViewModels;

namespace HelloMauiDefault;

public partial class ListPageButXaml : BaseContentPage<ListViewModel>
{
	public ListPageButXaml(ListViewModel vm) : base(vm)
	{
		InitializeComponent();
	}

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		await Toast.Make(".NET MAUI Alp").Show();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        this.ShowPopup(new WelcomePopup());
        //if (BindingContext is ListViewModel viewModel)
        //{
        //    viewModel.SelectedItem = null;
        //}
    }

    class WelcomePopup : Popup
    {
        public WelcomePopup()
        {
            Content = new Label()
                .Text("WelcomeBro")
                .Font(size: 42, bold: true)
                .Center()
                .TextCenter();
        }
    }
}