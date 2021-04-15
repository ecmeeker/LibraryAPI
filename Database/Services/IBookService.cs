using LibraryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> ListAsync();
    }
}
