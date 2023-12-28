/*DateTime dateTime = DateTime.Now;

Console.WriteLine(dateTime.ToUniversalTime());*/

/*DateTime birthDay = new DateTime(2003, 2, 20, 0, 0, 0);

Console.WriteLine((DateTime.Now - birthDay).Days / 365);*/

/*DateTime dateTime = DateTime.Parse("20 Feb, 2003");

Console.WriteLine(dateTime.Year);
Console.WriteLine(dateTime.Month);
Console.WriteLine(dateTime.Day);
Console.WriteLine(dateTime.DayOfYear);
Console.WriteLine(dateTime.DayOfWeek);*/

/*Console.WriteLine(DateTime.SpecifyKind(dateTime, DateTimeKind.Local));*/


/*Console.WriteLine(DateTime.Now.ToString("yyyy,MM-dd"));*/


//culture
/*var culture = Thread.CurrentThread.CurrentCulture;

Console.WriteLine(culture);*/



using System.Globalization;

var cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);

foreach (var c in cultures)
    Console.WriteLine(c);

foreach (var c in cultures)
    Console.WriteLine(c.DisplayName);