using BulletStormAPI.Dto;
using BulletStormAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulletStormAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;
        private readonly IMatchService _matchService;

        public StatisticsController(IStatisticsService statisticsRepository, IMatchService matchService)
        {
            _statisticsService = statisticsRepository;
            _matchService = matchService;
        }

        [HttpGet]
        public async Task<ActionResult<float>> GetAsync()
        {
            float elo = await _statisticsService.GetELOAsync();
            //if (elo is null)
            //{
            //    return BadRequest("The user doesnt have elo");
            //}
            return Ok(elo);
        }
    }
}
