using Doctors.DTOs;
using Doctors.Models;
using Doctors.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctors.Services
{
  public class DoctorService
  {
    private readonly IDoctorRepository _repository;

    public DoctorService(IDoctorRepository repository)
    {
      _repository = repository;
    }

    // Get all doctors
    public async Task<List<DoctorResponseDto>> GetAllAsync()
    {
      var doctors = await _repository.GetAllAsync();
      return doctors.Select(d => MapToDto(d)).ToList();
    }

    // Get doctor by Id
    public async Task<DoctorResponseDto?> GetByIdAsync(int id)
    {
      var doctor = await _repository.GetByIdAsync(id);
      return doctor is null ? null : MapToDto(doctor);
    }

    // Add new doctor
    public async Task<DoctorResponseDto> AddAsync(CreateDoctorDto dto)
    {
      var doctor = new Doctor
      {
        Name = dto.Name,
        Designation = dto.Designation
      };
      await _repository.AddAsync(doctor);
      return MapToDto(doctor);
    }

    // Update doctor
    public async Task<bool> UpdateAsync(int id, UpdateDoctorDto dto)
    {
      var doctor = await _repository.GetByIdAsync(id);
      if (doctor == null) return false;

      doctor.Name = dto.Name;
      doctor.Designation = dto.Designation;

      await _repository.UpdateAsync(doctor);
      return true;
    }

    // Delete doctor
    public async Task<bool> DeleteAsync(int id)
    {
      var doctor = await _repository.GetByIdAsync(id);
      if (doctor == null) return false;

      await _repository.DeleteAsync(id);
      return true;
    }

    // Mapping helper
    private static DoctorResponseDto MapToDto(Doctor doctor) => new DoctorResponseDto
    {
      Id = doctor.Id,
      Name = doctor.Name,
      Designation = doctor.Designation
    };
  }
}
