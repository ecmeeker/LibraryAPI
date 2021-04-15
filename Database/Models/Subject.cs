using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models
{
    public class Subject
    {
        public int Id { get; set; }

        public string SubjectName { get; set; }

        public int ParentSubject { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
