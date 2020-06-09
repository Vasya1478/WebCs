using System;
using System.Collections.Generic;

namespace MedicalJournal2.Models
{
    public partial class NameOfPosition
    {
        public NameOfPosition()
        {
            Doctors = new HashSet<Doctors>();
        }

        public int Id { get; set; }
        public string Position { get; set; }
        public decimal? Salary { get; set; }
        public decimal? Premium { get; set; }

        public virtual ICollection<Doctors> Doctors { get; set; }
    }
}
