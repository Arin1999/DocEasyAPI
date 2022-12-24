using System;
using System.Collections.Generic;

#nullable disable

namespace DocEasyAPI.Models
{
    public partial class Appointment
    {
        public Appointment()
        {
            Medicines = new HashSet<Medicine>();
        }

        public int AppointmentId { get; set; }
        public DateTime? AppointmentDateTime { get; set; }
        public bool? HasOrdered { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int ShopId { get; set; }
        public bool? IsDone { get; set; }
        public bool? HasDispatched { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Shop Shop { get; set; }
        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
