using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Club
    {
        public int ClubId { get; set; }
        public string Name { get; set; }
        public int Played { get; set; }
        public int Points { get; set; }
        public int Won { get; set; }
        public int Drawn { get; set; }
        public int Lost { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }

        public virtual List<Player> Players { get; set; }
        public virtual List<Match> Matches { get; set; }
    }
}
