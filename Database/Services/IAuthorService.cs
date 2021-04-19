using Database.Responses;
using LibraryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> ListAsync();
        Task<AuthorSaveResponse> SaveAsync(Author author);
    }
}
