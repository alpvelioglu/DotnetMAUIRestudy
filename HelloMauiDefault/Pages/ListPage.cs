using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Maui.Markup;
using CommunityToolkit.Maui.Views;
using HelloMauiDefault.Models;
using HelloMauiDefault.ViewModels;
using HelloMauiDefault.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloMauiDefault.Pages
{
    public class ListPage : BaseContentPage<ListViewModel>
    {
        public ListPage(ListViewModel viewModel) : base(viewModel)
        {
            this.AppThemeBinding(BackgroundColorProperty, Colors.LightBlue, Color.FromArgb("#3b4a4f"));

            Content = new RefreshView
            {
                Content = new CollectionView
                {
                    Header = new SearchBar()
                        .Placeholder("Search Titles")
                        .Center()
                        .TextCenter()
                        .Behaviors(new UserStoppedTypingBehavior()
                        {
                            BindingContext = viewModel,
                            StoppedTypingTimeThreshold = 1000,
                            ShouldDismissKeyboardAutomatically = true,
                        }.Bind(UserStoppedTypingBehavior.CommandProperty, getter: (ListViewModel vm) => vm.UserStoppedTypingCommand))
                        .TapGesture(async () =>
                        {
                            await Toast.Make(".NET MAUI RULES!").Show();
                        })
                        .Bind(SearchBar.TextProperty, getter: (ListViewModel vm) => vm.SearchBarText, setter: (ListViewModel vm, string text) => vm.SearchBarText = text)
                        .Bind(SearchBar.IsEnabledProperty, getter: (ListViewModel vm) => vm.IsSearchBarEnabled),

                    Footer = new Label()
                        .Text(".NET MAUI: From Zero to Hero")
                        .TextCenter()
                        .Center()
                        .Font(size: 10)
                        .Paddings(left: 8),

                    SelectionMode = SelectionMode.Single,

                }
                .ItemTemplate(new MauiLibrariesDataTemplate())
                .Bind(CollectionView.SelectedItemProperty, 
                      getter: (ListViewModel vm) => vm.SelectedItem, 
                      setter: (ListViewModel vm, object? selectedItem) => vm.SelectedItem = selectedItem)
                .Bind(CollectionView.SelectionChangedCommandProperty, getter: (ListViewModel vm) => vm.HandleSelectionChangedCommand)
                .Bind(CollectionView.ItemsSourceProperty, getter: (ListViewModel vm) => vm.MauiLibraries)
            }.Bind(RefreshView.CommandProperty, getter: (ListViewModel vm) => vm.HandleRefreshingCommand)
            .Bind(RefreshView.IsRefreshingProperty, getter: (ListViewModel vm) => vm.IsRefreshing, setter: (ListViewModel vm, bool isRefreshing) => vm.IsRefreshing = isRefreshing);
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
}
