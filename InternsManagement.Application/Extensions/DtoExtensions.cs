using InternsManagement.Application.Dtos;
using InternsManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternsManagement.Application.Extensions
{
    public static class DtoExtensions
    {
        public static InternDto AsDto(this Intern intern) 
        {
            return new InternDto(
                intern.Id,
                intern.FirstName,
                intern.LastName,
                intern.Gender,
                intern.Email,
                intern.PhoneNumber,
                intern.DateOfBirth,
                intern.Project?.AsShortDto()
            );
          
        }

        public static InternShortDto AsShortDto(this Intern intern)
        {
            return new InternShortDto(
                intern.Id,
                intern.FirstName,
                intern.LastName,
                intern.Gender,
                intern.Email,
                intern.PhoneNumber,
                intern.DateOfBirth
                );
        }

        public static ProjectDto AsDto(this Project project) 
        {
            var interns = project.Interns.Select( x => x.AsShortDto());

            return new ProjectDto(
                project.Id,
                project.Name,
                project.Description,
                project.Direction?.Id,
                project.Direction?.Name,
                interns
            );
        }

        public static ProjectShortDto AsShortDto(this Project project) 
        {
            return new ProjectShortDto(
                project.Id,
                project.Name,
                project.Description,
                project.Direction?.Id,
                project.Direction?.Name
            );
        }


        public static DirectionDto AsDto(this InternshipDirection direction) 
        {
            var projectsDto = direction.Projects.Select(p => p.AsShortDto());

            return new DirectionDto(
                direction.Id,
                direction.Name,
                direction.Description,
                projectsDto
            );
        } 
    }
}
