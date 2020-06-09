using System;
using System.Collections.Generic;

namespace MedicalJournal2.Models
{
    public partial class Patients
    {
        public Patients()
        {
            Journal = new HashSet<Journal>();
        }

        public int Id { get; set; }
        public int? CardNumber { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Address { get; set; }
        public string InsuranceNumber { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Journal> Journal { get; set; }
    }
}
