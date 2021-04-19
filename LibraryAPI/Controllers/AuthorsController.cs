using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibraryAPI.Extensions;
using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        // GET: api/<AuthorsController>
        [HttpGet]
        public async Task<IEnumerable<AuthorResource>> GetAllAsync()
        {
            var authors = await _authorService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Author>, IEnumerable<AuthorResource>>(authors);

            return resources;
        }

        // GET api/<AuthorsController>/5
        [HttpGet("{id}")]
        public async Task<AuthorResource> Get(int id)
        {
            var authors = await _authorService.ListAsync();
            var author = authors.Where(b => b.Id == id).FirstOrDefault();
            var resource = _mapper.Map<Author, AuthorResource>(author);

            return resource;
        }

        // POST api/<AuthorsController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AuthorSaveResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var author = _mapper.Map<AuthorSaveResource, Author>(resource);
            var result = await _authorService.SaveAsync(author);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var authorResource = _mapper.Map<Author, AuthorResource>(result.Author);

            return Ok(authorResource);
        }

        // PUT api/<AuthorsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthorsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
