using Microsoft.AspNetCore.Mvc;
using RescueTeam.Models.TeamMember;
using RescueTeam.Services;
using RescueTeam.Services.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RescueTeam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMemberController : ControllerBase
    {

        //dependency injection, injecto il servizio
        private readonly ITeamMemberWorkerService _service;

        public TeamMemberController(ITeamMemberWorkerService service)
        {
            _service = service;
        }
        //ed ora usi il servizio injectato
        //convenzione REST, ritorna statuscode E TUTTI ASYNC

        //Get ALL
        [ProducesResponseType(typeof(List<TeamMemberSimpleResponse>),200)]
        [ProducesResponseType(typeof(InvalidOperationException), 500)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.ReadAll());
        }

        // GET api/<TeamMemberController>/5
        [ProducesResponseType(typeof(TeamMemberGetByIdResponse), 200)]
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

        // POST api/<TeamMemberController>
        [HttpPost]
        public async Task<IActionResult> Post(TeamMemberPostRequest teamMember)
        {
            var postTeamMemberResponse = await _service.Create(teamMember);
            return CreatedAtAction(
            nameof(Get),
                new {ID = postTeamMemberResponse.Id},
                    postTeamMemberResponse
            );
        }

        // put api/<TeamController>/5

        [ProducesResponseType(typeof(TeamMemberPutResponse), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(InvalidOperationException), 500)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TeamMemberPutRequest teamMember)
        {
            try
            {
                return Ok(await _service.Update(id, teamMember));
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

        // DELETE api/<TeamMemberController>/5
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
