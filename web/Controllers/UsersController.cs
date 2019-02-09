using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.Entities;
using web.Models.Users;

namespace web.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class UsersController : Controller
    {
        readonly MyDbContext _dbContext;
        readonly UserManager<IdentityUser> _userManager;

        public UsersController(MyDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userTasks = _userManager.Users
                .AsEnumerable()
                .Select(async x => new UserListItem {
                    UserName = x.UserName,
                    IsAdmin = await _userManager.IsInRoleAsync(x, Roles.Admin)
                });

            var users = await Task.WhenAll(userTasks);

            return View(users);
        } 
    }
}
