using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieLib.Models;

namespace MovieLib.Data
{
    public class ModelsContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=models.db");
        }

        public DbSet<MovieModel> Movies { get; set; }
    }
}
