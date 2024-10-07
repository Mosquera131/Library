using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewLibrary.Models;
using NewLibrary.Models.Dtos;

namespace NewLibrary.Repositories;

public interface IuserRepository
{
    Task Add(User user);
    string HashPassword(string password);
}



