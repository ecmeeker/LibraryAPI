using LibraryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Responses
{
    public class AuthorSaveResponse : BaseResponse
    {
        public Author Author { get; private set; }

        private AuthorSaveResponse(bool success, string message, Author author) : base(success, message)
        {
            Author = author;
        }

        // Create a success response
        // <param name="book">Saved book</param>
        // <return>Response</return>
        public AuthorSaveResponse(Author author) : this(true, string.Empty, author)
        {
        }

        // Create error response
        // <param name="message">Error message</param>
        // <return>Response</return>
        public AuthorSaveResponse(string message) : this(false, message, null)
        {
        }
    }
}
