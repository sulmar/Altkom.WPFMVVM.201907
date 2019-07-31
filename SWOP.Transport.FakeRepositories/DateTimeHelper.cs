using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SWOP.Transport.FakeRepositories
{
    internal static class DateTimeHelper
    {
        public static bool IsHoliday(DateTime dateTime)
        {
            return 
                dateTime.DayOfWeek == DayOfWeek.Saturday ||
                dateTime.DayOfWeek == DayOfWeek.Sunday;
                
        }
    }

    internal static class DateTimeExtensions
    {
        public static bool IsHoliday(this DateTime dateTime, int days = 7)
        {
            return
                dateTime.DayOfWeek == DayOfWeek.Saturday ||
                dateTime.DayOfWeek == DayOfWeek.Sunday;

        }
    }

    internal static class StringExtensions
    {
        public static bool ContainsInvariant(this string current, string value)
        {
            return current.ToLower().Contains(value.ToLower());
        }
    }

   //public static class ICommandExtensions
   // {
   //     public static void OnCanExecuteChanged(this ICommand command)
   //     {
   //         command.CanExecuteChanged?.Invoke(command, EventArgs.Empty);
   //     }
   // }
}
