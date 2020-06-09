using System;
using System.Collections.Generic;

namespace MedicalJournal2.Models
{
    public partial class Services
    {
        public Services()
        {
            Journal = new HashSet<Journal>();
        }

        public int Id { get; set; }
        public int Number { get; set; }
        public string ServiceName { get; set; }
        public int? TypeOfServiceId { get; set; }
        public decimal? Price { get; set; }
        public int? Discount { get; set; }

        public virtual NameOfService TypeOfService { get; set; }
        public virtual ICollection<Journal> Journal { get; set; }
    }
}
