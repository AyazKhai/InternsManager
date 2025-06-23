using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternsManagement.Domain.Entities
{
    public class Project : BaseEntity
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public ICollection<Intern>? Interns { get; set; } = new List<Intern>();
        public Guid DirectionId { get; set; }
        public InternshipDirection Direction { get; set; } = null!;
    }
}
