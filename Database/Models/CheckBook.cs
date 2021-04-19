using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models
{
    public class CheckBook
    {
        [ForeignKey("Book")]
        public Book Book { get; set; }

        [ForeignKey("User")]
        public User User { get; set; }

        public DateTime CheckOutDate { get; set; }

        public DateTime CheckInDate { get; set; }
    }
}
