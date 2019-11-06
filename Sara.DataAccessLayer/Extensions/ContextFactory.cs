using ClassLibrary1.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ClassLibrary1.Extensions
{
    public class ContextFactory: IDesignTimeDbContextFactory<MainInfoContext>
    {
        public MainInfoContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MainInfoContext>();
            optionsBuilder.UseNpgsql("Data Source=sarapostrges.db");

            return new MainInfoContext(optionsBuilder.Options);
        }
    }
}