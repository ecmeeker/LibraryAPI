using Database.Responses;
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
        Task<BookSaveResponse> SaveAsync(Book book);
        Task<BookSaveResponse> UpdateAsync(int id, Book book);
    }
}
