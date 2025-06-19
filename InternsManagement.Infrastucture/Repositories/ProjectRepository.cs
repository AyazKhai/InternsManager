using InternsManagement.Domain.Entities;
using InternsManagement.Domain.Interfaces;
using InternsManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternsManagement.Infrastucture.Repositories
{
    public class ProjectRepository:IProjectRepository
    {
        private ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Project entity)
        {
            if (entity is null) throw new ArgumentNullException($"Entity was null {nameof(entity)}");
            await _context.Projects.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var project = await GetByIdAsync(id);
            if (project is not null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project?> GetByIdAsync(Guid id)
        {
            return await _context.Projects.FindAsync(id); 
        }

        public async Task<Project?> GetByNameAsync(string name)
        {
            return await _context.Projects.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task UpdateAsync(Project entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            _context.Projects.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
