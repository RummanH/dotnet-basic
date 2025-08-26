using Doctors.DTOs;
using Doctors.Services;
using Microsoft.AspNetCore.Mvc;

namespace Doctors.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class DoctorsController(DoctorService service) : ControllerBase
  {


    [HttpGet]
    public async Task<ActionResult<IEnumerable<DoctorResponseDto>>> GetAll()
    {
      var doctors = await service.GetAllAsync();
      return Ok(doctors);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DoctorResponseDto>> GetById(int id)
    {
      var doctor = await service.GetByIdAsync(id);
      if (doctor == null)
      {
        return NotFound(new { message = "Doctor not found" });
      }
      return Ok(doctor);
    }

    [HttpPost]
    public async Task<ActionResult<DoctorResponseDto>> Create([FromBody] CreateDoctorDto dto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var created = await service.AddAsync(dto);
      return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateDoctorDto dto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var success = await service.UpdateAsync(id, dto);
      if (!success)
      {
        return NotFound(new { message = "Doctor not found" });
      }
      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var success = await service.DeleteAsync(id);
      if (!success)
      {
        return NotFound(new { message = "Doctor not found" });
      }
      return NoContent();
    }
  }
}
