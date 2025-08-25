using System.ComponentModel.DataAnnotations;

namespace Doctors.Models
{
  public class Doctor
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "Doctor name is required")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Doctor designation is required")]
    [StringLength(50, ErrorMessage = "Designation cannot exceed 50 characters")]
    public string Designation { get; set; } = string.Empty;
  }
}
