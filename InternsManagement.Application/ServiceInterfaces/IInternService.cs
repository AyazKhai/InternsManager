using InternsManagement.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternsManagement.Application.ServiceInterfaces
{
    public interface IInternService
    {
        Task<InternDto> CreateAsync(CreateInternDto createintern);
        Task DeleteAsync(Guid id);
        Task<List<InternDto>> GetAllAsync();
        Task<InternDto?> GetByIdAsync(Guid id);
        Task<InternDto?> GetByEmailAsync(string email);
        Task<InternDto?> GetByPhoneNumberAsync(string phonenumber);
        Task<InternDto> UpdateInternAsync(Guid id, UpdateInternDto updateInternDto);
    }
}
