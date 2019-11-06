using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1.EF
{
    public class MainInfoContext : DbContext
    {
        public DbSet<Object> Info { get; set; }

        public MainInfoContext(DbContextOptions<MainInfoContext> options)
            : base(options)
        {
        }
    }

    public class MainInfoContextSeed
    {
        
        public static async Task SeedAsync(MainInfoContext context)
        {
            UseRealDataBase(context);
            //OR:
            //UseTestDataBase(context);

            if (!context.Info.Any())
            {
                context.Info.AddRange(GetPreconfiguredAny());
            }

            await context.SaveChangesAsync();
        }

        private static IEnumerable<Object> GetPreconfiguredAny()
        {
            return new List<Object>
            {
                new Object()
                {
                    Id = 70002234,
                    Name = "vasia"
                }
            };
        }

        private static void UseRealDataBase(MainInfoContext context)
        {
            context.Database.Migrate();
        }
        
        private static void UseTestDataBase(MainInfoContext context)
        {
            context.Database.EnsureDeleted();
            // the database that is created cannot be later updated using migrations.
            context.Database.EnsureCreated();
        }

    }
}