using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Player
    {
        public int PlayerId { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane.")]
        public int PositionId { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane.")]
        public int ClubId { get; set; }

        public virtual Position Position { get; set; }
        public virtual Club Club { get; set; }
    }
}
