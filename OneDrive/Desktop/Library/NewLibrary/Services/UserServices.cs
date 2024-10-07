using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore;
using NewLibrary.Data;
using NewLibrary.Models;
using NewLibrary.Models.Dtos;
using NewLibrary.Repositories;

namespace NewLibrary.Services;

public class UserServices : IuserRepository
{

    private readonly ApplicationDbContext _context;

    public UserServices(ApplicationDbContext context)
    {
        _context = context;
    }
    public string HashPassword(string password)
    {
        // Hash the password using BCrypt
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public async Task Add(User user)
    {
        if (!await _context.DocumentTypes.AnyAsync(dt => dt.Id == user.DocumentTypeId))
        {
            throw new Exception("DocumentTypeId does not exist.");
        }

        if (!await _context.Roles.AnyAsync(r => r.Id == user.RoleId))
        {
            throw new Exception("RoleId does not exist.");
        }

        // Hashing the password before saving
        user.Password = HashPassword(user.Password);

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }



}




