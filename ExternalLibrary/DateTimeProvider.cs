using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalLibrary
{
    public class DateTimeProvider
    {
        public string GetCurrentDayOfWeek()
        {
            DateTime today = DateTime.Today;
            return today.DayOfWeek.ToString();
        }

        public string GetDayOfWeek(int year, int month, int day)
        {
            bool x = true;
            DateTime date = new DateTime(year, month, day);
            return date.DayOfWeek.ToString();
        }
    }
}
