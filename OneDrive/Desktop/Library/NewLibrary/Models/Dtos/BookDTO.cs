using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewLibrary.Models.Dtos;

public class BookDTO
{

    [Required(ErrorMessage = "The Name of the Book is need it.")]
    [StringLength(100, ErrorMessage = " The name of the book can't be more that 100 characters.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "The publication year is required")]
    public DateTime YearPublication { get; set; }

    [Required(ErrorMessage = "Id author is required")]
    public int AuthorId { get; set; }

    [Required(ErrorMessage = "The editorial Id is required")]
    public int EditorialId { get; set; }

    [Required(ErrorMessage = "The genre Id is required")]
    public int GenreId { get; set; }



}
