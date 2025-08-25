using Doctors.Models;
using Doctors.Repositories;

namespace Doctors.Services
{
  public class DoctorService(DoctorRepository repository)
  {

    public List<Doctor> GetAll() => repository.GetAll();

    public Doctor? GetById(int id) => repository.GetById(id);

    public Doctor Add(Doctor doctor) => repository.Add(doctor);

    public bool Update(int id, Doctor doctor) => repository.Update(id, doctor);

    public bool Delete(int id) => repository.Delete(id);
  }
}
