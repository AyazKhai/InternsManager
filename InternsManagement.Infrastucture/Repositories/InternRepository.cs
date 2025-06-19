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
    public class InternRepository : IInternRepository
    {
        private readonly ApplicationDbContext _context;

        public InternRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Intern entity)
        {
            if (entity is null) throw new ArgumentNullException($"Entity was null {nameof(entity)}");
            await _context.Interns.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var intern = await GetByIdAsync(id);
            if (intern is not null) 
            {
                _context.Interns.Remove(intern);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Intern>> GetAllAsync()
        {
            return await _context.Interns.ToListAsync();
        }

        public async Task<Intern?> GetByEmailAsync(string email)
        {
            return await _context.Interns.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<Intern?> GetByIdAsync(Guid id)
        {
            return await _context.Interns.FindAsync(id);
        }

        public async Task<Intern?> GetByPhoneNumberAsync(string phoneNumber)
        {
            return await _context.Interns.FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);
        }

        public async Task UpdateAsync(Intern entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            _context.Interns.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
