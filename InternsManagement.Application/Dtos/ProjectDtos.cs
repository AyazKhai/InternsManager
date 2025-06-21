using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternsManagement.Application.Dtos
{
    public record CreateProjectDto(
        [Required][StringLength(200)]string Name, 
        string? Descripton
        );
    public record UppdateProjectDto(
        [Required][StringLength(200)] string Name, 
        string? Description
        );

    public record ProjectDto(Guid Id, 
        string Name, 
        string? Description
        );
}
