using System.ComponentModel.DataAnnotations;

namespace BigBangAssessment2.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        public string? Name { get; set; }
        public string? Specialty { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        public bool isActive { get; set; }
      
        public ICollection<Patient>? Patients { get; set; }
    }

}
