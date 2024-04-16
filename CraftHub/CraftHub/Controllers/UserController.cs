using CraftHub.Areas.Admin.Controllers;
using CraftHub.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CraftHub.Controllers
{
    public class UserController : AdminBaseController
    {

        private readonly IUserService _users;
        public UserController(IUserService users)
        {
            _users = users;
        }

        [Route("User/All")]
        public async Task<IActionResult>All()
        {
            var users = await _users.AllAsync();

            return View(users);
        }
    }
}
