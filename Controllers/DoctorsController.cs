using Microsoft.AspNetCore.Mvc;
using Doctors.Models;
using Doctors.Repositories;

namespace Doctors.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class DoctorsController : ControllerBase
  {
    [HttpGet]
    public ActionResult<IEnumerable<Doctor>> GetAll()
    {
      return Ok(DoctorRepository.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Doctor> GetById(int id)
    {
      var doctor = DoctorRepository.GetById(id);
      if (doctor == null)
        return NotFound();
      return Ok(doctor);
    }

    [HttpPost]
    public ActionResult<Doctor> Create(Doctor doctor)
    {
      var created = DoctorRepository.Add(doctor);
      return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Doctor updated)
    {
      var success = DoctorRepository.Update(id, updated);
      if (!success) return NotFound();
      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var success = DoctorRepository.Delete(id);
      if (!success) return NotFound();
      return NoContent();
    }
  }
}
