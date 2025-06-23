using InternsManagement.Application.Dtos;
using InternsManagement.Application.ServiceInterfaces;
using InternsManagement.Application.Services;
using InternsManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InternsManagement.WebApi.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService) 
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetAsync() 
        {
            return await _projectService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDto>> GetByIdAsync(Guid id)
        {
            return await _projectService.GetByIdAsync(id);
        }

        [HttpGet("by-name/{name}")]
        public async Task<ActionResult<ProjectDto>> GetByNameAsync(string name)
        {
            return await _projectService.GetByNameAsync(name);
        }

        [HttpPost]
        public async Task<ActionResult<ProjectDto>> CreateAsync(CreateProjectDto projectDto) 
        {
            var project = await _projectService.CreateAsync(projectDto);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = project.Id }, project);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UppdateProjectDto uppdateProjectDto) 
        {
            await _projectService.UpdateProjectAsync(id, uppdateProjectDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _projectService.DeleteAsync(id);
            return NoContent();
        }
    }
}
