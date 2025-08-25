using Microsoft.AspNetCore.Mvc;
using Doctors.Models;
using Doctors.Services;

namespace Doctors.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class DoctorsController(DoctorService service) : ControllerBase
  {
    private readonly DoctorService _service = service;

    [HttpGet]
    public ActionResult<IEnumerable<Doctor>> GetAll() => Ok(_service.GetAll());

    [HttpGet("{id}")]
    public ActionResult<Doctor> GetById(int id)
    {
      var doctor = _service.GetById(id);
      if (doctor == null) return NotFound();
      return Ok(doctor);
    }

    [HttpPost]
    public ActionResult<Doctor> Create([FromBody] Doctor doctor)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var created = _service.Add(doctor);
      return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Doctor doctor)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var success = _service.Update(id, doctor);
      if (!success) return NotFound();
      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var success = _service.Delete(id);
      if (!success) return NotFound();
      return NoContent();
    }
  }
}
