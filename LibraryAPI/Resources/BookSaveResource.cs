using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Resources
{
    public class BookSaveResource
    {
        [Required]
        [MaxLength(250)]
        public string Title { get; set; }

        public int? ISBN { get; set; }

        public int Year { get; set; }

        public int? Edition { get; set; }

        [Required]
        public int AuthorId { get; set; }
    }
}
