﻿using HelloMauiDefault.Views;
using Microsoft.Maui.Handlers;
using UIKit;
using Microsoft.Maui.Platform;
using Foundation;

namespace HelloMauiDefault.Handlers
{
    public sealed class CalendarSelectionSingleDateDelegate(ICalendarView calendarView)
    : IUICalendarSelectionSingleDateDelegate
    {
        public void DidSelectDate(UICalendarSelectionSingleDate calendarSelection, NSDateComponents? date)
        {
            calendarSelection.SelectedDate = date;
            calendarView.SelectedDate = date?.Date.ToDateTime();
            calendarView.OnSelectedDateChanged(date?.Date.ToDateTime());
        }

        public void Dispose()
        {
        }

        public NativeHandle Handle { get; }
    }

    public partial class CalendarHandler : ViewHandler<ICalendarView, UICalendarView>
    {
        private UICalendarSelection? calendarSelection;

        protected override UICalendarView CreatePlatformView()
        {
            return new UICalendarView();
        }

        protected override void ConnectHandler(UICalendarView platformView)
        {
            base.ConnectHandler(platformView);
            calendarSelection = new UICalendarSelectionSingleDate(new CalendarSelectionSingleDateDelegate(VirtualView));
            platformView.SelectionBehavior = calendarSelection;
        }

        static void MapFirstDayOfWeek(CalendarHandler handler, ICalendarView virtualView)
        {
            handler.PlatformView.Calendar.FirstWeekDay = (nuint)virtualView.FirstDayOfWeek;
        }

        static void MapMinDate(CalendarHandler handler, ICalendarView virtualView)
        {
            SetDateRange(handler, virtualView);
        }

        static void MapMaxDate(CalendarHandler handler, ICalendarView virtualView)
        {
            SetDateRange(handler, virtualView);
        }

        static void MapSelectedDate(CalendarHandler handler, ICalendarView virtualView)
        {
            if (handler.calendarSelection is UICalendarSelectionSingleDate calendarSelection)
            {
                MapSingleDateSelection(calendarSelection, virtualView);
            }
        }

        static void MapSingleDateSelection(UICalendarSelectionSingleDate calendarSelection, ICalendarView virtualView)
        {
            if (virtualView.SelectedDate is null)
            {
                calendarSelection.SetSelectedDate(null, true);
                return;
            }

            calendarSelection.SetSelectedDate(new NSDateComponents()
            {
                Day = virtualView.SelectedDate.Value.Day,
                Month = virtualView.SelectedDate.Value.Month,
                Year = virtualView.SelectedDate.Value.Year
            }, true);
        }

        private static void SetDateRange(CalendarHandler handler, ICalendarView virtualView)
        {
            var fromDateComponents = virtualView.MinDate.Date.ToNSDate();
            var toDateComponents = virtualView.MaxDate.Date.ToNSDate();

            var calendarViewDateRange = new NSDateInterval(fromDateComponents, toDateComponents);
            handler.PlatformView.AvailableDateRange = calendarViewDateRange;
        }
    }
}
