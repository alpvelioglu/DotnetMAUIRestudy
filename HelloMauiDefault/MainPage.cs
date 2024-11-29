using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Markup;
using Microsoft.Maui.Layouts;
using static CommunityToolkit.Maui.Markup.GridRowsColumns;

namespace HelloMauiDefault
{
    public class MainPage : BaseContentPage
    {
        const int imageWidthRequest = 500;
        const int imageHeightRequest = 250;
        const int labelHeightRequest = 32;
        const int absoluteLayoutChildrenSpacing = 12;
        public MainPage()
        {
            BackgroundColor = Colors.DarkViolet;
            //Content = new AbsoluteLayout()
            //{
            //    BackgroundColor = Colors.LightSteelBlue,
            //    Children =
            //    {
            //        new Image()
            //        .Size(imageWidthRequest, imageHeightRequest)
            //        .Aspect(Aspect.AspectFit)
            //        .Source("dotnet_bot")
            //        .LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
            //        .LayoutBounds(0.5, 0),

            //        new Label().Text("Welcome to .NET MAUI!").Font(size: 24).Center().TextCenter()
            //                   .Height(labelHeightRequest)
            //                   .LayoutFlags(AbsoluteLayoutFlags.XProportional)
            //                   .LayoutBounds(0.5, imageHeightRequest + absoluteLayoutChildrenSpacing),

            //        new Entry().Placeholder("First Entry", Colors.DarkGray).TextColor(Colors.Black)
            //                   .LayoutFlags(AbsoluteLayoutFlags.XProportional | AbsoluteLayoutFlags.WidthProportional)
            //                   .LayoutBounds(0, imageHeightRequest + absoluteLayoutChildrenSpacing + labelHeightRequest + absoluteLayoutChildrenSpacing, 0.3, labelHeightRequest),

            //        new Entry().Placeholder("Second Entry", Colors.DarkGray).TextColor(Colors.Black).LayoutFlags(AbsoluteLayoutFlags.XProportional | AbsoluteLayoutFlags.WidthProportional)
            //                   .LayoutBounds(0.5, imageHeightRequest + absoluteLayoutChildrenSpacing + labelHeightRequest + absoluteLayoutChildrenSpacing, 0.3, labelHeightRequest),

            //        new Entry().Placeholder("Third Entry", Colors.DarkGray).TextColor(Colors.Black).LayoutFlags(AbsoluteLayoutFlags.XProportional | AbsoluteLayoutFlags.WidthProportional)
            //                   .LayoutBounds(1, imageHeightRequest + absoluteLayoutChildrenSpacing + labelHeightRequest + absoluteLayoutChildrenSpacing, 0.3, labelHeightRequest)
            //    }
            //};
            Content = new ScrollView()
            {
                Content = new Grid()
                {
                    RowSpacing = 12,
                    ColumnSpacing = 12,
                    RowDefinitions = Rows.Define((Row.Image, Star), (Row.Label, 32), (Row.Entry, 40), (Row.LargeTextEntry, 800)),
                    ColumnDefinitions = Columns.Define((Column.First, Star), (Column.Second, Star), (Column.Third, Star)),
                    BackgroundColor = Colors.LightSteelBlue,
                    Children =
                {
                    new Image()
                    .Size(imageWidthRequest, imageHeightRequest)
                    .Aspect(Aspect.AspectFit)
                    .Source("dotnet_bot")
                    .Row(Row.Image).ColumnSpan(All<Column>()),

                    new Label().BackgroundColor(Colors.Green).Text("Welcome to .NET MAUI!").Font(size: 24).Center().TextCenter().Margins(5,2,15,20).Paddings(5, 10, 15, 30).Row(Row.Label).ColumnSpan(All<Column>()),

                    new Entry().Placeholder("First Entry", Colors.DarkGray).TextColor(Colors.Black).Row(Row.Entry).Column(Column.First),

                    new Entry().Placeholder("Second Entry", Colors.DarkGray).TextColor(Colors.Black).Row(Row.Entry).Column(Column.Second),

                    new Entry().Placeholder("Third Entry", Colors.DarkGray).TextColor(Colors.Black).Row(Row.Entry).Column(Column.Third),

                    new Label{ LineBreakMode = LineBreakMode.WordWrap }.Text("LARGE TEXT", Colors.DarkGray).Font(size: 100).TextColor(Colors.Black).Row(Row.LargeTextEntry).ColumnSpan(All<Column>()).TextCenter(),
                }
                }.Top().CenterHorizontal().Padding(12).Margin(0,6)
            };
        }

        enum Row
        {
            Image,
            Label,
            Entry,
            LargeTextEntry,
        }

        enum Column
        {
            First,
            Second,
            Third
        }
    }
}
