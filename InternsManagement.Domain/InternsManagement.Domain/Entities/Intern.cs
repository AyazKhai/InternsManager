using InternsManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InternsManagement.Domain.Entities
{
    public class Intern : BaseEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public Gender Gender { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Guid? DirectionId { get; set; }
        public InternshipDirection? Direction { get; set; } = null!;

        public Guid? ProjectId { get; set; }
        public Project? Project { get; set; } = null!;
    }
}
