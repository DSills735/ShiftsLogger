
using Spectre.Console;
using System.Globalization;

namespace ShiftsLoggerUI.Controllers
{
    internal class ShiftsController
    {

        internal void LogShift()
        {
            Console.Clear();

            string jobTitle = AnsiConsole.Ask<string>("Enter your job title.");
            string startTime;
            string endTime;
            bool valid = false;
            AnsiConsole.MarkupLine("Please enter the start time of your shift in the format: [underline][bold]yyyy-MM-dd HH:mm[/][/]");
                startTime = Console.ReadLine()!;

            //TODO need to check this validation.. I think its OK

            while (!DateTime.TryParseExact(startTime, "yyyy-MM-dd HH:mm",  CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
            {
                Console.WriteLine("Invalid input. Please enter a valid start time in the format: yyyy-MM-dd HH:mm");
                startTime = Console.ReadLine()!;
            }

            valid = false;
            AnsiConsole.MarkupLine("Please enter the end time of your shift in the format: [underline][bold]yyyy-MM-dd HH:mm[/][/]");
            endTime = Console.ReadLine()!;

            while (!DateTime.TryParseExact(endTime, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
            {
                Console.WriteLine("Invalid input. Please enter a valid end time in the format: yyyy-MM-dd HH:mm");
                startTime = Console.ReadLine()!;
            }

        }
    }
}
