using AutoMapper;
using LibraryAPI.Models;
using LibraryAPI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Book, BookResource>();
            CreateMap<Author, AuthorResource>();
        }
    }
}
