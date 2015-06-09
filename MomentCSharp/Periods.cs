using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomentCSharp
{
    public static class Periods
    {
        public static DateTime StartTimeOfDay(this DateTime current)
        {
            return new DateTime(current.Year, current.Month, current.Day, 0, 0, 0);
        }

        public static DateTime EndTimeOfDay(this DateTime current)
        {
            return new DateTime(current.Year, current.Month, current.Day, 23, 59, 59);
        }

        public static DateTime FirstTimeOfMonth(this DateTime current)
        {
            return current.AddDays(1 - current.Day).StartTimeOfDay();
        }

        public static DateTime LastTimeOfMonth(this DateTime current)
        {
            return new DateTime(current.Year, current.Month, DateTime.DaysInMonth(current.Year, current.Month)).EndTimeOfDay();
        }

        public static DateTime FirstTimeOfYear(this DateTime current)
        {
            return new DateTime(current.Year, 1, 1);
        }

        public static DateTime LastTimeOfYear(this DateTime current)
        {
            return new DateTime(current.Year, 12, 31).EndTimeOfDay();
        }

        public static DateTime FirstTimeOfWeek(this DateTime current)
        {
            var defaultCultureInfo = CultureInfo.CurrentCulture;
            var firstDay = defaultCultureInfo.DateTimeFormat.FirstDayOfWeek;
            var firstDayInWeek = current.Date;
            while (firstDayInWeek.DayOfWeek != firstDay)
                firstDayInWeek = firstDayInWeek.AddDays(-1);
            return firstDayInWeek.StartTimeOfDay();
        }
        public static DateTime LastTimeOfWeek(this DateTime current)
        {
            var defaultCultureInfo = CultureInfo.CurrentCulture;
            var firstDay = defaultCultureInfo.DateTimeFormat.FirstDayOfWeek;
            var lastDayInweek = current.Date;
            while (lastDayInweek.DayOfWeek != firstDay)
                lastDayInweek = lastDayInweek.AddDays(1);
            return lastDayInweek.StartTimeOfDay();
        }

        public static DateTime FirstTimeOfQuinzena(this DateTime current)
        {
            var date = current.FirstTimeOfMonth();
            if (current.Day > 15)
            {
                date = date.AddDays(14);
            }
            return date;
        }

        public static DateTime LastTimeOfQuinzena(this DateTime current)
        {
            current = current.Day > 15 ? current.LastTimeOfMonth() : current.FirstTimeOfMonth().AddDays(15);
            return current;
        }

        public static DateTime FirstTimeOfBimester(this DateTime current)
        {
            int bimester = (int)Math.Ceiling(current.Month / 2f);
            return new DateTime(current.Year, (2 * bimester) - 1, 1);
        }

        public static DateTime LastTimeOfBimester(this DateTime current)
        {
            var bimester = (int)Math.Ceiling(current.Month / 2f);
            return new DateTime(current.Year, bimester * 2, 1).LastTimeOfMonth();
        }

        public static DateTime FirstTimeOfTrimester(this DateTime current)
        {
            var trimester = (int)Math.Ceiling(current.Month / 3f);
            return new DateTime(current.Year, (3 * trimester) - 2, 1);
        }

        public static DateTime LastTimeOfTrimester(this DateTime current)
        {
            var trimester = (int)Math.Ceiling(current.Month / 3f);
            return new DateTime(current.Year, 3 * trimester, 1).LastTimeOfMonth();
        }

        public static DateTime FirstTimeOfQuadrimester(this DateTime current)
        {
            var quadrimester = (int)Math.Ceiling(current.Month / 4f);
            return new DateTime(current.Year, (4 * quadrimester) - 3, 1);
        }

        public static DateTime LastTimeOfQuadrimester(this DateTime current)
        {
            var quadrimester = (int)Math.Ceiling(current.Month / 4f);
            return new DateTime(current.Year, 4 * quadrimester, 1).LastTimeOfMonth();
        }

        public static DateTime FirstTimeOfSemester(this DateTime current)
        {
            var quadrimester = (int)Math.Ceiling(current.Month / 6f);
            return new DateTime(current.Year, (6 * quadrimester) - 5, 1);
        }

        public static DateTime LastTimeOfSemester(this DateTime current)
        {
            var quadrimester = (int)Math.Ceiling(current.Month / 6f);
            return new DateTime(current.Year, 6 * quadrimester, 1).LastTimeOfMonth();
        }
    }
}
