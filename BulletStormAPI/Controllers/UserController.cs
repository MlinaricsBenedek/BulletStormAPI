using BulletStormAPI.Dto;
using BulletStormAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulletStormAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost("registration")]
        public async Task<IActionResult> RegistrationAsync(UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("The data was not valid");
            }
            await _userService.CreateAsync(userDto);
            return Created();
        }
    }
}
