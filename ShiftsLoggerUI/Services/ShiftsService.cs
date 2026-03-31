using Newtonsoft.Json;
using ShiftsLoggerUI.Models;
namespace ShiftsLoggerUI.Services
{
    internal class ShiftsService
    {
        //conn link http://localhost:7064/api/shifts
        //todo need to come back and further test this once the log area is done

        private static readonly HttpClient client = new HttpClient();
        public async Task ShowAllShifts()
        {

            client.BaseAddress = new Uri("http://localhost:7064/");
            try
            {
                string shifts = await client.GetStringAsync("api/shifts");

                if (shifts == null)
                {
                    Console.WriteLine("No shifts found.");
                    return;
                }
                var serializedShifts = JsonConvert.DeserializeObject<Shifts>(shifts);

                if (serializedShifts != null)
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

        public async Task LogShift(Shift shift)
        {
            client.BaseAddress = new Uri("http://localhost:7064/");
            try
            {
                var jsonContent = JsonConvert.SerializeObject(shift);
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync("api/shifts", content);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Shift logged successfully.");
                }
                else
                {
                    Console.WriteLine($"Failed to log shift. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }
    }
}