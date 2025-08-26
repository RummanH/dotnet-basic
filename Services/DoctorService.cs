using Doctors.DTOs;
using Doctors.Models;
using Doctors.Repositories;

namespace Doctors.Services
{
  public class DoctorService
  {
    private readonly IDoctorRepository _repository;

    public DoctorService(IDoctorRepository repository)
    {
      _repository = repository;
    }

    public async Task<List<DoctorResponseDto>> GetAllAsync()
    {
      var doctors = await _repository.GetAllAsync();
      return doctors.Select(d => MapToDto(d)).ToList();
    }

    public async Task<DoctorResponseDto?> GetByIdAsync(int id)
    {
      var doctor = await _repository.GetByIdAsync(id);
      return doctor is null ? null : MapToDto(doctor);
    }

    public async Task<DoctorResponseDto> AddAsync(CreateDoctorDto dto)
    {
      var doctor = new Doctor
      {
        Name = dto.Name,
        Designation = dto.Designation
      };
      var created = await _repository.AddAsync(doctor);
      return MapToDto(created);
    }

    public async Task<bool> UpdateAsync(int id, UpdateDoctorDto dto)
    {
      var doctor = new Doctor
      {
        Name = dto.Name,
        Designation = dto.Designation
      };
      return await _repository.UpdateAsync(id, doctor);
    }

    public async Task<bool> DeleteAsync(int id) =>
      await _repository.DeleteAsync(id);

    private static DoctorResponseDto MapToDto(Doctor doctor) => new()
    {
      Id = doctor.Id,
      Name = doctor.Name,
      Designation = doctor.Designation
    };
  }
}
