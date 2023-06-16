using Microsoft.AspNetCore.Mvc;
using RescueTeam.Models.Team;
using RescueTeam.Services;
using RescueTeam.Services.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RescueTeam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamWorkerService _service;

        public TeamController(ITeamWorkerService service)
        {
            _service = service;
        }



        //Get ALL
        [ProducesResponseType(typeof(List<TeamSimpleResponse>), 200)]
        [ProducesResponseType(typeof(InvalidOperationException), 500)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.ReadAll());
        }

        // GET api/<TeamController>/5
        [ProducesResponseType(typeof(TeamGetByIdResponse), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(InvalidOperationException), 500)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var associate = await _service.Read(id);
                return Ok(associate);
            }
            catch
            {
                return NotFound();
            }
        }
        // POST api/<TeamController>/5


        [HttpPost]
        public async Task<IActionResult> Post(TeamPostRequest team)
        {
            var postTeamResponse = await _service.Create(team);
            return CreatedAtAction(
                nameof(Get),
                new { ID = postTeamResponse.Id },
                postTeamResponse
            );
        }


        // put api/<TeamController>/5

        [ProducesResponseType(typeof(TeamPutResponse), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(InvalidOperationException), 500)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TeamPutRequest team)
        {
            try
            {
                return Ok(await _service.Update(id, team));
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<TeamController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.Delete(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
    }
}
