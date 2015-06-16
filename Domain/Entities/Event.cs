using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Event
    {
        public int EventId { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane.")]
        [Range(1,90, ErrorMessage = "Proszę wprowadzić wartość od 1 do 90.")]
        public int Time { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane.")]
        public int MatchId { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane.")]
        public int ClubId { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane.")]
        public int PlayerId { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane.")]
        public int EventKindId { get; set; }
        public virtual Match Match { get; set; }
        public virtual Club Club { get; set; }
        public virtual Player Player { get; set; }
        public virtual EventKind Kind { get; set; }
        
    }
}
