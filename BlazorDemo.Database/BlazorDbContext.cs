using BlazorDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorDemo.Database
{
    public class BlazorDbContext : DbContext
    {
        public DbSet<Answer> Answers { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Survey> Surveys { get; set; }

        public BlazorDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
