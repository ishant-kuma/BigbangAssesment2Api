using BigBangAssessment2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BigBangAssessment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivateController : ControllerBase
    {
        
            private readonly HospitalDbContext _context;

            public ActivateController(HospitalDbContext context)
            {
                _context = context;
            }

            [HttpGet]
           // [Authorize(Roles = "Patient")]
            public async Task<ActionResult<IEnumerable<Doctor>>> GetActiveDoctors()
            {
                var activeDoctors = await _context.Doctors.Where(d => d.isActive).ToListAsync();
                return activeDoctors;
            }
        [Route("api/doctor/change-status/{id}")]
        [HttpPut]
        public async Task<ActionResult> ChangeStatus(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound($"Doctor Not Found with id = {id}");

            }
            doctor.isActive = !doctor.isActive;
            _context.SaveChanges();
            return Ok(doctor);
        }
    }
 

}
