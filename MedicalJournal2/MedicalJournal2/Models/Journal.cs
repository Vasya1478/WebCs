using System;
using System.Collections.Generic;

namespace MedicalJournal2.Models
{
    public partial class Journal
    {
        public int Id { get; set; }
        public DateTime? DateOfReceipt { get; set; }
        public int? CardNumberId { get; set; }
        public string PatientName { get; set; }
        public int? DoctorNameId { get; set; }
        public int? DoctorPost { get; set; }
        public int? ServiceId { get; set; }
        public int? Quantity { get; set; }

        public virtual Patients CardNumber { get; set; }
        public virtual Doctors DoctorName { get; set; }
        public virtual Services Service { get; set; }
    }
}
