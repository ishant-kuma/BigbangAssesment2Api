using BigBangAssessment2.Models;
using BigBangAssessment2.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigBangAssessment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            var doctors = await _doctorRepository.GetDoctors();
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            try
            {
                var doctor = await _doctorRepository.GetDoctorById(id);
                if (doctor == null)
                    return NotFound();

                return Ok(doctor);
            }
            catch (Exception ex)
            {
                // Handle and log the exception
                Console.WriteLine("Error retrieving doctor by ID: " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the doctor.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor(Doctor doctor)
        {
            try
            {
                await _doctorRepository.AddDoctor(doctor);
                return Ok(doctor);
            }
            catch (Exception ex)
            {
                // Handle and log the exception
                Console.WriteLine("Error creating doctor: " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the doctor.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor(int id, [FromBody] Doctor doctor)
        {
            try
            {
                if (id != doctor.DoctorId)
                    return BadRequest();

                await _doctorRepository.UpdateDoctor(doctor);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle and log the exception
                Console.WriteLine("Error updating doctor: " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the doctor.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            try
            {
                await _doctorRepository.DeleteDoctor(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle and log the exception
                Console.WriteLine("Error deleting doctor: " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the doctor.");
            }
        }





    }
}
