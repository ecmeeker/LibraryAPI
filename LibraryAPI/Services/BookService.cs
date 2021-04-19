using Database.Repositories;
using Database.Responses;
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
        private readonly ITransaction _transaction;

        public BookService(IBookRepository bookRepository, ITransaction transaction)
        {
            _bookRepository = bookRepository;
            _transaction = transaction;
        }

        public async Task<IEnumerable<Book>> ListAsync()
        {
            return await _bookRepository.ListAsync();
        }

        public async Task<BookSaveResponse> SaveAsync(Book book)
        {
            try
            {
                await _bookRepository.AddAsync(book);
                await _transaction.CompleteAsync();

                return new BookSaveResponse(book);
            }
            catch (Exception ex)
            {
                return new BookSaveResponse($"An error occurred while attempting to save the book: {ex.Message}");
            }
        }

        public async Task<BookSaveResponse> UpdateAsync(int id, Book book)
        {
            try
            {
                Book existingBook = await _bookRepository.FindByIdAsync(id);

                if (existingBook == null)
                {
                    return new BookSaveResponse("Book not found");
                    //return await SaveAsync(book);
                }

                existingBook = book;

                _bookRepository.Update(existingBook);

                await _transaction.CompleteAsync();

                return new BookSaveResponse(existingBook);
            }
            catch (Exception ex)
            {
                return new BookSaveResponse($"An error occurred while attempting to update the book: {ex.Message}");
            }
        }
    }
}
