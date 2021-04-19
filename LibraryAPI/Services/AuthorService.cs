using Database.Repositories;
using Database.Responses;
using LibraryAPI.Models;
using LibraryAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ITransaction _transaction;

        public AuthorService(IAuthorRepository authorRepository, ITransaction transaction)
        {
            _authorRepository = authorRepository;
            _transaction = transaction;
        }

        public async Task<IEnumerable<Author>> ListAsync()
        {
            return await _authorRepository.ListAsync();
        }

        public async Task<AuthorSaveResponse> SaveAsync(Author author)
        {
            try
            {
                await _authorRepository.AddAsync(author);
                await _transaction.CompleteAsync();

                return new AuthorSaveResponse(author);
            }
            catch (Exception ex)
            {
                return new AuthorSaveResponse($"An error occurred while attempting to save the author: {ex.Message}");
            }
        }
    }
}
