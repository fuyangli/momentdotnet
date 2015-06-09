using System;

namespace MomentCSharp
{
    public static class Intervals
    {

        public static String FromNow(this DateTime current)
        {
            return null;
        }

        public static double TotalMinutesFrom(this DateTime current, DateTime relative)
        {
            return (current - relative).TotalMinutes;
        }

        public static double TotalMinutesFromNow(this DateTime current)
        {
            return DateTime.Now.TotalMinutesFrom(current);
        }

        public static int MinutesFromNow2(this DateTime current)
        {

        }

    }
}
