using Microsoft.EntityFrameworkCore;
using RecipesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesAPI.DBContexts
{
    public class RecipesDbContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }

        public RecipesDbContext(DbContextOptions<RecipesDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>()
                .Property(r => r.CreatedAt)
                .HasDefaultValueSql("NOW()");
            modelBuilder.Entity<Recipe>()
               .Property(r => r.UpdatedAt)
               .HasDefaultValueSql("NOW()");
        }

    }
}
