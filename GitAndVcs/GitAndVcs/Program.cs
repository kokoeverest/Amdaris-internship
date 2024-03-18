using System.Text;

StringBuilder builder = new("", 200);

builder.AppendFormat("{0, -20} - {1, 15:C}", DateTime.Now.DayOfYear, 2000);

Console.WriteLine(builder);

DateTime dateTime = new(year: 2022, month: 3, day: 20);
TimeSpan duration = new(days: 36, 0,0,0);
Console.WriteLine(dateTime);
Console.WriteLine(dateTime.Add(duration));