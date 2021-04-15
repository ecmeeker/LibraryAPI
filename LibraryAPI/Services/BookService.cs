using LibraryAPI.Models;
using LibraryAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this._bookRepository = bookRepository;
        }
        public async Task<IEnumerable<Book>> ListAsync()
        {
            return await _bookRepository.ListAsync();
        }
    }
}
