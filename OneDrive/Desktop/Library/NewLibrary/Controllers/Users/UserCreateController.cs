using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NewLibrary.Models;
using NewLibrary.Models.Dtos;
using Swashbuckle.AspNetCore.Annotations;

namespace NewLibrary.Controllers.Users;

public partial class UserController
{
    [HttpPost]
    [SwaggerOperation(
    Summary = "Add a Book",
    Description = "Register a Book in the database."
)]
    [SwaggerResponse(200, "Return the Book that has been created.")]
    [SwaggerResponse(500, "An Internal server error occurred.")]

    public async Task<ActionResult<User>> Create(UserDTO inputUser)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var passwordh = _IuserService.HashPassword(inputUser.Password);

        var user1 = new User
        {
            Name = inputUser.Name,
            LastName = inputUser.LastName,
            DocumentNumber = inputUser.DocumentNumber,
            BirthDate = inputUser.BirthDate,
            PhoneNumber = inputUser.PhoneNumber,
            Email = inputUser.Email,
            Password = inputUser.Password,  // Password will be hashed in the service
            DocumentTypeId = inputUser.DocumentTypeId,
            RoleId = inputUser.RoleId,

        };

        //  var newBook = new Book(inputBook.Name, inputBook.YearPublication, inputBook.AuthorId, inputBook.EditorialId, inputBook.GenreId);

        await _IuserService.Add(user1);

        return Ok(user1);
    }

}
