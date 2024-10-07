using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using NewLibrary.Data;
using NewLibrary.Models;
using NewLibrary.Repositories;

namespace NewLibrary.Services
{
    public class AuthService : IAuthRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool VerifyPassword(string password, string PassworDataBase)
        {
            return BCrypt.Net.BCrypt.Verify(password, PassworDataBase);
        }
        public async Task<bool> CheckExistence(string Email)
        {
            try
            {
                return await _context.Users.AnyAsync(v => v.Email == Email);
            }

            catch (Exception ex)
            {
                throw new Exception("Error al comprobar la existencia del usuario por email.", ex);
            }

        }

        public async Task<User> Get(string Email)
        {

            return await _context.Users.Include(User => User.Role).FirstOrDefaultAsync(u => u.Email == Email);
        }

        public async Task<bool> Authentitication(string Email, string Password)
        {
            var Exist = await CheckExistence(Email);
            if (!Exist)
            {
                return false;
            }


            var dataBaseUser = await Get(Email);
            var verifyingPassword = VerifyPassword(Password, dataBaseUser.Password);

            if (verifyingPassword == false)
            {
                return false;
            }


            if (dataBaseUser.RoleId != 1)
            {
                return false;
            }

            return true;

        }







    }
}