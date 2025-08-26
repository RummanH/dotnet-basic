using Doctors.Models;

namespace Doctors.Repositories
{
  public interface IDoctorRepository
  {
    Task<IEnumerable<Doctor>> GetAllAsync();
    Task<Doctor?> GetByIdAsync(int id);
    Task<Doctor> AddAsync(Doctor doctor);
    Task<bool> UpdateAsync(int id, Doctor doctor);
    Task<bool> DeleteAsync(int id);
  }
}
