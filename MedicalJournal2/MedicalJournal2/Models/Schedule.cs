using System;
using System.Collections.Generic;

namespace MedicalJournal2.Models
{
    public partial class Schedule
    {
        public Schedule()
        {
            Doctors = new HashSet<Doctors>();
        }

        public int Id { get; set; }
        public int? Number { get; set; }
        public string TimeOfReceipt { get; set; }

        public virtual ICollection<Doctors> Doctors { get; set; }
    }
}
