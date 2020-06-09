using System;
using System.Collections.Generic;

namespace MedicalJournal2.Models
{
    public partial class NameOfService
    {
        public NameOfService()
        {
            Doctors = new HashSet<Doctors>();
            Services = new HashSet<Services>();
        }

        public int Id { get; set; }
        public string TypeOfService { get; set; }

        public virtual ICollection<Doctors> Doctors { get; set; }
        public virtual ICollection<Services> Services { get; set; }
    }
}
