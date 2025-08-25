using Doctors.Models;
using Doctors.Repositories;

namespace Doctors.Services
{
  public class DoctorService(DoctorRepository repository)
  {
    private readonly DoctorRepository _repository = repository;

    public List<Doctor> GetAll() => _repository.GetAll();

    public Doctor? GetById(int id) => _repository.GetById(id);

    public Doctor Add(Doctor doctor) => _repository.Add(doctor);

    public bool Update(int id, Doctor doctor) => _repository.Update(id, doctor);

    public bool Delete(int id) => _repository.Delete(id);
  }
}
