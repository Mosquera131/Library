using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewLibrary.Models.Dtos;

    public class LoginDTO
    {
        
        [EmailAddress(ErrorMessage = "The email format is not valid")]
        public required string Email { get; set; }
        
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>/?])(?=.*[a-zA-Z0-9]).{8,}$", ErrorMessage = "The password needs: 8 characters, 1 special character, 1 char in upper case")]
        public required string Password { get; set; }
    }
    
