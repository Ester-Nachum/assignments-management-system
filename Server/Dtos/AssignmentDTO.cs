using Assignments.Models;

namespace Assignments.Dtos
{
    public class AssignmentDTO
    {
        public int Id { get; set; }
        public AssignmentType AssignmentType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsRecurring { get; set; }
        public bool IsCompleted { get; set; }
    }
}
