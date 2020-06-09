using System;
using System.Collections.Generic;

namespace MedicalJournal2.Models
{
    public partial class Doctors
    {
        public Doctors()
        {
            Journal = new HashSet<Journal>();
        }

        public int Id { get; set; }
        public int? EmployeeCode { get; set; }
        public string Name { get; set; }
        public int? PositionId { get; set; }
        public int? CabinetNumber { get; set; }
        public int? TimeOfReceiptId { get; set; }
        public int? TypeOfServiceId { get; set; }

        public virtual NameOfPosition Position { get; set; }
        public virtual Schedule TimeOfReceipt { get; set; }
        public virtual NameOfService TypeOfService { get; set; }
        public virtual ICollection<Journal> Journal { get; set; }
    }
}
