using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewLibrary.Repositories;

namespace NewLibrary.Controllers.Auth;

    [ApiController]
    [Route("api/[controller]")]
    public partial class AuthController : ControllerBase
    {
        private readonly IAuthRepository _Auth;

        public  AuthController( IAuthRepository Auth)
        {
            _Auth=Auth;
        }
    }
