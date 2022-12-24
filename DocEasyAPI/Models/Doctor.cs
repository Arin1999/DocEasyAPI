using System;
using System.Collections.Generic;

#nullable disable

namespace DocEasyAPI.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int DoctorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Degrees { get; set; }
        public string SpecializesIn { get; set; }
        public string EmploymentHistory { get; set; }
        public byte YearsOfExp { get; set; }
        public byte[] Image { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
