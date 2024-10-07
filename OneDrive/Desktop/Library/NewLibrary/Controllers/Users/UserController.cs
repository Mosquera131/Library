using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewLibrary.Repositories;

namespace NewLibrary.Controllers.Users;

[ApiController]
[Route("api/[controller]")]
public partial class UserController : ControllerBase
{
    private readonly IuserRepository _IuserService;

    public UserController(IuserRepository IuserService)
    {
        _IuserService = IuserService;
    }
}
