using InternsManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternsManagement.Domain.Interfaces
{
    public interface IDirectionRepository : IBaseRepository<InternshipDirection>
    {
        Task<InternshipDirection?> GetByNameAsync(string name);
    }
}
