using Microsoft.AspNetCore.Mvc;
using ShiftsLoggerAPI.Services;
using ShiftsLoggerAPI.Models;

[ApiController]
[Route("api/[controller]")]

public class ShiftsCntroller(IShiftsService shiftService) : ControllerBase
{
    private readonly IShiftsService _shiftService = shiftService;

    [HttpGet]
    public ActionResult<List<Shift>> GetAllShifts(int id)
    {
        var result = _shiftService.GetShiftByID(id);

        if(result == null)
        {
            return NotFound();
        }
        return Ok(_shiftService.GetAllShifts());
    }

    [HttpGet("{id}")]
    public ActionResult<Shift> GetShiftByID(int id)
    {
        var result = _shiftService.GetShiftByID(id);
        if(result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPost]
    public ActionResult<Shift> CreateShift(Shift shift)
    {
        var result = _shiftService.CreateShift(shift);
        if(result == null)
        {
            return BadRequest();
        }
        return Ok(result);
    }
    [HttpPut("{id}")]
    public ActionResult<Shift> UpdateShift(int id, Shift shiftNew)
    {
        var result = _shiftService.UpdateShift(id, shiftNew);
        if(result == null)
        {
            return NotFound();
        }
        return Ok(_shiftService.UpdateShift(id, shiftNew));
    }
    [HttpDelete("{id}")]
    public ActionResult DeleteShift(int id)
    {
        var result = _shiftService.DeleteShift(id);
        if(result == null)
        {
            return NotFound();
        }
        return Ok(_shiftService.DeleteShift(id));
    }
}

