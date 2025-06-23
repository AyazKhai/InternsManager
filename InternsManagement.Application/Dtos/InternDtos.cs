using InternsManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternsManagement.Application.Dtos
{
    public record CreateInternDto
    (
        [Required][StringLength(100)] string FirstName,
        [Required][StringLength(100)]string LastName,
        [Required]Gender Gender,
        [Required][EmailAddress]string? Email,  
        [Phone][RegularExpression(@"^\+7\d{10}$")]string PhoneNumber,
        [Required]DateTime DateOfBirth
    );

    public record UpdateInternDto
    (
        [Required][StringLength(100)] string FirstName,
        [Required][StringLength(100)] string LastName,
        [Required] Gender Gender,
        [Required][EmailAddress] string Email,
        [Phone][RegularExpression(@"^\+7\d{10}$")] string? PhoneNumber,
        [Required][DataType(DataType.Date)] DateTime DateOfBirth,
        [Required] Guid ProjectId
    );
    public record InternDto
    (
        Guid Id,
        string FirstName,
        string LastName,
        Gender Gender,
        string Email,
        string? PhoneNumber,
        DateTime DateOfBirth,
        //Guid DirectionId,
        //string DirectionName,
        //Guid ProjectId,
        //string ProjectTitle
        ProjectShortDto? ProjectShortDto
    );
    public record InternShortDto
    (
        Guid Id,
        string FirstName,
        string LastName,
        Gender Gender,
        string Email,
        string? PhoneNumber,
        DateTime DateOfBirth
    );
}
