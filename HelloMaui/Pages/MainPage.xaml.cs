using HelloMaui.Models;
using HelloMaui.PageModels;

namespace HelloMaui.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}