using Newtonsoft.Json;
using ShiftsLoggerUI.Models;
using System.Net.Http.Json;
namespace ShiftsLoggerUI.Services
{
    internal class ShiftsService
    {
        //conn link http://localhost:7064/api/shifts

        private static readonly HttpClient client = new HttpClient();
        public async Task ShowAllShifts()
        {
          
            client.BaseAddress = new Uri("http://localhost:7064/");
            try
            {
                string shifts = await client.GetStringAsync("api/shifts");
               
                if(shifts == null)
                {
                    Console.WriteLine("No shifts found.");
                    return;
                }
                var serializedShifts = JsonConvert.DeserializeObject<Shifts>(shifts);

                if(serializedShifts != null)
                {
                    List<Shift>? deserializedShift = serializedShifts.ShiftList;

                    Menus.Visualizations.ShowAllShiftsTable(deserializedShift);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

    }
}
