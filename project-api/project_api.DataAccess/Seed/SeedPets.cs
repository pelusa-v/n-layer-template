using Microsoft.EntityFrameworkCore;
using project_api.Core.Entities;
using project_api.DataAccess;

namespace project_api;


public class SeedPets
{
    public static void Initialize(IServiceProvider serviceProvider, IConfiguration configuration)
    {
        using (var context = new AppDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
        {
            if (!context.Pets.Any())
            {
                context.Pets.AddRange(
                    new Pet
                    {
                        Id = 1,
                        Name = "Bob",
                    },
                    new Pet
                    {
                        Id = 2,
                        Name = "Perry",
                    },
                    new Pet
                    {
                        Id = 3,
                        Name = "Tom",
                    },
                    new Pet
                    {
                        Id = 4,
                        Name = "Curly",
                    },
                    new Pet
                    {
                        Id = 5,
                        Name = "Eddie",
                    }
                );
            }

            context.SaveChanges();
        }
    }
}
