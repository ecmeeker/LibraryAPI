using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibraryAPI.Models;
using LibraryAPI.Resources;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using LibraryAPI.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BooksController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public async Task<IEnumerable<BookResource>> GetAllAsync()
        {
            var books = await _bookService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Book>, IEnumerable<BookResource>>(books);

            return resources;
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public async Task<BookResource> Get(int id)
        {
            var books = await _bookService.ListAsync();
            var book = books.Where(b => b.Id == id).FirstOrDefault();
            var resource = _mapper.Map<Book, BookResource>(book);

            return resource;
        }

        // POST api/<BooksController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] BookSaveResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var book = _mapper.Map<BookSaveResource, Book>(resource);
            var result = await _bookService.SaveAsync(book);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var bookResource = _mapper.Map<Book, BookResource>(result.Book);

            return Ok(bookResource);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] BookSaveResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var book = _mapper.Map<BookSaveResource, Book>(resource);
            var result = await _bookService.UpdateAsync(id, book);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var bookResource = _mapper.Map<Book, BookResource>(result.Book);

            return Ok(bookResource);
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
