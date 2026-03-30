using ShiftsLoggerUI.Services;
using Spectre.Console;

namespace ShiftsLoggerUI.Menus
{
    internal class UserInterface
    {
        internal static void MainMenu()
        {
            Console.Clear();
            AnsiConsole.MarkupLine("[slowblink][red] Welcome to the shift logging main menu[/][/]");

            Console.WriteLine();

            var choice = AnsiConsole.Prompt(
               new SelectionPrompt<string>()
               .Title("Please select an option:")
               .AddChoices(new[]
               {
                    "Log a new shift",
                    "View all past shifts",
                    "Update a shift",
                    "Delete a shift",
                    "Exit"
               }));

            switch(choice){
                case "Log a new shift":
                   ShiftsController.LogShift();
                    break;
                case "View all past shifts":
                    ShiftsService shiftsService = new ShiftsService();
                    _ = shiftsService.ShowAllShifts();
                    break;
                case "Update a shift":
                    ShiftsController.UpdateShift();
                    break;
                case "Delete a shift":
                    ShiftsController.DeleteShift();
                    break;
                case "Exit":
                    AnsiConsole.MarkupLine("[slowblink][red] Exiting the application. Goodbye![/][/]");
                    Environment.Exit(0);
                    break;

            }

        }

        
    }
}
