using LibraryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Repositories
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<Subject>> ListAsync();
    }
}
