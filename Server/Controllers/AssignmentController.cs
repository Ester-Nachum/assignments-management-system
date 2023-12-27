using Assignments.Dtos;
using Assignments.Models;
using Assignments.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using System.Web.Http.Controllers;

namespace Assignments.Controllers
{
    public class AssignmentController : Controller
    {

        private IAssignmentService _assignmentService { get; set; }
        public AssignmentController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        //[HttpGet("Index")]
        //public ActionResult Index(int? page)
        //{
        //    var pageNumber = page ?? 1;
        //    var pageSize = 7; // Set your desired page size

        //    var query = new List<int>(); // Your data query here, e.g., fetching data from a database

        //    var pagedList = query.ToPagedList(pageNumber, pageSize);

        //    return View(pagedList);
        //}

        [HttpPost("createAssignment")]
        public async Task<IActionResult> CreateAssignment([FromBody]AssignmentDTO assignmentDTO)
        {
            if (assignmentDTO != null)
            {
                var result = await _assignmentService.CreateAssignment(assignmentDTO);
                if (result)
                    return Ok();
            }
            return BadRequest();
        }

        [HttpPost("DeleteAssignment")]
        public async Task<IActionResult> DeleteAssignment(int id)
        {
            var result = await _assignmentService.DeleteAssignment(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("GetAllAssignments")]
        public async Task<IActionResult> GetAllAssignments(int pageNumber, int pageSize)
        {
            var result = await _assignmentService.PageLoadAsync(pageNumber, pageSize);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("GetIdAssignments")]
        public async Task< IActionResult> GetIdAssignments()
        {
            var result = await _assignmentService.GetIdAssignments();
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpGet("GetAssignmentById")]
        public async Task<IActionResult> GetAssignmentById(int id)
        {
            var result = await _assignmentService.GetAssignmentById(id);
            if (result != null||result==null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("GetAssignmentTypes")]
        public IActionResult GetAssignmentTypes()
        {
            var result = _assignmentService.GetAssignmentTypes();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("UpdateAssignmentComplated")]
        public async Task<IActionResult> UpdateAssignmentComplated(int IDAssignment)
        {
            var result =await _assignmentService.UpdateAssignmentComplated(IDAssignment);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
