using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewLibrary.Models;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("Name")]
    public required string Name { get; set; }

    [Column("LastName")]
    public required string LastName { get; set; }

    [Column("DocumentNumber")]
    public required string DocumentNumber { get; set; }

    [Column("BirthDate")]
    public required DateOnly BirthDate { get; set; }

    [Column("PhoneNumber")]
    public required string PhoneNumber { get; set; }

    [Column("Email")]
    public required string Email { get; set; }

    [Column("password")]
    public required string Password{ get; set; }

    //foreign keys

    public int? DocumentTypeId { get; set; }

    public int? RoleId { get; set; }

    //Navigation properties
    [ForeignKey("DocumentTypeId")]
    public DocumentType? DocumentType { get; set; }

    [ForeignKey("RoleId")]
    public Role? Role { get; set; }

}
