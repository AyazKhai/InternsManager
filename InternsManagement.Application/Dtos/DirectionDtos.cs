using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternsManagement.Application.Dtos
{
    public record DirectionDto(
        Guid id, 
        string Name, 
        string? Description,
        IEnumerable<ProjectShortDto> ProjectsShorts
        );

    public record CreateDirectionDto(
        [Required][StringLength(200)] string Name, 
        string? Description
        );
    public record UpdateDirectionDto(
        [Required][StringLength(200)] string Name,
        string? Description
        );

}
