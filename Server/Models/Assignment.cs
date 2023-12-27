using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignments.Models
{
    public enum AssignmentType { Personal,Work,Study}
    public class Assignment
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public AssignmentType AssignmentType { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsRecurring { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsActive { get; set; }
    }
}