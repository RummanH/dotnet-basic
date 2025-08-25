using Doctors.Models;

namespace Doctors.Repositories
{
  public interface IDoctorRepository
  {
    Task<IEnumerable<Doctor>> GetAllAsync();
    Task<Doctor?> GetByIdAsync(int id);
    Task AddAsync(Doctor doctor);
    Task UpdateAsync(Doctor doctor);
    Task DeleteAsync(int id);
  }
}
