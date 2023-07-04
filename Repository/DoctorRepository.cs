using BigBangAssessment2.Models;
using Microsoft.EntityFrameworkCore;

namespace BigBangAssessment2.Repository
{
    public class DoctorRepository:IDoctorRepository
    {
        private readonly HospitalDbContext _dbContext;

        public DoctorRepository(HospitalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            var doctors = await _dbContext.Set<Doctor>().Include(x => x.Patients).ToListAsync();
            return doctors;
        }

        public async Task AddDoctor(Doctor doctor)
        {
            try
            {
                await _dbContext.Set<Doctor>().AddAsync(doctor);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }


        public async Task DeleteDoctor(int id)
        {
            try
            {
                var doctor = await _dbContext.Set<Doctor>().FindAsync(id);
                _dbContext.Set<Doctor>().Remove(doctor);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            var doctor = await _dbContext.Set<Doctor>().FirstOrDefaultAsync(d => d.DoctorId == id);
            return doctor;
        }


        public async Task UpdateDoctor(Doctor doctor)
        {
            try
            {
                _dbContext.Entry(doctor).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }



    }
}
