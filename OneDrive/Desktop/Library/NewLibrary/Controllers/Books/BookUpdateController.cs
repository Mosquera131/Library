using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using NewLibrary.Models;
using NewLibrary.Models.Dtos;
using NewLibrary.Repositories;
using Swashbuckle.AspNetCore.Annotations;

namespace NewLibrary.Controllers.Books;

public partial class BookController
{
    [HttpPut("/api/v1/book{Id}")]

    [SwaggerOperation(
        Summary = "Update a book",
        Description = "Get a book and Update the book with the new information that has been submited. "
        )]
    [SwaggerResponse(200, "Return the book that has been updated ")]
    [SwaggerResponse(500, "An Internal server error occurred.")]

    public async Task<ActionResult<Book>> Update(int Id, BookDTO bookDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var Checkbook = await _IBook.CheckExistence(Id);

        if (Checkbook == false)
        {
            return NotFound("The book is not in our system");
        }

        var Book = await _IBook.GetById(Id);

        if (Book == null)
        {
            return NotFound();
        }

        Book.Name = bookDTO.Name;
        Book.YearPublication = bookDTO.YearPublication;
        Book.AuthorId = bookDTO.AuthorId;
        Book.EditorialId = bookDTO.EditorialId;
        Book.GenreId = bookDTO.GenreId;

        await _IBook.Update(Book);
        return NoContent();

    }
}
