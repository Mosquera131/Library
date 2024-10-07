using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewLibrary.Models;

[Table("Books")]
public class Book
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("Name")]
    public string Name { get; set; }

    [Column("YearPublication")]
    public DateTime YearPublication { get; set; }

    //foreing keys
    public required int AuthorId { get; set; }

    public required int EditorialId { get; set; }

    public required int GenreId { get; set; }


    //navigations properties
    [ForeignKey("AuthorId")]
    public Author Author { get; set; }

    [ForeignKey("EditorialId")]
    public Editorial Editorial { get; set; }

    [ForeignKey("GenreId")]
    public Genre Genre { get; set; }


}
