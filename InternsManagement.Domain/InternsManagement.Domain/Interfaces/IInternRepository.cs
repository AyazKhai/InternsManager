using InternsManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternsManagement.Domain.Interfaces
{
    public interface IInternRepository : IBaseRepository<Intern>
    {
        Task<Intern?> GetByEmailAsync(string email);
        Task<Intern?> GetByPhoneNumberAsync(string phoneNumber);

    }
}
