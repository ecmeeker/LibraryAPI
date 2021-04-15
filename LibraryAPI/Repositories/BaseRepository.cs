using Database.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly LibraryDbContext _context;

        public BaseRepository(LibraryDbContext context)
        {
            _context = context;
        }
    }
}
