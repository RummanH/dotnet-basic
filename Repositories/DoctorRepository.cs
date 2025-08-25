using Doctors.Models;

namespace Doctors.Repositories
{
  public static class DoctorRepository
  {
    private static readonly List<Doctor> _doctors = [];
    private static int _nextId = 1;

    public static List<Doctor> GetAll() => _doctors;

    public static Doctor? GetById(int id) =>
        _doctors.FirstOrDefault(d => d.Id == id);

    public static Doctor Add(Doctor doctor)
    {
      doctor.Id = _nextId++;
      _doctors.Add(doctor);
      return doctor;
    }

    public static bool Update(int id, Doctor updated)
    {
      var existing = GetById(id);
      if (existing == null) return false;
      existing.Name = updated.Name;
      existing.Designation = updated.Designation;
      return true;
    }

    public static bool Delete(int id)
    {
      var doctor = GetById(id);
      if (doctor == null) return false;
      _doctors.Remove(doctor);
      return true;
    }
  }
}
