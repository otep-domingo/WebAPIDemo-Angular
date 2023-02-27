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
    public class StudentsController : ControllerBase
    {
        private readonly ApidemoContext DBContext;

        public StudentsController(ApidemoContext dBContext)
        {
            DBContext = dBContext;
        }
        [HttpGet("GetStudents")]
        public async Task<ActionResult<List<Student>>> Get()
        {
            var students = await DBContext.Student.ToListAsync();
            return students;
        }

        [HttpGet("GetStudentById/{id}")]
        public async Task<ActionResult<StudentDTO>> GetStudentById(int id)
        {
            StudentDTO s = await DBContext.Student.Select(a => new StudentDTO
            {
                Id = a.Id,
                StudentId = a.StudentId,
                Lastname = a.Lastname,
                Firstname = a.Firstname,
                DateEnrolled = a.DateEnrolled,
                Course = a.Course

            }).FirstOrDefaultAsync(a=>a.Id == id);

            if(s == null)
            {
                return NotFound();
            }
            else
            {
                return s;
            }

        }

        [HttpPost("InsertStudent")]
        public async Task<HttpStatusCode> InsertStudent(Student s)
        {
            var x = DBContext.Student.FirstOrDefault(a => a.StudentId == s.StudentId);


            if (x != null)
            {
                //return HttpStatusCode.Conflict;
                throw new Exception("Ooops! Duplicate Record.");
            }
            else
            {
                //insert to the database
                DBContext.Student.Add(s);
                await DBContext.SaveChangesAsync();
                return HttpStatusCode.OK;
            }
        }

        [HttpPut("UpdateStudent/{id}")]
        public async Task<HttpStatusCode> UpdateStudent(int id,StudentDTO sDTO)
        {
            var e = await DBContext.Student.FirstOrDefaultAsync(a => a.Id ==id);
            e.StudentId = sDTO.StudentId;
            e.Lastname = sDTO.Lastname;
            e.Firstname = sDTO.Firstname;
            e.Course = sDTO.Course;
            e.DateEnrolled = DateTime.Now;
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.Accepted;
        }
        [HttpDelete("DeleteStudent/{id}")]
        public async Task<HttpStatusCode> DeleteStudent(int id)
        {
            var e = new Student()
            {
                Id = id
            };
            DBContext.Student.Attach(e);
            DBContext.Student.Remove(e);
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}
