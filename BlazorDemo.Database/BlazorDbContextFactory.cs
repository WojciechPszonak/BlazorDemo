using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BlazorDemo.Database
{
    public class BlazorDbContextFactory : IDesignTimeDbContextFactory<BlazorDbContext>
    {
        public BlazorDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BlazorDbContext>();
            optionsBuilder.UseSqlServer("Data Source=localhost;Persist Security Info=True;User ID=SA;Password=DBpassword123");
            return new BlazorDbContext(optionsBuilder.Options);
        }
    }
}
