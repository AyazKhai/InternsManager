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
            return new InternDto(intern.Id, intern.FirstName, intern.LastName, intern.Gender, 
                intern.Email, intern.PhoneNumber, intern.DateOfBirth,
                new ProjectDto(intern.Project.Id, intern.Project.Name, intern.Project.Description),
                new DirectionDto(intern.Direction.Id, intern.Direction.Name, intern.Direction.Description));
        }

        public static ProjectDto AsDto(this Project project) 
        {
            return new ProjectDto(project.Id, project.Name, project.Description);
        }

        public static DirectionDto AsDto(this InternshipDirection direction) 
        {
            return new DirectionDto(direction.Id, direction.Name, direction.Description);
        } 
    }
}
