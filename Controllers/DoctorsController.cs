using Doctors.DTOs;
using Doctors.Services;
using Microsoft.AspNetCore.Mvc;

namespace Doctors.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class DoctorsController(DoctorService service, ILogger<DoctorsController> logger) : ControllerBase
  {
    private readonly ILogger<DoctorsController> _logger = logger;

    [HttpGet]
    public ActionResult<IEnumerable<DoctorResponseDto>> GetAll()
    {
      _logger.LogInformation("Fetching all doctors");
      return Ok(service.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<DoctorResponseDto> GetById(int id)
    {
      var doctor = service.GetById(id);
      if (doctor == null)
      {
        _logger.LogWarning("Doctor with id {Id} not found", id);
        return NotFound(new { message = "Doctor not found" });
      }
      return Ok(doctor);
    }

    [HttpPost]
    public ActionResult<DoctorResponseDto> Create([FromBody] CreateDoctorDto dto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var created = service.Add(dto);
      _logger.LogInformation("Created doctor with id {Id}", created.Id);
      return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] UpdateDoctorDto dto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var success = service.Update(id, dto);
      if (!success)
      {
        _logger.LogWarning("Failed to update doctor with id {Id}", id);
        return NotFound(new { message = "Doctor not found" });
      }
      _logger.LogInformation("Updated doctor with id {Id}", id);
      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var success = service.Delete(id);
      if (!success)
      {
        _logger.LogWarning("Failed to delete doctor with id {Id}", id);
        return NotFound(new { message = "Doctor not found" });
      }
      _logger.LogInformation("Deleted doctor with id {Id}", id);
      return NoContent();
    }
  }
}
