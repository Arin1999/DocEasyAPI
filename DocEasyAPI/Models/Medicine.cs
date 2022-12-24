using System;
using System.Collections.Generic;

#nullable disable

namespace DocEasyAPI.Models
{
    public partial class Medicine
    {
        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public int AppointmentId { get; set; }
        public byte? Dose { get; set; }

        public virtual Appointment Appointment { get; set; }
    }
}
