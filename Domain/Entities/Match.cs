using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Match
    {
        public int MatchId { get; set; }
        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }
        public int HomeClubId { get; set; }
        public int AwayClubId { get; set; }
        public virtual Club HomeClub { get; set; }
        public virtual Club AwayClub { get; set; }
        public virtual List<Event> Events { get; set; }
    }
}
