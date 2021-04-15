using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int ISBN { get; set; }

        public int Year { get; set; }

        public int? Edition { get; set; }

        public int AuthorId { get; set; }

        public int SubjectId { get; set; }

        public Author Author { get; set; }

        public Subject Subject { get; set; }
    }
}
