using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NewLibrary.Models;

namespace NewLibrary.Repositories;

public interface IAuthRepository
{
    Task<bool> CheckExistence(string Email);

    Task<User> Get (string Email);
    
    Task<bool> Authentitication(string Email, string Password);


}
