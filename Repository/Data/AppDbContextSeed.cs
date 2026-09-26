using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class AppDbContextSeed
    {
        public static async Task SeedAsync(AppDbContext dbContext)
        {
            if (!dbContext.Categories.Any())
            {
                var CategorysData = File.ReadAllText("../Repository/Data/DataSeed/Categories.json");
                var Categorys = JsonSerializer.Deserialize<List<Category>>(CategorysData, new JsonSerializerOptions{ PropertyNameCaseInsensitive = true});
                if (Categorys?.Count > 0)
                {
                    foreach (var Category in Categorys)
                    {
                        await dbContext.Set<Category>().AddAsync(Category);
                    }
                    await dbContext.SaveChangesAsync();

                }
            }


            if (!dbContext.Users.Any())
            {

                var UsersData = File.ReadAllText("../Repository/Data/DataSeed/Users.json");
                var Users = JsonSerializer.Deserialize<List<User>>(UsersData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (Users?.Count > 0)
                {
                    foreach (var User in Users)
                    {
                        await dbContext.Set<User>().AddAsync(User);
                    }
                    await dbContext.SaveChangesAsync();

                }
            }


            if (!dbContext.Games.Any())
            {

                var GameData = File.ReadAllText("../Repository/Data/DataSeed/Games.json");
                var Games = JsonSerializer.Deserialize<List<Game>>(GameData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (Games?.Count > 0)
                {
                    foreach (var Game in Games)
                    {
                        await dbContext.Set<Game>().AddAsync(Game);
                    }
                    await dbContext.SaveChangesAsync();

                }
            }

            if (!dbContext.Reviews.Any())
            {

                var ReviewsData = File.ReadAllText("../Repository/Data/DataSeed/Reviews.json");
                var Reviews = JsonSerializer.Deserialize<List<Review>>(ReviewsData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (Reviews?.Count > 0)
                {
                    foreach (var Review in Reviews)
                    {
                        await dbContext.Set<Review>().AddAsync(Review);
                    }
                    await dbContext.SaveChangesAsync();

                }
            }

            


        }
    }
}
