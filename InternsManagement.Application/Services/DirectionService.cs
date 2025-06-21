using InternsManagement.Application.CustoomExceptions;
using InternsManagement.Application.Dtos;
using InternsManagement.Application.Extensions;
using InternsManagement.Application.ServiceInterfaces;
using InternsManagement.Domain.Entities;
using InternsManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternsManagement.Application.Services
{
    public class DirectionService : IDirectionService
    {
        private readonly IDirectionRepository _repository;

        public DirectionService(IDirectionRepository repository)
        {
            _repository = repository;
        }

        public async Task<DirectionDto> CreateAsync(CreateDirectionDto direction)
        {
            if (string.IsNullOrEmpty(direction.Name))
            {
                throw new InvalidOperationException("Невозможное имя");
            }

            if (await _repository.GetByNameAsync(direction.Name) != null)
            {
                throw new ConflictException("Имя проекта уже используется");
            }

            var newdirection = new InternshipDirection
            {
                Name = direction.Name,
                Description = direction.Description
            };
            await _repository.AddAsync(newdirection);
            return newdirection.AsDto();

        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = _repository.GetByIdAsync(id);
            if (entity is null)
            {
                throw new NotFoundException("Проект не найден");
            }
            await _repository.DeleteAsync(id);
        }

        public async Task<List<DirectionDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(entity => entity.AsDto()).ToList();
        }

        public async Task<DirectionDto?> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity is null) { return null; }
            return entity.AsDto();
        }

        public async Task<DirectionDto?> GetByNameAsync(string name)
        {
            var entity = await _repository.GetByNameAsync(name);
            if (entity is null) { return null; }
            return entity.AsDto();
        }

        public async Task<DirectionDto> UpdateDirectionAsync(Guid id, UpdateDirectionDto updateDirectionDto)
        {
            var direction = await _repository.GetByIdAsync(id);
            if (direction is null)
            {
                throw new NotFoundException("Проект не неайден");
            }

            if (string.IsNullOrEmpty(updateDirectionDto.Name))
            {
                throw new InvalidOperationException("Невозможное имя");
            }

            if (!string.IsNullOrEmpty(updateDirectionDto.Name) && direction.Name != updateDirectionDto.Name)
            {
                if (await _repository.GetByNameAsync(updateDirectionDto.Name) != null)
                {
                    throw new ConflictException("Имя проекта уже используется");
                }
            }

            direction.Name = updateDirectionDto.Name; 
            direction.Description = updateDirectionDto.Description;
            direction.UpdatedAt = DateTime.Now;

            await _repository.UpdateAsync(direction);
            return direction.AsDto();
        }
    }
}
