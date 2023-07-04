using BigBangAssessment2.Models;

namespace BigBangAssessment2.Repository
{
    public interface IPatientRepository
    {
        Task<Patient> GetPatientById(int id);
        Task<IEnumerable<Patient>> GetPatients();

        Task AddPatient(Patient patient);

        Task DeletePatient(int id);
        Task UpdatePatient(Patient patient);

    }
}
