using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewLibrary.Models;

namespace NewLibrary.Seeders;

    public class RolesSeeder:ModelBuilder
    {
        public static void Seeder (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role {Id=1, Name="Admin"},
                new Role {Id=2, Name="Client"}
            );
        }
    }
