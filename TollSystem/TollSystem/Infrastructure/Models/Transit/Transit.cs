using System;
using System.Collections.Generic;

namespace TollSystem.Infrastructure.Models
{
    public partial class Transit
    {
        public Transit()
        {
            Transaction = new HashSet<Transaction>();
        }

        public decimal Id { get; set; }
        public decimal Entrancestationid { get; set; }
        public decimal Entrancestationboothid { get; set; }
        public decimal? Exitstationid { get; set; }
        public decimal? Exitstationboothid { get; set; }
        public DateTime Entrancetime { get; set; }
        public DateTime? Exittime { get; set; }
        public decimal? Tagid { get; set; }
        public decimal? Ticketid { get; set; }
        public decimal Isdeleted { get; set; }

        public virtual Tollbooth Entrancestation { get; set; }
        public virtual Tollbooth Exitstation { get; set; }
        public virtual Tag Tag { get; set; }
        public virtual Ticket Ticket { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
