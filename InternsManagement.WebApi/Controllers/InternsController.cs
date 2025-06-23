using InternsManagement.Application.Dtos;
using InternsManagement.Application.ServiceInterfaces;
using InternsManagement.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace InternsManagement.WebApi.Controllers
{
    [ApiController]
    [Route("api/interns")]
    public class InternsController : ControllerBase
    {
        private readonly IInternService _internservice;

        public InternsController(IInternService internservice)
        {
            _internservice = internservice;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InternDto>>> GetAsync()
        {
            return await _internservice.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InternDto>> GetByIdAsync(Guid id) 
        {
            return await _internservice.GetByIdAsync(id);
        }

        [HttpGet("by-email/{email}")]
        public async Task<ActionResult<InternDto>> GetByEmailAsync(string email)
        {
            return await _internservice.GetByEmailAsync(email);
        }

        [HttpGet("by-phone/{phonenumber}")]
        public async Task<ActionResult<InternDto>> GetByPhoneNumberAsync(string phonenumber)
        {
            return await _internservice.GetByPhoneNumberAsync(phonenumber);
        }

        [HttpPost]
        public async Task<ActionResult<InternDto>> CreateAsync(CreateInternDto createInternDto)
        {
            var intern = await _internservice.CreateAsync(createInternDto);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = intern.Id }, intern);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateInternDto updateInternDto) 
        {
            await _internservice.UpdateInternAsync(id, updateInternDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id) 
        {
            await _internservice.DeleteAsync(id);
            return NoContent();
        }


    }
}
