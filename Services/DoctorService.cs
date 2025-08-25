using Doctors.DTOs;
using Doctors.Models;
using Doctors.Repositories;

namespace Doctors.Services
{
  public class DoctorService(DoctorRepository repository)
  {


    public List<DoctorResponseDto> GetAll() => [.. repository.GetAll().Select(d => MapToDto(d))];

    public DoctorResponseDto? GetById(int id)
    {
      var doctor = repository.GetById(id);
      return doctor is null ? null : MapToDto(doctor);
    }

    public DoctorResponseDto Add(CreateDoctorDto dto)
    {
      var doctor = new Doctor
      {
        Name = dto.Name,
        Designation = dto.Designation
      };
      var created = repository.Add(doctor);
      return MapToDto(created);
    }

    public bool Update(int id, UpdateDoctorDto dto)
    {
      var doctor = new Doctor
      {
        Name = dto.Name,
        Designation = dto.Designation
      };
      return repository.Update(id, doctor);
    }

    public bool Delete(int id) => repository.Delete(id);

    private static DoctorResponseDto MapToDto(Doctor doctor) => new()
    {
      Id = doctor.Id,
      Name = doctor.Name,
      Designation = doctor.Designation
    };
  }
}
