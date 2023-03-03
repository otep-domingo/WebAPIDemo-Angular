using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIDemo.Entities;
using WebAPIDemo.DTO;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ApidemoContext DBContext;

        public CoursesController(ApidemoContext dBContext)
        {
            DBContext = dBContext;
        }
        [HttpGet("GetCourses")]
        public async Task<ActionResult<List<Course>>> Get()
        {
            var courses = await DBContext.Course.ToListAsync();
            return courses;
        }

        //[HttpGet("GetStudentById/{id}")]
        //public async Task<ActionResult<StudentDTO>> GetStudentById(int id)
        //{
        //    StudentDTO s = await DBContext.Student.Select(a => new StudentDTO
        //    {
        //        Id = a.Id,
        //        StudentId = a.StudentId,
        //        Lastname = a.Lastname,
        //        Firstname = a.Firstname,
        //        DateEnrolled = a.DateEnrolled,
        //        Course = a.Course

        //    }).FirstOrDefaultAsync(a=>a.Id == id);

        //    if(s == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        return s;
        //    }

        //}

        
    }
}
