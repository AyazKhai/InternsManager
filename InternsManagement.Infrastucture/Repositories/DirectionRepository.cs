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
    public class DirectionRepository : IDirectionRepository
    {
        private readonly ApplicationDbContext _context;

        public DirectionRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task AddAsync(InternshipDirection entity)
        {
            if (entity is null) throw new ArgumentNullException($"Entity was null {nameof(entity)}");
            await _context.Directions.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var direction = await GetByIdAsync(id);
            if (direction is not null)
            {
                _context.Directions.Remove(direction);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<InternshipDirection>> GetAllAsync()
        {
            return await _context.Directions.Include(d => d.Projects).ToListAsync();
        }

        public async Task<InternshipDirection?> GetByIdAsync(Guid id)
        {
            return await _context.Directions.Include(d => d.Projects).FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<InternshipDirection?> GetByNameAsync(string name)
        {
            return await _context.Directions.Include(d => d.Projects).FirstOrDefaultAsync(e => e.Name == name);
        }

        public async Task UpdateAsync(InternshipDirection entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            _context.Directions.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
