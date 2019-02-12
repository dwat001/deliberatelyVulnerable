using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Entities
{
    public class Seeder
    {
        public MyDbContext _dbContext;

        public Seeder(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed() {
            _dbContext.Posts.AddRange(
                new Post { Html = "Hello world", Created = DateTimeOffset.Parse("2019-01-01 15:32:01+13") },
                new Post { Html = "This is some seed data", Created = DateTimeOffset.Parse("2019-01-01 15:33:04+13") },
                new Post { Html = "This should be recreated every time the application starts", Created = DateTimeOffset.Parse("2019-01-01 15:35:22+13") }
            );

            _dbContext.SaveChanges();
        }

    }
}
