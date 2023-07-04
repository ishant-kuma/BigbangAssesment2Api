using BigBangAssessment2.Models;

namespace BigBangAssessment2.Repository
{
    public interface IDoctorRepository
    {
        Task<Doctor> GetDoctorById(int id);
        Task<IEnumerable<Doctor>> GetDoctors();
        Task AddDoctor(Doctor doctor);
        Task UpdateDoctor(Doctor doctor);
        Task DeleteDoctor(int id);

    }
}
