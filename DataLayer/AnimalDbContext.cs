using System;
using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class AnimalDbContext:DbContext
    {
        public AnimalDbContext()
        {

        }
        public AnimalDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-L18INB7\SQLEXPRESS;Database=AnimalDB;Trusted_Connection=True");
            }
        }
        public DbSet<Diet> Diets { get; set; }

        public DbSet<Habitat> Habitats { get; set; }

        public DbSet<Species> Species { get; set; }
    }
}
