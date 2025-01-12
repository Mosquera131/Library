using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewLibrary.Models;

[Table("Authors")]
public class Author
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [Column("Name")]
    public string Name { get; set; }

    [Required]
    [Column("CountryOrigen")]
    public string CountryOrigen { get; set; }
}

