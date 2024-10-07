using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewLibrary.Models.Dtos;

public class LoanDTO
{

    [Required(ErrorMessage = "The Loan Date must be type")]
    public DateOnly LoanDate { get; set; }

    [Required(ErrorMessage = "The returning date must be Type")]
    public DateOnly ReturnDate { get; set; }

    [Required(ErrorMessage = "Must be an status")]
    public string Status { get; set; }

    [Required(ErrorMessage = "Must be an UserId")]
    public int UserId { get; set; }
    
    [Required(ErrorMessage = "Must be a BookId")]
    public int BookId { get; set; }
}
