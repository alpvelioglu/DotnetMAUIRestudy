﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloMauiDefault.Views
{
    public class CalendarView : View, ICalendarView
    {
        public static readonly BindableProperty FirstDayOfWeekProperty = BindableProperty.Create(nameof(FirstDayOfWeek), typeof(DayOfWeek), typeof(CalendarView), default(DayOfWeek));
        public static readonly BindableProperty MinDateProperty = BindableProperty.Create(nameof(MinDate), typeof(DateTimeOffset), typeof(CalendarView), DateTimeOffset.MinValue);
        public static readonly BindableProperty MaxDateProperty = BindableProperty.Create(nameof(MaxDate), typeof(DateTimeOffset), typeof(CalendarView), DateTimeOffset.MaxValue);
        public static readonly BindableProperty SelectedDateProperty = BindableProperty.Create(nameof(SelectedDate), typeof(DateTimeOffset?), typeof(CalendarView));

        public event EventHandler<SelectedDateChangedEventArgs>? SelectedDateChanged;

        public DayOfWeek FirstDayOfWeek
        {
            get => (DayOfWeek)GetValue(FirstDayOfWeekProperty);
            set => SetValue(FirstDayOfWeekProperty, value);
        }

        public DateTimeOffset MinDate
        {
            get => (DateTimeOffset)GetValue(MinDateProperty);
            set => SetValue(MinDateProperty, value);
        }

        public DateTimeOffset MaxDate
        {
            get => (DateTimeOffset)GetValue(MaxDateProperty);
            set => SetValue(MaxDateProperty, value);
        }

        public DateTimeOffset? SelectedDate
        {
            get => (DateTimeOffset?)GetValue(SelectedDateProperty);
            set => SetValue(SelectedDateProperty, value);
        }

        void ICalendarView.OnSelectedDateChanged(DateTimeOffset? selectedDate)
        {
            SelectedDateChanged?.Invoke(this, new SelectedDateChangedEventArgs(selectedDate));
        }
    }

    public class SelectedDateChangedEventArgs(DateTimeOffset? selectedDate) : EventArgs
    {
        public DateTimeOffset? SelectedDate { get; } = selectedDate;
    }

    public class DateTimeOffsetStringConverter : TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            if (value is string valueString)
            {
                return DateTimeOffset.Parse(valueString);
            }

            return DateTimeOffset.MinValue;
        }
    }
}
