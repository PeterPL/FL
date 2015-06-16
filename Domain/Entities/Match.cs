using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Match
    {
        public int MatchId { get; set; }
       [Required(ErrorMessage = "To pole jest wymagane.")]
        public int HomeGoals { get; set; }
      [Required(ErrorMessage = "To pole jest wymagane.")]
        public int AwayGoals { get; set; }
       [Required(ErrorMessage = "To pole jest wymagane.")]
        public int HomeClubId { get; set; }
       [Required(ErrorMessage = "To pole jest wymagane.")]
        public int AwayClubId { get; set; }
        public virtual Club HomeClub { get; set; }
        public virtual Club AwayClub { get; set; }
        public virtual List<Event> Events { get; set; }
    }
}
