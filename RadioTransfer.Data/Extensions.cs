using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace Thornton.Data
//{
public static class Extensions
{
    public static DateTime Next(this DateTime from, DayOfWeek dayOfWeek)
    {
        int start = (int)from.DayOfWeek;
        int target = (int)dayOfWeek;
        if (target <= start)
            target += 7;
        return from.AddDays(target - start);
    }

    public static DateTime Previous(this DateTime fromDate, DayOfWeek findDay,
        bool skipSame = false)
    {
        if (fromDate.DayOfWeek < findDay)
            fromDate = fromDate.AddDays(-((int)fromDate.DayOfWeek - 1 + (int)findDay));
        else if (fromDate.DayOfWeek > findDay)
            fromDate = fromDate.AddDays(-((int)fromDate.DayOfWeek - (int)findDay));
        else if (fromDate.DayOfWeek == findDay && skipSame == true)
            fromDate = fromDate.AddDays(-7);

        return fromDate;
    }
}
//}
