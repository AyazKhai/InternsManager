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
    public class InternService : IInternService
    {
        private readonly IInternRepository _internRepository;
        //private readonly IDirectionRepository _directionRepository;
        //private readonly IProjectRepository _projectRepository;


        public InternService(IInternRepository internRepository)
        {
            _internRepository = internRepository;
        }

        public async Task<InternDto> CreateAsync(CreateInternDto createintern)
        {

            if (await _internRepository.GetByEmailAsync(createintern.Email!) != null)
                throw new InvalidOperationException("Email уже используется");

            if (!string.IsNullOrEmpty(createintern.PhoneNumber))
            {
                if (await _internRepository.GetByPhoneNumberAsync(createintern.PhoneNumber) != null)
                    throw new InvalidOperationException("Телефон уже используется");
            }


            var intern = new Intern
            {
                FirstName = createintern.FirstName,
                LastName = createintern.LastName,
                Gender = createintern.Gender,
                Email = createintern.Email!,
                PhoneNumber = createintern.PhoneNumber,
                DateOfBirth = createintern.DateOfBirth,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _internRepository.AddAsync(intern);
            return intern.AsDto();
        }

        public async Task DeleteAsync(Guid id)
        {
            var intern = await _internRepository.GetByIdAsync(id);
            if (intern is null)
                ы

            await _internRepository.DeleteAsync(id);
        }

        public async Task<List<InternDto>> GetAllAsync()
        {
            var interns = await _internRepository.GetAllAsync();
            return interns.Select(intern => intern.AsDto()).ToList();
        }

        public async Task<InternDto?> GetByEmailAsync(string email)
        {
            var intern = await _internRepository.GetByEmailAsync(email);

            if (intern is null) { return null; }
            return intern.AsDto();
        }

        public async Task<InternDto?> GetByIdAsync(Guid id)
        {
           var intern = await _internRepository.GetByIdAsync(id);

            if (intern is null) { return null; }
            return intern.AsDto();
        }

        public async Task<InternDto?> GetByPhoneNumberAsync(string phonenumber)
        {
            var intern = await _internRepository.GetByPhoneNumberAsync(phonenumber);

            if (intern is null) { return null; }
            return intern.AsDto();
        }

        public async Task<InternDto> UpdateInternAsync(Guid id, UpdateInternDto updateInternDto)
        {
            var intern = await _internRepository.GetByIdAsync(id);
            if (intern is null) 
            {
                throw new NotFoundException("Стажер не найден");
            }

            if (updateInternDto.Email != intern.Email) 
            {
                if (await _internRepository.GetByEmailAsync(updateInternDto.Email) != null)
                    throw new ConflictException("Email уже используется");
            }

            if (!string.IsNullOrEmpty(updateInternDto.PhoneNumber) && intern.PhoneNumber != updateInternDto.PhoneNumber)
            {
                if (await _internRepository.GetByPhoneNumberAsync(updateInternDto.PhoneNumber!) != null)
                    throw new ConflictException("Телефон уже используется");
            }

            intern.FirstName = updateInternDto.FirstName;
            intern.LastName = updateInternDto.LastName;
            intern.Gender = updateInternDto.Gender;
            intern.Email = updateInternDto.Email;
            intern.PhoneNumber = updateInternDto.PhoneNumber;
            intern.DateOfBirth = updateInternDto.DateOfBirth;
            intern.DirectionId = updateInternDto.DirectionId;
            intern.ProjectId = updateInternDto.ProjectId;
            intern.UpdatedAt = DateTime.UtcNow;

            await _internRepository.UpdateAsync(intern);

            var updatedIntern = await _internRepository.GetByIdAsync(intern.Id);
            if (updatedIntern is null)
                throw new Exception("Ошибка при получении обновленного стажера");

            return updatedIntern.AsDto();
        }
    }
}
