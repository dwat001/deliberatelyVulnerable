using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web.Entities;

namespace web.Controllers
{
    public class PostsController : Controller
    {
        readonly MyDbContext _dbContext;

        public PostsController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var posts = _dbContext.Posts.Take(25).ToList();

            return View(posts);
        }
    }
}