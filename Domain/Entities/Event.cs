using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Event
    {
        public int EventId { get; set; }
        public int Time { get; set; }

        public int MatchId { get; set; }
        public int ClubId { get; set; }
        public int PlayerId { get; set; }
        public int EventKindId { get; set; }
        public virtual Match Match { get; set; }
        public virtual Club Club { get; set; }
        public virtual Player Player { get; set; }
        public virtual EventKind Kind { get; set; }
        
    }
}
