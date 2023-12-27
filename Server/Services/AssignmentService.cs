using Assignments.Data;
using Assignments.Dtos;
using Assignments.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Assignments.Services
{
    public class AssignmentService : IAssignmentService
    {
        private DataContext _context { get; set; }
        private int pageNumber { get; set; } = 1;
        private int pageSize { get; set; } = 10;
        public AssignmentService(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateAssignment(AssignmentDTO assignment)
        {
            Assignment newAssignment = new Assignment();
            newAssignment.AssignmentType = assignment.AssignmentType;
            newAssignment.Name = assignment.Name;
            newAssignment.Description = assignment.Description;
            newAssignment.StartDate = assignment.StartDate;
            newAssignment.EndDate = assignment.EndDate;
            newAssignment.IsRecurring = assignment.IsRecurring;
            newAssignment.IsCompleted = assignment.IsCompleted;
            newAssignment.IsActive = true;
            try
            {
                _context.Add(newAssignment);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                if (ex is SqlException)
                    return false;
                return false;
            }
        }

        public async Task<IEnumerable<AssignmentDTO>> DeleteAssignment(int id)
        {
            try
            {
                var assignment = await _context.Assignments.FindAsync(id);
                if (assignment != null)
                {
                    assignment.IsActive = false;
                    _context.Assignments.Update(assignment);
                    _context.SaveChanges();
                    var updateAssignments = await PageLoadAsync(pageNumber, pageSize);
                    return updateAssignments.Assignments;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<AssignmentsListDTO> PageLoadAsync(int pageNumber, int pageSize)
        {
            this.pageNumber = pageNumber;
            this.pageSize = pageSize;

            var query = await GetAllAssignments();
            var pagedList = query.Assignments.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList(); // Your data query here, e.g., fetching data from a database
            query.Assignments = pagedList;
            return query;
            //var pagedList = query.ToPagedList(pageNumber, pageSize);
            //return View(pagedList);
        }
        public async Task<AssignmentsListDTO> GetAllAssignments()
        {
            var query = await _context.Assignments
                .Where(a => a.IsActive)
                .OrderByDescending(d => d.StartDate)
                .Select(a => new AssignmentDTO
                {
                    AssignmentType = a.AssignmentType,
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    StartDate = a.StartDate,
                    EndDate = a.EndDate,
                    IsRecurring = a.IsRecurring,
                    IsCompleted = a.IsCompleted
                }).ToListAsync();

            var assignmentsList = new AssignmentsListDTO();
            assignmentsList.Count = query.Count;
            assignmentsList.Assignments = new List<AssignmentDTO>();
            assignmentsList.Assignments = query;

            return assignmentsList;
        }

        public async Task<List<int>> GetIdAssignments()
        {
            var idAssignments = await GetAllAssignments();
            return idAssignments.Assignments.Select(a => a.Id).ToList();
        }

        public async Task<AssignmentDTO> GetAssignmentById(int id)
        {
            try
            {
                var assignment = await _context.Assignments
                                .Where(a => a.IsActive && a.Id == id)
                                .Select(a => new AssignmentDTO
                                {
                                    AssignmentType = a.AssignmentType,
                                    Id = a.Id,
                                    Name = a.Name,
                                    Description = a.Description,
                                    StartDate = a.StartDate,
                                    EndDate = a.EndDate,
                                    IsRecurring = a.IsRecurring,
                                    IsCompleted = a.IsCompleted
                                }).FirstOrDefaultAsync();

                return assignment;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<string> GetAssignmentTypes()
        {
            var assignmentTypes = Enum.GetNames(typeof(AssignmentType));
            return assignmentTypes;
        }

        public async Task<bool> UpdateAssignmentComplated(int IDAssignment)
        {
            try
            {
                var existingAssignment = await _context.Assignments.FindAsync(IDAssignment);

                if (existingAssignment != null)
                {
                    existingAssignment.IsCompleted = true;
                    var e = _context.Assignments.Update(existingAssignment);
                    await _context.SaveChangesAsync();

                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
