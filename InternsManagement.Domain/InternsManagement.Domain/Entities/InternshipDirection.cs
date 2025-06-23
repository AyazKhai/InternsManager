using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternsManagement.Domain.Entities
{
    public class InternshipDirection : BaseEntity
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }
        public ICollection<Project>? Projects { get; set; } = new List<Project>();
    }
}
