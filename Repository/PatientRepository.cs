using BigBangAssessment2.Models;
using Microsoft.EntityFrameworkCore;

namespace BigBangAssessment2.Repository
{
    public class PatientRepository:IPatientRepository
    {
        private readonly HospitalDbContext _dbcontext;

        public PatientRepository(HospitalDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            var p = await _dbcontext.Set<Patient>().Include(x => x.Doctor).ToListAsync();
            return p;
        }

        public async Task AddPatient(Patient patient)
        {
            try
            {
                await _dbcontext.Set<Patient>().AddAsync(patient);
                await _dbcontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task DeletePatient(int id)
        {
            try
            {
                var p = await _dbcontext.Set<Patient>().FindAsync(id);
                _dbcontext.Set<Patient>().Remove(p);
                await _dbcontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<Patient> GetPatientById(int id)
        {
            var pat = await _dbcontext.Set<Patient>().FirstOrDefaultAsync(d => d.DoctorId == id);
            return pat;
        }

        public async Task UpdatePatient(Patient patient)
        {
            try
            {
                _dbcontext.Entry(patient).State = EntityState.Modified;
                await _dbcontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }



    }
}
