using ShiftsLoggerAPI.Models;
using ShiftsLoggerUI.Models;
using Spectre.Console;

namespace ShiftsLoggerUI.Menus
{
    internal class Visualizations
    {
        //TODO what is wrong lol I am confusion
        internal static void ShowAllShiftsTable(List<Shift> shifts)
        {
            var table = new Table()
                .RoundedBorder()
                .BorderColor(Color.Blue)
                .Title("Sifts")
                .AddColumn("Shift ID")
                .AddColumn("Job Title")
                .AddColumn("Start Time")
                .AddColumn("End Time")
                .AddColumn("Hours Worked");
            
            foreach (var shift in shifts)
            {
                //TODO validate the below is working as expected. 
              table.AddRow(shift.id, shift.jobTitle, shift.start.ToString("yyyy-MM-dd HH:mm"), shift.end.ToString("yyyy-MM-dd HH:mm"), shift.HoursWorked.ToString("F2"));
            }

            AnsiConsole.Write(table);



        }
    }
}
