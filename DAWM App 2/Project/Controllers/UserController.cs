using Core.Dtos;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class UserController : Controller
    {
        private UserService userService { get; set; }


        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("/register")]
        public IActionResult Add(UserAddDto payload)
        {
            var result = userService.RegisterUser(payload);

            if (result == null)
            {
                return BadRequest("User cannot be added");
            }

            return Ok(result);
        }

        [HttpGet("/login")]
        public IActionResult Login(UserLoginDto payload)
        {
            var result = userService.LoginUser(payload);

            if (result == false)
            {
                return BadRequest("User does not exist");
            }

            return Ok("You logged in!");
        }
    }
}
