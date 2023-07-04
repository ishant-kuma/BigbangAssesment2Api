using BigBangAssessment2.Models;
using BigBangAssessment2.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigBangAssessment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _IPRepository;
        public PatientController(IPatientRepository IPRepository)
        {
            _IPRepository = IPRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatient()
        {
            var pat = await _IPRepository.GetPatients();
            return Ok(pat);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            try
            {
                var pat = await _IPRepository.GetPatientById(id);
                if (pat == null)
                    return NotFound();

                return Ok(pat);

            }
            catch (Exception ex)
            {
                // Handle and log the exception
                Console.WriteLine("Error retrieving patient by ID: " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the Patient.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor(Patient patient)
        {
            try
            {
                await _IPRepository.AddPatient(patient);
                return CreatedAtAction(nameof(GetPatientById), new { id = patient.PatientId }, patient);
            }
            catch (Exception ex)
            {
                // Handle and log the exception
                Console.WriteLine("Error creating patient: " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the patient.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, Patient patient)
        {
            try
            {
                if (id != patient.PatientId)
                    return BadRequest();

                await _IPRepository.UpdatePatient(patient);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle and log the exception
                Console.WriteLine("Error updating patient: " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the patient.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            try
            {
                await _IPRepository.DeletePatient(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle and log the exception
                Console.WriteLine("Error deleting patient: " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the patient.");
            }
        }

    }
}
