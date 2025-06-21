using InternsManagement.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternsManagement.Application.ServiceInterfaces
{
    public interface IProjectService
    {
        Task<ProjectDto> CreateAsync(CreateProjectDto Project);
        Task DeleteAsync(Guid id);
        Task<List<ProjectDto>> GetAllAsync();
        Task<ProjectDto?> GetByIdAsync(Guid id);
        Task<ProjectDto?> GetByNameAsync(string name);
        Task<ProjectDto> UpdateProjectAsync(Guid id, UppdateProjectDto updateProjectDto);
    }
}
