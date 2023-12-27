using Assignments.Dtos;
using Assignments.Models;

namespace Assignments.Services
{
    public interface IAssignmentService
    {
        Task<bool> CreateAssignment(AssignmentDTO assignment);
        Task<bool> UpdateAssignmentComplated(int IDAssignment);
        Task<IEnumerable<AssignmentDTO>> DeleteAssignment(int id);
        Task<AssignmentsListDTO> PageLoadAsync(int pageNumber, int pageSize);
        Task<AssignmentsListDTO> GetAllAssignments();
        Task<List<int>> GetIdAssignments();
        Task<AssignmentDTO> GetAssignmentById(int id);
        IEnumerable<string> GetAssignmentTypes();
    }
}
