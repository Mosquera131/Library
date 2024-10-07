using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewLibrary.Models;

namespace NewLibrary.Seeders;

    public class DocumentTypeSeeder
    {
        public static void Seeder (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocumentType>().HasData(
                new DocumentType{Id=1, Name="T.I"},
                new DocumentType{Id=2, Name="C.C"},
                new DocumentType{Id=3, Name="PassPort"}
            );
        }
    }
    
