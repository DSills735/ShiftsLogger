using ShiftsLoggerUI.Services;
using ShiftsLoggerUI.Controllers;
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
                    "Update a shift - not implemented",
                    "Delete a shift - not implemented",
                    "Exit"
               }));

            switch(choice){
                case "Log a new shift":
                    ShiftController shiftController = new ShiftController();
                    shiftController.LogShift();
                    break;

                case "View all past shifts":
                    ShiftsService shiftsService = new ShiftsService();
                    //TODO i think this is broken because of discard operator??
                    _ = shiftsService.ShowAllShifts();
                    break;
                case "Update a shift":
                    
                    //ShiftController.UpdateShift();
                    break;
                case "Delete a shift":
                    
                    //shiftController.DeleteShift();
                    break;
                case "Exit":
                    AnsiConsole.MarkupLine("[slowblink][red] Exiting the application. Goodbye![/][/]");
                    Environment.Exit(0);
                    break;

            }

        }

        
    }
}
