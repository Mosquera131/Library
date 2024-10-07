using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewLibrary.Models;
using NewLibrary.Seeders;

namespace NewLibrary.Data;



public class ApplicationDbContext : DbContext
{
    public DbSet<Author> Authors { get; set; }

    public DbSet<Book> Books { get; set; }

    public DbSet<Editorial> Editorials { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Genre> Genres { get; set; }

    public DbSet<DocumentType> DocumentTypes { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<Loan> Loans { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        RolesSeeder.Seeder(modelBuilder);
        DocumentTypeSeeder.Seeder(modelBuilder);

    }

}


