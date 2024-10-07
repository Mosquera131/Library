using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace NewLibrary.Controllers.Books;

public partial class BookController
{
    [HttpDelete("/api/v1/book/{id}")]
    [Authorize]

    [SwaggerOperation(
        Summary = "Delete a Book",
        Description = "This endpoint allows to delete any book that has been registered. "
    )]
    [SwaggerResponse(200, "Return the confirmation than the  Book has been deleted.")]
    [SwaggerResponse(500, "An Internal server error occurred.")]

    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var result = await _IBook.Delete(id);
        if (result)
        {
            return Ok($"Book has been deleted");

        }
        return StatusCode(500, "the Boos was not deleted");




    }
}
