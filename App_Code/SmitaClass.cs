using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
/// <summary>
/// Summary description for SmitaClass
/// </summary>
public class SmitaClass
{
	public SmitaClass()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    // DECIMAL ROUND OFF
    public static double SignificantTruncate(decimal num, int significantDigits)
    {
        double number = Convert.ToDouble(num);
        double y = Math.Pow(10, significantDigits);
        return Math.Truncate(number * y) / y;
    }


    // INDIAN TIME
    public static DateTime IndianTime()
    {
        DateTime dtUTC = DateTime.UtcNow;
        TimeZoneInfo indianZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"); // say          
        DateTime systemDate = TimeZoneInfo.ConvertTimeFromUtc(dtUTC, indianZone);

        return systemDate;
    }
    public static DateTimeFormatInfo dateformat()
    {
        System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
        dateInfo.ShortDatePattern = "dd/MM/yyyy";
        return dateInfo;
    }
    public static DateTimeFormatInfo dateformat1()
    {
        System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
        dateInfo.ShortDatePattern = "yyyy-MM-dd";
        return dateInfo;
    }
     public static DateTimeFormatInfo YMDHMS()
    {
        System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
        dateInfo.ShortDatePattern = "yyyy-MM-dd HH:mm:ss";
        return dateInfo;
    }
   
    // Date calculation
    public static string LoopYear(DateTime myDOB, DateTime FutureDate)
    {
        int years = 0;
        int months = 0;
        int days = 0;

        string Year;

        DateTime tmpMyDOB = new DateTime(myDOB.Year, myDOB.Month, 1);

        DateTime tmpFutureDate = new DateTime(FutureDate.Year, FutureDate.Month, 1);

        while (tmpMyDOB.AddYears(years).AddMonths(months) < tmpFutureDate)
        {
            months++;
            if (months >= 12)
            {
                years++;
                months = months - 12;
            }
        }

        if (FutureDate.Day >= myDOB.Day)
        {
            days = days + FutureDate.Day - myDOB.Day;
        }
        else
        {
            months--;
            if (months < 0)
            {
                years--;
                months = months + 12;
            }
            days +=
                DateTime.DaysInMonth(
                    FutureDate.AddMonths(-1).Year, FutureDate.AddMonths(-1).Month
                ) + FutureDate.Day - myDOB.Day;

        }

        //add an extra day if the dob is a leap day
        if (DateTime.IsLeapYear(myDOB.Year) && myDOB.Month == 2 && myDOB.Day == 29)
        {
            //but only if the future date is less than 1st March
            if (FutureDate >= new DateTime(FutureDate.Year, 3, 1))
                days++;
        }

        //Age = years + " Years, " + months + " Months, " + days+" Days ";
        //return Age;
        Year=years.ToString();
        return Year;

    }

