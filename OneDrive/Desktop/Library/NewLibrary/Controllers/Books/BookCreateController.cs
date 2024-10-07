using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NewLibrary.Models;
using NewLibrary.Models.Dtos;
using Swashbuckle.AspNetCore.Annotations;

namespace NewLibrary.Controllers.Books;


public partial class BookController
{
    [HttpPost]
    [Authorize]
    [SwaggerOperation(
        Summary ="Add a Book",
        Description="Register a Book in the database."
    )]
    [SwaggerResponse(200,"Return the Book that has been created.")]
    [SwaggerResponse(500,"An Internal server error occurred.")]

    public async Task<ActionResult<Book>> Create(BookDTO inputBook)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var newBook = new Book
        {
            Name = inputBook.Name.ToLower().Trim(),
            YearPublication = inputBook.YearPublication,
            AuthorId = inputBook.AuthorId,
            EditorialId = inputBook.EditorialId,
            GenreId = inputBook.GenreId
        };

        //  var newBook = new Book(inputBook.Name, inputBook.YearPublication, inputBook.AuthorId, inputBook.EditorialId, inputBook.GenreId);

        await _IBook.Add(newBook);

        return Ok(newBook);
    }

}
