using Doctors.Models;
using Microsoft.EntityFrameworkCore;

namespace Doctors.Data
{
  public class DoctorsDbContext(DbContextOptions<DoctorsDbContext> options) : DbContext(options)
  {
    public DbSet<Doctor> Doctors { get; set; }
  }
}
