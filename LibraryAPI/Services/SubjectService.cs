using LibraryAPI.Models;
using LibraryAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            this._subjectRepository = subjectRepository;
        }
        public async Task<IEnumerable<Subject>> ListAsync()
        {
            return await _subjectRepository.ListAsync();
        }
    }
}
