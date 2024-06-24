namespace Store.Business.Common.Helpers;

public class DateHelper {

    public static DateTime GetLastDayofMonth(DateTime dateOriginal) {
        var lastDayOfMonth = DateTime.DaysInMonth(dateOriginal.Year, dateOriginal.Month);

        DateTime returnDate = new DateTime(dateOriginal.Year, dateOriginal.Month, lastDayOfMonth);
        returnDate = returnDate.AddHours(23).AddMinutes(59).AddSeconds(59);

        return returnDate;
    }

    public static DateTime GetFirstDayofMonth(DateTime day)  {
        day = day.Date;

        var sd = new DateTime(day.Year, day.Month, 1);
        DateTime returnDate = sd;

        return returnDate;
    }

    public static DateTime GetDateTimeNow(string timeZone) {
        DateTime utcDateTime    = DateTime.UtcNow;
        TimeZoneInfo nzTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZone);

        return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, nzTimeZone);
    }

    public static string GetMonthName(int numMonth) {
        string[] months = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"};
        return months[numMonth - 1];
    }
}