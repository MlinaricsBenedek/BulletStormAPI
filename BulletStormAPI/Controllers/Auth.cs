using BulletStormAPI.Dto;
using BulletStormAPI.Model;
using BulletStormAPI.Services;
using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult<UserEloDto>> GetAsync(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            { 
                return BadRequest(ModelState);
            }
            return Ok(await userService.GetAsync(loginDto));    
        }
    }
}
