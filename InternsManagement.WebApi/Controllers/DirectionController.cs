using InternsManagement.Application.Dtos;
using InternsManagement.Application.ServiceInterfaces;
using InternsManagement.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace InternsManagement.WebApi.Controllers
{
    [ApiController]
    [Route("api/direction")]
    public class DirectionController:ControllerBase
    {
        private readonly IDirectionService _directionService;
        public DirectionController(IDirectionService directionService) 
        {
            _directionService = directionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DirectionDto>>> GetAsync() 
        {
            return await _directionService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DirectionDto>> GetByIdAsync(Guid id) 
        {
            return await _directionService.GetByIdAsync(id);
        }

        [HttpGet("by-name/{name}")]
        public async Task<ActionResult<DirectionDto>> GetByNameAsync(string name)
        {
            return await _directionService.GetByNameAsync(name);
        }

        [HttpPost]
        public async Task<ActionResult<DirectionDto>> CreateAsync(CreateDirectionDto directionDto) 
        {
            var direction = await _directionService.CreateAsync(directionDto);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = direction.id }, direction);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateDirectionDto updateDirectionDto) 
        {
            await _directionService.UpdateDirectionAsync(id, updateDirectionDto);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _directionService.DeleteAsync(id);
            return NoContent();
        }

    }
}
