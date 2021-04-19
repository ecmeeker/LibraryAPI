using LibraryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Responses
{
    public class BookSaveResponse : BaseResponse
    {
        public Book Book { get; private set; }

        private BookSaveResponse(bool success, string message, Book book) : base(success, message)
        {
            Book = book;
        }

        // Create a success response
        // <param name="book">Saved book</param>
        // <return>Response</return>
        public BookSaveResponse(Book book) : this(true, string.Empty, book)
        {
        }

        // Create error response
        // <param name="message">Error message</param>
        // <return>Response</return>
        public BookSaveResponse(string message) : this(false, message, null)
        {
        }
    }
}
