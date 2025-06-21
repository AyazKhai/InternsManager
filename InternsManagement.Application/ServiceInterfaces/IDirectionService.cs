using InternsManagement.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternsManagement.Application.ServiceInterfaces
{
    public interface IDirectionService
    {
        Task<DirectionDto> CreateAsync(CreateDirectionDto direction);
        Task DeleteAsync(Guid id);
        Task<List<DirectionDto>> GetAllAsync();
        Task<DirectionDto?> GetByIdAsync(Guid id);
        Task<DirectionDto?> GetByNameAsync(string name);
        Task<DirectionDto> UpdateDirectionAsync(Guid id, UpdateDirectionDto updateDirectionDto);
    }
}
