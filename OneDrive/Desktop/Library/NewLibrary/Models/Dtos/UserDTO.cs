using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewLibrary.Models.Dtos;

public class UserDTO
{

    [Required(ErrorMessage = "The Name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "The LastName is required")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "The DocumentNumber is required")]
    public string DocumentNumber { get; set; }

    [Required(ErrorMessage = "The Birthdate is required")]
    public DateOnly BirthDate { get; set; }

    [Required(ErrorMessage = "The PhoneNumber is required")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "The Email is required")]
    public string Email { get; set; }

    [Required]
    [Column("password")]
    public required string Password { get; set; }

    [Required(ErrorMessage = "The DocumentType is required")]
    public int DocumentTypeId { get; set; }

    [Required(ErrorMessage = "The Rol Idis required")]
    public int RoleId { get; set; }
}
