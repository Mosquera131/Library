using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewLibrary.Models;

[Table("Loans")]
public class Loan
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("LoanDate")]
    public required DateOnly LoanDate { get; set; }

    [Column("ReturnDate")]
    public required DateOnly ReturDate { get; set; }

    [Column("Status")]
    public required string Status { get; set; }

    //foreignkeys

    [ForeignKey("UserId")]
    public int UserId { get; set; }

    public int BookId { get; set; }


    //navigation Properties

    public User User { get; set; }

    public Book Book { get; set; }


}
