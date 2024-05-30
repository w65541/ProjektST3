using ExternalUser.Api.Services;
using ExternalUser.CrossCutting.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExternalUser.Api.Controllers
{
    [Route("/externalUser")]
    public class ExternalUserController : ControllerBase
    {
        private readonly ExternalUserServices _service;
        public ExternalUserController(ExternalUserServices service) { _service = service; }

        [HttpGet("get")]
        public async Task<IEnumerable<ExternalUserDto>> Read() => await _service.Get();

        [HttpGet("get/{id}")]
        public async Task<IActionResult> ReadById(int id)
        {
            var Dto = await _service.GetById(id);

            if (Dto == null)
            {
                return NotFound();
            }

            return Ok(Dto);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ExternalUserDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var operationResult = await _service.Create(dto);

            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var result = await _service.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok();
        }


        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ExternalUserDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (updateDto == null)
            {
                return BadRequest("Invalid data.");
            }

            var dto = await _service.GetById(id);
            if (dto == null)
            {
                return NotFound();
            }

            var operationResult = await _service.Update(id, updateDto);

            return Ok();
        }
    }
}
