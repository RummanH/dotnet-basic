using System.ComponentModel.DataAnnotations;

namespace Doctors.DTOs
{
  public class UpdateDoctorDto
  {
    [Required(ErrorMessage = "Name is required")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Designation is required")]
    [StringLength(50, ErrorMessage = "Designation cannot exceed 50 characters")]
    public string Designation { get; set; } = string.Empty;
  }
}
