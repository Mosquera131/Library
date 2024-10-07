using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewLibrary.ConfigJWT;
using NewLibrary.Models;
using NewLibrary.Models.Dtos;
using NewLibrary.Services;

namespace NewLibrary.Controllers.Auth;

public partial class AuthController
{
    
        [HttpPost("GenerateToken")]

        public async Task<IActionResult> GenerateToken(User user)
        {
            var token = JWT.GenerateJwtToken(user);

            return Ok($"ACA ESTA SU TOKEN{token}");
        }
    

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult> Login(LoginDTO login)

    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var verificatioLogin = await _Auth.Authentitication(login.Email, login.Password);

        if (verificatioLogin == false)
        {
            return StatusCode(500, "The user can't be authenticade");
        }

        var VerifyingUser = await _Auth.Get(login.Email);

        var Savetoke = JWT.GenerateJwtToken(VerifyingUser);

        return Ok(Savetoke);


    }

}
