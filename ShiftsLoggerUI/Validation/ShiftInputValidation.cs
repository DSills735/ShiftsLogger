
namespace ShiftsLoggerUI.Validation
{
    internal class ShiftInputValidation
    {
        internal static bool ValidateShiftInput(string input)
        {
            if (DateTime.TryParseExact(input, "yyyy-MM-dd HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime result))
            {
                return true;
                
            }
            else
            {
                return false;
            }
        }
    }
}
