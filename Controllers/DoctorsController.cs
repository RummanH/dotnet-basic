using Doctors.DTOs;
using Doctors.Services;
using Microsoft.AspNetCore.Mvc;

namespace Doctors.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class DoctorsController : ControllerBase
  {
    private readonly DoctorService _service;
    private readonly ILogger<DoctorsController> _logger;

    // ✅ Correct constructor
    public DoctorsController(DoctorService service, ILogger<DoctorsController> logger)
    {
      _service = service;
      _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DoctorResponseDto>>> GetAll()
    {
      _logger.LogInformation("Fetching all doctors");
      var doctors = await _service.GetAllAsync();
      return Ok(doctors);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DoctorResponseDto>> GetById(int id)
    {
      var doctor = await _service.GetByIdAsync(id);
      if (doctor == null)
      {
        _logger.LogWarning("Doctor with id {Id} not found", id);
        return NotFound(new { message = "Doctor not found" });
      }
      return Ok(doctor);
    }

    [HttpPost]
    public async Task<ActionResult<DoctorResponseDto>> Create([FromBody] CreateDoctorDto dto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var created = await _service.AddAsync(dto);
      _logger.LogInformation("Created doctor with id {Id}", created.Id);
      return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateDoctorDto dto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var success = await _service.UpdateAsync(id, dto);
      if (!success)
      {
        _logger.LogWarning("Failed to update doctor with id {Id}", id);
        return NotFound(new { message = "Doctor not found" });
      }
      _logger.LogInformation("Updated doctor with id {Id}", id);
      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var success = await _service.DeleteAsync(id);
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
