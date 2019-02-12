using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Entities
{
    public class Seeder
    {
        readonly MyDbContext _dbContext;
        readonly UserManager<IdentityUser> _userManager;

        public Seeder(MyDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task Seed() {
            await SeedDatabase();
            await SeedUsers();
        }

        async Task SeedUsers()
        {
            await CreateUserWithPassword("admin", "admin");
        }

        async Task CreateUserWithPassword(string userName, string password)
        {
            
            var user = new IdentityUser
            {
                UserName = "admin"
            };

            var createResult = await _userManager.CreateAsync(user);
            if (createResult.Succeeded == false)
            {
                var exception = new InvalidOperationException("Failed to create user " + userName);
                exception.Data["Errors"] = createResult.Errors;
                throw exception;
            }

            var addPasswordResult = await _userManager.AddPasswordAsync(user, password);
            if (addPasswordResult.Succeeded == false)
            {
                var exception = new InvalidOperationException("Failed to set password for user " + userName);
                exception.Data["Errors"] = addPasswordResult.Errors;
                throw exception;
            }
        }

        async Task SeedDatabase()
        {
            await _dbContext.Posts.AddRangeAsync(
                new Post { Html = "Hello world", Created = DateTimeOffset.Parse("2019-01-01 15:32:01+13") },
                new Post { Html = "This is some seed data", Created = DateTimeOffset.Parse("2019-01-01 15:33:04+13") },
                new Post { Html = "This should be recreated every time the application starts", Created = DateTimeOffset.Parse("2019-01-01 15:35:22+13") }
            );

            await _dbContext.SaveChangesAsync();
        }
    }
}
