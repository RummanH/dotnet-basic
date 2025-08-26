using Doctors.Data;
using Doctors.Models;
using Microsoft.EntityFrameworkCore;

namespace Doctors.Repositories
{
  public class DoctorRepository : IDoctorRepository
  {
    private readonly DoctorsDbContext _context;

    public DoctorRepository(DoctorsDbContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<Doctor>> GetAllAsync()
    {
      return await _context.Doctors.ToListAsync();
    }

    public async Task<Doctor?> GetByIdAsync(int id)
    {
      return await _context.Doctors.FindAsync(id);
    }

    public async Task<Doctor> AddAsync(Doctor doctor)
    {
      _context.Doctors.Add(doctor);
      await _context.SaveChangesAsync();
      return doctor;
    }

    public async Task<bool> UpdateAsync(int id, Doctor doctor)
    {
      var existing = await _context.Doctors.FindAsync(id);
      if (existing == null) return false;

      existing.Name = doctor.Name;
      existing.Designation = doctor.Designation;
      await _context.SaveChangesAsync();
      return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
      var existing = await _context.Doctors.FindAsync(id);
      if (existing == null) return false;

      _context.Doctors.Remove(existing);
      await _context.SaveChangesAsync();
      return true;
    }
  }
}
