﻿using CommunityToolkit.Mvvm.Input;
using HelloMauiDefault.Models;
using HelloMauiDefault.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HelloMauiDefault.ViewModels
{
    public class ListViewModel : BaseViewModel
    {
        string _searchBarText = string.Empty;
        bool _isSearchBarEnabled = true;
        bool _isRefreshing = false;
        object? _selectedItem = null;
        public string SearchBarText
        {
            get => _searchBarText;
            set => SetProperty(ref _searchBarText, value);
        }

        public bool IsSearchBarEnabled
        {
            get => _isSearchBarEnabled;
            set => SetProperty(ref _isSearchBarEnabled, value);
        }

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }

        public object? SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        public ListViewModel()
        {
            UserStoppedTypingCommand = new RelayCommand(UserStoppedTyping);
            RefreshCommand = new AsyncRelayCommand(HandleRefreshing);
            HandleSelectionChangedCommand = new AsyncRelayCommand(HandleSelectionChanged);
        }
        public ICommand UserStoppedTypingCommand { get; }
        public ICommand RefreshCommand { get; }
        public ICommand HandleSelectionChangedCommand { get; }
        public ObservableCollection<LibraryModel> MauiLibraries { get; } = new(CreateLibraries());
        void UserStoppedTyping()
        {
            MauiLibraries.Clear();
            if (string.IsNullOrWhiteSpace(SearchBarText))
            {
                foreach (var library in CreateLibraries())
                {
                    MauiLibraries.Add(library);
                }
            }
            else
            {
                foreach (var library in CreateLibraries().Where(x => x.Title.Contains(SearchBarText, StringComparison.OrdinalIgnoreCase)))
                {
                    MauiLibraries.Add(library);
                }
            }
        }

        async Task HandleRefreshing()
        {
            IsSearchBarEnabled = false;

            try
            {
                await Task.Delay(TimeSpan.FromSeconds(2));
                MauiLibraries.Add(new LibraryModel
                {
                    Title = "Sharpnado.Tabs",
                    Description = "A pure MAUI Tabs library",
                    ImageSource = "https://api.nuget.org/v3-flatcontainer/sharpnado.tabs/2.2.0/icon"
                });
            }
            finally
            {
                IsRefreshing = false;
                IsSearchBarEnabled = true;
            }
        }

        public async Task HandleSelectionChanged()
        {
            if (SelectedItem is LibraryModel library)
            {
                await Shell.Current.GoToAsync(AppShell.GetRoute<DetailsPage>(), new Dictionary<string, object>()
                {
                    { DetailsViewModel.LibraryModelKey, library }
                });
            }
            //SelectedItem = null;
        }

        static List<LibraryModel> CreateLibraries() => new()
        {
            new()
            {
                Title = "Microsoft.Maui",
                Description = ".NET Multi-platform App UI is a framework for building native device applications spanning mobile, tablet, and desktop",
                ImageSource = "https://api.nuget.org/v3-flatcontainer/microsoft.maui.controls/8.0.3/icon"
            },
            new()
            {
                Title = "CommunityToolkit.Maui",
                Description = "The .NET MAUI Community Toolkit is a community-created library that contains .NET MAUI Extensions, Advanced UI/UX Controls, and Behaviors to help make your life as a .NET MAUI developer easier",
                ImageSource = "https://api.nuget.org/v3-flatcontainer/communitytoolkit.maui/5.2.0/icon"
            },
            new()
            {
                Title = "CommunityToolkit.Maui.Markup",
                Description = "The .NET MAUI Markup Community Toolkit is a community-created library that contains Fluent C# Extension Methods to easily create your User Interface in C#",
                ImageSource = "https://api.nuget.org/v3-flatcontainer/communitytoolkit.maui.markup/3.2.0/icon"
            },
            new()
            {
                Title = "CommunityToolkit.MVVM",
                Description = "This package includes a .NET MVVM library with helpers such as ObservableObject, ObservableRecipient, ObservableValidator, RelayCommand, AsyncRelayCommand, WeakReferenceMessenger, StrongReferenceMessenger and IoC",
                ImageSource = "https://api.nuget.org/v3-flatcontainer/communitytoolkit.mvvm/8.2.0/icon"
            },
            new()
            {
                Title = "Sentry.Maui",
                Description = "Bad software is everywhere, and we're tired of it. Sentry is on a mission to help developers write better software faster, so we can get back to enjoying technology",
                ImageSource = "https://api.nuget.org/v3-flatcontainer/sentry.maui/3.33.1/icon"
            },
            new()
            {
                Title = "Esri.ArcGISRuntime.Maui",
                Description = "Contains APIs and UI controls for building native mobile and desktop apps with the .NET Multi-platform App UI (.NET MAUI) cross-platform framework",
                ImageSource = "https://api.nuget.org/v3-flatcontainer/esri.arcgisruntime.maui/100.14.1-preview3/icon"
            },
            new()
            {
                Title = "Syncfusion.Maui.Core",
                Description = "This package contains .NET MAUI Avatar View, .NET MAUI Badge View, .NET MAUI Busy Indicator, .NET MAUI Effects View, and .NET MAUI Text Input Layout components for .NET MAUI application",
                ImageSource = "https://api.nuget.org/v3-flatcontainer/syncfusion.maui.core/21.2.10/icon"
            },
            new()
            {
                Title = "DotNet.Meteor",
                Description = "A VSCode extension that can run and debug .NET apps (based on Clancey VSCode.Comet)",
                ImageSource = "https://nromanov.gallerycdn.vsassets.io/extensions/nromanov/dotnet-meteor/3.0.3/1686392945636/Microsoft.VisualStudio.Services.Icons.Default"
            },
        };
    }
}
