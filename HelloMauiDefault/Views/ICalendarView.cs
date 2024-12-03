using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloMauiDefault.Views
{
    public interface ICalendarView : IView
    {
        DayOfWeek FirstDayOfWeek { get; }
        DateTimeOffset MinDate { get; }
        DateTimeOffset MaxDate { get; }
        DateTimeOffset? SelectedDate { get; set; }
        void OnSelectedDateChanged(DateTimeOffset? selectedDate);
    }
}