    public static string LoopMonth(DateTime myDOB, DateTime FutureDate)
    {
        int years = 0;
        int months = 0;
        int days = 0;

        string Month;

        DateTime tmpMyDOB = new DateTime(myDOB.Year, myDOB.Month, 1);

        DateTime tmpFutureDate = new DateTime(FutureDate.Year, FutureDate.Month, 1);

        while (tmpMyDOB.AddYears(years).AddMonths(months) < tmpFutureDate)
        {
            months++;
            if (months >= 12)
            {
                years++;
                months = months - 12;
            }
        }

        if (FutureDate.Day >= myDOB.Day)
        {
            days = days + FutureDate.Day - myDOB.Day;
        }
        else
        {
            months--;
            if (months < 0)
            {
                years--;
                months = months + 12;
            }
            days +=
                DateTime.DaysInMonth(
                    FutureDate.AddMonths(-1).Year, FutureDate.AddMonths(-1).Month
                ) + FutureDate.Day - myDOB.Day;

        }

        //add an extra day if the dob is a leap day
        if (DateTime.IsLeapYear(myDOB.Year) && myDOB.Month == 2 && myDOB.Day == 29)
        {
            //but only if the future date is less than 1st March
            if (FutureDate >= new DateTime(FutureDate.Year, 3, 1))
                days++;
        }

        Month = months.ToString();
        return Month;

    }
    public static string LoopDays(DateTime myDOB, DateTime FutureDate)
    {
        int years = 0;
        int months = 0;
        int days = 0;

        string Days;

        DateTime tmpMyDOB = new DateTime(myDOB.Year, myDOB.Month, 1);

        DateTime tmpFutureDate = new DateTime(FutureDate.Year, FutureDate.Month, 1);

        while (tmpMyDOB.AddYears(years).AddMonths(months) < tmpFutureDate)
        {
            months++;
            if (months >= 12)
            {
                years++;
                months = months - 12;
            }
        }

        if (FutureDate.Day >= myDOB.Day)
        {
            days = days + FutureDate.Day - myDOB.Day;
        }
        else
        {
            months--;
            if (months < 0)
            {
                years--;
                months = months + 12;
            }
            days +=
                DateTime.DaysInMonth(
                    FutureDate.AddMonths(-1).Year, FutureDate.AddMonths(-1).Month
                ) + FutureDate.Day - myDOB.Day;

        }

        //add an extra day if the dob is a leap day
        if (DateTime.IsLeapYear(myDOB.Year) && myDOB.Month == 2 && myDOB.Day == 29)
        {
            //but only if the future date is less than 1st March
            if (FutureDate >= new DateTime(FutureDate.Year, 3, 1))
                days++;
        }

        Days = days.ToString();
        return Days;

    }

    public static string LoopTotDays(DateTime myDOB, DateTime FutureDate)
    {
        int years = 0;
        int months = 0;
        int days = 0;

        string Days;

        DateTime tmpMyDOB = new DateTime(myDOB.Year, myDOB.Month, 1);

        DateTime tmpFutureDate = new DateTime(FutureDate.Year, FutureDate.Month, 1);

        while (tmpMyDOB.AddYears(years).AddMonths(months) < tmpFutureDate)
        {
            months++;
            if (months >= 12)
            {
                years++;
                months = months - 12;
            }
        }

        if (FutureDate.Day >= myDOB.Day)
        {
            days = days + FutureDate.Day - myDOB.Day;
        }
        else
        {
            months--;
            if (months < 0)
            {
                years--;
                months = months + 12;
            }
            days +=
                DateTime.DaysInMonth(
                    FutureDate.AddMonths(-1).Year, FutureDate.AddMonths(-1).Month
                ) + FutureDate.Day - myDOB.Day;

        }

        //add an extra day if the dob is a leap day
        if (DateTime.IsLeapYear(myDOB.Year) && myDOB.Month == 2 && myDOB.Day == 29)
        {
            //but only if the future date is less than 1st March
            if (FutureDate >= new DateTime(FutureDate.Year, 3, 1))
                days++;
        }

        Days = Convert.ToString((months * 30) + days);
        return Days;

    }
    public static string NumberToWords(int number)
    {
        if (number == 0)
            return "zero";

        if (number < 0)
            return "minus " + NumberToWords(Math.Abs(number));

        string words = "";

        if ((number / 1000000) > 0)
        {
            words += NumberToWords(number / 1000000) + " million ";
            number %= 1000000;
        }
        if ((number / 100000) > 0)
        {
            words += NumberToWords(number / 100000) + " Lakh ";
            number %= 100000;
        }

        if ((number / 1000) > 0)
        {
            words += NumberToWords(number / 1000) + " thousand ";
            number %= 1000;
        }

        if ((number / 100) > 0)
        {
            words += NumberToWords(number / 100) + " hundred ";
            number %= 100;
        }

        if (number > 0)
        {
            if (words != "")
                words += "and ";

            var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

            if (number < 20)
                words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                    words += "-" + unitsMap[number % 10];
            }
        }

        return words;
    }
}