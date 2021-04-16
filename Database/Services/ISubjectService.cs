using LibraryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public interface ISubjectService
    {
        Task<IEnumerable<Subject>> ListAsync();
    }
}
