using InternsManagement.Application.Dtos;
using InternsManagement.Application.ServiceInterfaces;
using InternsManagement.Domain.Interfaces;
using InternsManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternsManagement.Application.Extensions;
using InternsManagement.Application.CustoomExceptions;

namespace InternsManagement.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectrepository;
        private readonly IDirectionRepository _directionrepository;

        public ProjectService(IProjectRepository projectrepository, IDirectionRepository directionrepository)
        {
            _directionrepository = directionrepository;
            _projectrepository = projectrepository;
        }

        public async Task<ProjectDto> CreateAsync(CreateProjectDto Project)
        {
            if (await _projectrepository.GetByNameAsync(Project.Name) != null) 
            {
                throw new ConflictException("Имя проекта уже используется");
            }

            var direction = await _directionrepository.GetByIdAsync(Project.DirectionId);
            if (direction == null)
            {
                throw new NotFoundException("Указанное направление не найдено");
            }

            var project = new Project
            {
                Name = Project.Name,
                Description = Project.Descripton,
                DirectionId = Project.DirectionId
            };

            await _projectrepository.AddAsync(project);
            return project.AsDto();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = _projectrepository.GetByIdAsync(id);
            if (entity is null)
            {
                throw new NotFoundException("Проект не найден");
            }
            await _projectrepository.DeleteAsync(id);
        }

        public async Task<List<ProjectDto>> GetAllAsync()
        {
           var entities = await _projectrepository.GetAllAsync();
            return entities.Select(entity => entity.AsDto()).ToList();
        }

        public async Task<ProjectDto?> GetByIdAsync(Guid id)
        {
            var entity = await  _projectrepository.GetByIdAsync(id);
            if (entity is null) { return null; }
            return entity.AsDto();
        }

        public async Task<ProjectDto?> GetByNameAsync(string name)
        {
             var entity = await  _projectrepository.GetByNameAsync(name);
            if (entity is null) { return null; }
            return entity.AsDto();
        }

        public async Task<ProjectDto> UpdateProjectAsync(Guid id, UppdateProjectDto updateProjectDto)
        {
            var project = await _projectrepository.GetByIdAsync(id);
            if (project is null) 
            {
                throw new NotFoundException("Проект не неайден");
            }

            if (!string.IsNullOrEmpty(updateProjectDto.Name) && project.Name != updateProjectDto.Name) 
            {
                if (await _projectrepository.GetByNameAsync(updateProjectDto.Name) != null)
                {
                    throw new ConflictException("Имя проекта уже используется");
                }
            }

            if (project.DirectionId != updateProjectDto.DirectionId) 
            {
                if (await _directionrepository.GetByIdAsync(updateProjectDto.DirectionId) == null)
                    throw new NotFoundException("Указанное направление не найдено");
            }
         
            project.Name = updateProjectDto.Name;
            project.Description = updateProjectDto.Description;
            project.DirectionId = updateProjectDto.DirectionId;
            project.UpdatedAt = DateTime.UtcNow;

            await _projectrepository.UpdateAsync(project);

            return project.AsDto();
        }
    }
}
