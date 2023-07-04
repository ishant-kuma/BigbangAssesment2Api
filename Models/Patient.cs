using System.ComponentModel.DataAnnotations;

namespace BigBangAssessment2.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string?   Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? MedicalCondition { get; set; }
        
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
    }

}
