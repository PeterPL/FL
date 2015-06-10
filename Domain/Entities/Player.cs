using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int PositionId { get; set; }
        public int ClubId { get; set; }
        public virtual Position Position { get; set; }
        public virtual Club Club { get; set; }
    }
}
