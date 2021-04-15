using Database.Contexts;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Repositories
{
    public class BookRepository : BaseRepository, IBookRepository
    {
        public BookRepository(LibraryDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Book>> ListAsync()
        {
            return await _context.Books.ToListAsync();
        }
    }
}
