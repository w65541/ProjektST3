using Microsoft.AspNetCore.Mvc;
using User.Api.Extensions;
using User.Api.Services;
using User.CrossCutting.Dtos;

namespace User.Api.Controllers
{
    [Route("/user")]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;
        public UserController(UserService service) { _service = service; }

        [HttpGet("get")]
        public async Task<IEnumerable<UserDto>> Read() =>  _service.Get();

        [HttpGet("get/{id}")]
        public async Task<IActionResult> ReadById(int id)
        {
            var Dto =  _service.GetById(id);

            if (Dto == null)
            {
                return NotFound();
            }

            return Ok(Dto);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] UserDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var operationResult =  _service.Create(dto);

            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var result = _service.Delete(id);
            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (updateDto == null)
            {
                return BadRequest("Invalid data.");
            }

            var dto = _service.GetById(id);
            if (dto == null)
            {
                return NotFound();
            }

            _service.Update(updateDto.ToEntity());

            return Ok();
        }
    }
}
