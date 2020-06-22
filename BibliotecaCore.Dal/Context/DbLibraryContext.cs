using BibliotecaCore.Dal.Entities;
using BibliotecaCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BibliotecaCore.Dal.Context
{
    public class DbLibraryContext : DbContext
    {
        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Category> Category { get; set; }

        public DbLibraryContext(DbContextOptions<DbLibraryContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=.;database=DbLibrary;trusted_connection=true;");
        //}

    }
    
}
