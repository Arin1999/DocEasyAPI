using System;
using System.Collections.Generic;

#nullable disable

namespace DocEasyAPI.Models
{
    public partial class Shop
    {
        public Shop()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int ShopId { get; set; }
        public string OwnerName { get; set; }
        public string OwnerPassword { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
