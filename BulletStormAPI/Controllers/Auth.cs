using BulletStormAPI.Dto;
using BulletStormAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BulletStormAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Auth : ControllerBase
    {
        private readonly IUserService userService;

        public Auth(IUserService _userService)
        {
            userService = _userService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> GetAsync(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var token = await userService.LoginAsync(loginDto);
            if (token is null)
            {
                return BadRequest("The user doesn't exist");
            }
            return Ok(new { token = token });
        }
    }
}
