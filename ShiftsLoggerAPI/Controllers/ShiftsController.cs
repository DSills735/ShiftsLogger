using Microsoft.AspNetCore.Mvc;
using ShiftsLoggerAPI.Services;
using ShiftsLoggerAPI.Models;
// Postman URLs
// GET    https://localhost:7064/api/shifts
// GET    https://localhost:7064/api/shifts/{id}
// POST   https://localhost:7064/api/shifts
// PUT    https://localhost:7064/api/shifts/{id}
// DELETE https://localhost:7064/api/shifts/{id}

[ApiController]
[Route("api/[controller]")]
public class ShiftsController(IShiftsService shiftService) : ControllerBase
{
    private readonly IShiftsService _shiftService = shiftService;

    [HttpGet]
    public ActionResult<List<Shift>> GetAllShifts()
    {
        return Ok(_shiftService.GetAllShifts());
    }

    [HttpGet("{id}")]
    public ActionResult<Shift> GetShiftById(int id)
    {
        var result = _shiftService.GetShiftByID(id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPost]
    public ActionResult<Shift> CreateShift(Shift shift)
    {
        var result = _shiftService.CreateShift(shift);
        if (result == null)
        {
            return BadRequest();
        }
        return Ok(result);
    }

    [HttpPut("{id}")]
    public ActionResult<Shift> UpdateShift(int id, Shift shiftNew)
    {
        var result = _shiftService.UpdateShift(id, shiftNew);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteShift(int id)
    {
        var result = _shiftService.DeleteShift(id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }


}

/* DELETE WHEN DONE DEBUGGING JSON INPUTS FOR POSTMAN
  {
  "start": "2023-10-30T22:00:00",
  "end": "2023-10-31T06:00:00",
  "jobTitle": "System Administrator"
}

{
  "start": "2023-10-30T07:00:00",
  "end": "2023-11-31T07:00:00",
  "jobTitle": "Firefighter"
}

{  "start": "2023-10-30T06:00:00",
  "end": "2023-10-31T15:00:00",
  "jobTitle": "Software Developer"
}
*/



