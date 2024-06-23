using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Globalization;

/// <summary>
/// Summary description for JaguClass
/// </summary>
public class JaguClass
{
	public JaguClass()
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

    // Date Format
    public static DateTimeFormatInfo dateformat103()
    {
        System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
        dateInfo.ShortDatePattern = "dd/MM/yyyy";
        return dateInfo;
    }
    public static DateTimeFormatInfo dateformat111()
    {
        System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
        dateInfo.ShortDatePattern = "yyyy-MM-dd";
        return dateInfo;
    }

    // RANDOM PASSWORD
    private static Random _random = new Random(Environment.TickCount);
    public static string RandomPassword(int length)
    {
        string chars = "$&0123456789abcdefghijklmnopqrstuvwxyz@#";
        StringBuilder builder = new StringBuilder(length);

        for (int i = 0; i < length; ++i)
            builder.Append(chars[_random.Next(chars.Length)]);

        return builder.ToString();
    }

    // RANDOM NUMBER
    public static Random random = new Random();
    public static string GenerateRandomNumber(int length)
    {
        string s = "";
        for (int i = 0; i < length; i++)
            s = String.Concat(s, random.Next(10).ToString());
        return s;
    }

    // Age Calculation In Year Month Days
    public static string LoopAge(DateTime myDOB, DateTime FutureDate)
    {
        int years = 0;
        int months = 0;
        int days = 0;

        string Age;

        DateTime tmpMyDOB = new DateTime(myDOB.Year, myDOB.Month, 1);

        DateTime tmpFutureDate = new DateTime(FutureDate.Year, FutureDate.Month, 1);

        while (tmpMyDOB.AddYears(years).AddMonths(months) < tmpFutureDate)
        {
            months++;
            if (months > 12)
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

        Age = years + "," + months + "," + days;
        return Age;

    }

    public static string NumberToWords(int number)
    {
        if (number == 0)
            return "Zero";

        if (number < 0)
            return "Minus " + NumberToWords(Math.Abs(number));

        string words = "";

        if ((number / 1000000) > 0)
        {
            words += NumberToWords(number / 1000000) + " Million ";
            number %= 1000000;
        }

        if ((number / 1000) > 0)
        {
            words += NumberToWords(number / 1000) + " Thousand ";
            number %= 1000;
        }

        if ((number / 100) > 0)
        {
            words += NumberToWords(number / 100) + " Hundred ";
            number %= 100;
        }

        if (number > 0)
        {
            if (words != "")
                words += "And ";

            var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

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
    //ReadOnly ALL TextBox
    public static void SetTextBoxReadOnly<T>(Control parent, bool readOnly) where T : TextBox
    {
        // Get all TextBoxes and set the value of the ReadOnly property.
        foreach (var tb in parent.Controls.OfType<T>())
            tb.ReadOnly = readOnly;

        // Recurse through all Controls
        foreach (Control c in parent.Controls)
            SetTextBoxReadOnly<T>(c, readOnly);
    }
    public static void setdropdownlistreadonly<T>(Control parent, bool readOnly) where T : DropDownList
    {
        // Get all TextBoxes and set the value of the ReadOnly property.
        foreach (var tb in parent.Controls.OfType<T>())
            tb.Enabled = false;

        // Recurse through all Controls
        foreach (Control c in parent.Controls)
            setdropdownlistreadonly<T>(c, readOnly);
    }
}