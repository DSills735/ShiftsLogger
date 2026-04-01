using ShiftsLoggerUI.Models;
using ShiftsLoggerUI.Services;
using Spectre.Console;
using System.Globalization;

namespace ShiftsLoggerUI.Controllers
{
    internal class ShiftController
    {

        internal async Task LogShift()
        {
            Console.Clear();

            string jobTitle = AnsiConsole.Ask<string>("Enter your job title.");
            string startTime;
            string endTime;
            
            AnsiConsole.MarkupLine("Please enter the start time of your shift in the format: [underline][bold]yyyy-MM-dd HH:mm[/][/]");
                startTime = Console.ReadLine()!;


            while (!DateTime.TryParseExact(startTime, "yyyy-MM-dd HH:mm",  CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
            {
                Console.WriteLine("Invalid input. Please enter a valid start time in the format: yyyy-MM-dd HH:mm");
                startTime = Console.ReadLine()!;
            }

            
            AnsiConsole.MarkupLine("Please enter the end time of your shift in the format: [underline][bold]yyyy-MM-dd HH:mm[/][/]");
            endTime = Console.ReadLine()!;

            while (!DateTime.TryParseExact(endTime, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
            {
                Console.WriteLine("Invalid input. Please enter a valid end time in the format: yyyy-MM-dd HH:mm");
                startTime = Console.ReadLine()!;
            }

            Shift shift = new Shift
            {
                JobTitle = jobTitle,
                start = DateTime.ParseExact(startTime, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                end = DateTime.ParseExact(endTime, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture)
            };
            ShiftsService shiftsService = new ShiftsService();

            await shiftsService.LogShift(shift);
        }

        internal async Task UpdateShift()
        {
            Console.WriteLine("What shift do you want to update?\n");

            var shiftsService = new ShiftsService();
                await shiftsService.ShowAllShifts();
    
                int shiftId = AnsiConsole.Ask<int>("Enter the [underline][bold]Shift ID[/][/] of the shift you want to update.");
    
                Console.WriteLine($"You want to update shift with ID: {shiftId}");

            var choice = AnsiConsole.Prompt(
               new SelectionPrompt<string>()
               .Title("What metric do you want to update")
               .AddChoices(new[]
               {
                    "Title",
                    "Start time",
                    "End time"
               }));


        }
    }
}
