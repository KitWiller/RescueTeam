﻿using Microsoft.AspNetCore.Mvc;
using RescueTeam.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RescueTeam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController : ControllerBase
    {
        private readonly IMissionWorkerService _service;

        public MissionController(IMissionWorkerService service)
        {
            _service = service;
        }



        //Get ALL
        [ProducesResponseType(typeof(MissionGetAllResponse), 200)]
        [ProducesResponseType(typeof(InvalidOperationException), 500)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.ReadAll());
        }

           // GET api/<MissionController>/5
        [ProducesResponseType(typeof(MissionGetByIdResponse), 200)]
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

        [ProducesResponseType(typeof(MissionPutResponse), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(InvalidOperationException), 500)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, MissionPutRequest mission)
        {
            try
            {
                return Ok(await _service.Update(id, mission));
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


        // put api/<MissionController>/5

        [ProducesResponseType(typeof(MissionPutResponse), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(InvalidOperationException), 500)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, MissionPutRequest mission)
        {
            try
            {
                return Ok(await _service.Update(id, mission));
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

        // DELETE api/<MissionController>/5
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