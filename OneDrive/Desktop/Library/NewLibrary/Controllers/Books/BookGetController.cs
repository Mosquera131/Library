using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewLibrary.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace NewLibrary.Controllers.Books
{
    public partial class BookController
    {
        [HttpGet("/api/v1/books")]
        [SwaggerOperation(
        Summary = "Retrieve all Books",
        Description = "Gets all the Book  that has been registered and save in the database. "
        )]
        [SwaggerResponse(200, "Return a list of the books.")]
        [SwaggerResponse(500, "An Internal server error occurred.")]


        public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks()
        {
            try
            {
                var books = await _IBook.GetAll();

                if (books == null || !books.Any())
                {
                    return NoContent();
                }

                return Ok(books);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrió un error inesperado al obtener los libros.");
            }



        }

        [HttpGet("/api/v1/{id}")]

        [SwaggerOperation(
        Summary = "Retrieve an specific Book",
        Description = "Gets  the Book  that has been search by  its Id "
        )]
        [SwaggerResponse(200, "Return a registered book ")]
        [SwaggerResponse(404, "Book not found")]
        [SwaggerResponse(500, "An Internal server error occurred.")]

        public async Task<ActionResult<Book>> GetById(int id)
        {
            var book = await _IBook.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return book;
        }

        [HttpGet("/api/v1/books/{keyword}")]

        [SwaggerOperation(
        Summary = "Retrieve all the books by a keyword",
        Description = "Gets all the Books that contain the keyword that has been searched "
        )]
        [SwaggerResponse(200, "Return a List of books ")]
        [SwaggerResponse(500, "An Internal server error occurred.")]

        public async Task<ActionResult<IEnumerable<Book>>> SearchKeyWord(string keyword)
        {
            var books = await _IBook.SearchKeyWord(keyword);

            if (string.IsNullOrWhiteSpace(keyword))
            {
                return BadRequest("The key word can't be empty");
            }
            return Ok(books);
        }

    };
}