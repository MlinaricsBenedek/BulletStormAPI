using BulletStormAPI.Dto;
using BulletStormAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulletStormAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _matchService;
        private readonly IResultService _resultService;

        public MatchController(IMatchService matchService, IResultService resultService)
        {
            _matchService = matchService;
            _resultService = resultService; 
        }

        [HttpGet]
        public async Task<ActionResult<int>> GetAsync()
        {
            return Ok(await _resultService.MatchCountAsync());
        }

        [HttpPost]
        public async Task CreateAsync(MatchResultClientDto matchResultDto)
        {
            await _matchService.CreateAsync(matchResultDto);
        }

        [HttpPut]
        public async Task UpdateAsync(MatchResultClientDto resulClientDto)
        {
            await _matchService.UpdateAsync(resulClientDto);
        }
    }
}
