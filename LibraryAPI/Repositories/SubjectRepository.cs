using Database.Contexts;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Repositories
{
    public class SubjectRepository : BaseRepository, ISubjectRepository
    {
        public SubjectRepository(LibraryDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Subject>> ListAsync()
        {
            return await _context.Subjects.ToListAsync();
        }
    }
}
