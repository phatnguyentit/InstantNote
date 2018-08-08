using System;

namespace InstantNote
{
    public class Helper
    {
        public static string GetTodayFileName()
        {
            return $"{DateTime.Now.ToString(Constants.DateFormat)}.json";
        }
    }
}