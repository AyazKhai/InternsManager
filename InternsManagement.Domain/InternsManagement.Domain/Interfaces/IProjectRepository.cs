using InternsManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternsManagement.Domain.Interfaces
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        Task<Project?> GetByNameAsync(string name);
    }
}
