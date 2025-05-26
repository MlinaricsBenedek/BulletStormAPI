using BulletStormAPI.Model;
using BulletStormAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulletStormAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GlobalStatisticsController : ControllerBase
    {
        private readonly IGlobalStatisticsService _globalStatisticsService;

        public GlobalStatisticsController(IGlobalStatisticsService globalStatisticsService)
        {
            _globalStatisticsService = globalStatisticsService;
        }

        [HttpGet]
        public async Task<ActionResult<Global>> GetAsync(int id = 1)
        {
            var global = await _globalStatisticsService.GetAsync(id);
            return Ok(global);
        }

        [HttpPost]
        public async Task<ActionResult> CreatedAsync(Global global)
        {
            await _globalStatisticsService.CreateAsync(global);

            return Created();
        }

        [HttpPut]
        public async Task<ActionResult> UpdatedAsync(Global global)
        {
            await _globalStatisticsService.UpdateAsync(global);
            return Ok();
        }
    }
}
