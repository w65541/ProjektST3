using Microsoft.AspNetCore.Mvc;
using Profil.Api.Services;
using Profil.CrossCutting.Dtos;

namespace Profil.Api.Controllers
{
    [Route("/profile")]
    public class ProfilController : ControllerBase
    {
        private readonly ProfilServices _service;
        public ProfilController(ProfilServices service) { _service = service; }

        [HttpGet("get")]
        public async Task<IEnumerable<ProfileDto>> Read() => await _service.Get();

        [HttpGet("get/{id}")]
        public async Task<IActionResult> ReadById(int id)
        {
            var Dto = _service.GetById(id);

            if (Dto == null)
            {
                return NotFound();
            }

            return Ok(Dto);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ProfileDto dto)
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
        public async Task<IActionResult> Update(int id, [FromBody] ProfileDto updateDto)
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

            var operationResult = _service.Update(id, updateDto);

            return Ok();
        }
    }
}
