using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewLibrary.Models;
using NewLibrary.Repositories;


namespace NewLibrary.Controllers.Books;

[ApiController]
[Route("api/v1/[controller]")]
public partial class BookController : ControllerBase
{
    private readonly IBookRepository _IBook;

    public BookController (IBookRepository IBook)
    {
        _IBook = IBook;
    }

}
