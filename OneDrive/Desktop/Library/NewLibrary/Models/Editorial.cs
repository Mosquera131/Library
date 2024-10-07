using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewLibrary.Models;

[Table("Editorials")]
public class Editorial
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }


    [Column("Name")]
    public string Name { get; set; }

    [Column("Location")]
    public string Location { get; set; }

};

