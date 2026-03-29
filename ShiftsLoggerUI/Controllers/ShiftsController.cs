
using Spectre.Console;

namespace ShiftsLoggerUI.Controllers
{
    internal class ShiftsController
    {

        internal void LogShift()
        {
            Console.Clear();

            string jobTitle = AnsiConsole.Ask<string>("Enter your job title.");
            bool validInput = false;
            DateTime startTime;
            DateTime endTime;

            while(!validInput)
            {
                AnsiConsole.MarkupLine("Please enter the start time of your shift in the format: [underline][bold]yyyy-MM-dd HH:mm[/][/]");
                startTime = Console.ReadLine();
                validInput = Validation.ShiftInputValidation.ValidateShiftInput();
            }
            


            
        }
    }
}
