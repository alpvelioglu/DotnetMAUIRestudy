﻿using HelloMauiDefault.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloMauiDefault.Handlers
{
    public partial class CalendarHandler
    {
        public CalendarHandler(IPropertyMapper mapper, CommandMapper? commandMapper = null) : base(mapper, commandMapper)
        {
        }

        public CalendarHandler() : this(PropertyMapper, CommandMapper)
        {
        }

        public static IPropertyMapper<ICalendarView, CalendarHandler> PropertyMapper = new PropertyMapper<ICalendarView, CalendarHandler>(ViewMapper)
        {
            [nameof(ICalendarView.FirstDayOfWeek)] = MapFirstDayOfWeek,
            [nameof(ICalendarView.MinDate)] = MapMinDate,
            [nameof(ICalendarView.MaxDate)] = MapMaxDate,
            [nameof(ICalendarView.SelectedDate)] = MapSelectedDate,
        };

        public static CommandMapper<ICalendarView, CalendarHandler> CommandMapper = new(ViewCommandMapper);
    }
}
