using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Entities;
using WebAPIDemo.DTO;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApidemoContext DBContext;
        public UserController(ApidemoContext dBContext)
        {
            DBContext = dBContext;
        }


        [HttpGet("GetUsers")]
        public async Task<ActionResult<List<UserDTO>>> Get()
        {
            var abc = await DBContext.Users.Select(
                s => new UserDTO
                {
                    Id = s.Id,
                    Firstname = s.Firstname,
                    Lastname = s.Lastname,
                    Userame = s.Userame,
                    Password = s.Password,
                    EnrollmentDate = s.EnrollmentDate
                }
            ).ToListAsync();


            if (abc.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return abc;
            }
        }

        [HttpPost("InsertUser")]
        public async Task<HttpStatusCode> InsertUser(UserDTO User)
        {
            var entity = new User()
            {
                Id = User.Id,
                Firstname = User.Firstname,
                Lastname = User.Lastname,
                Userame = User.Userame,
                Password = User.Password,
                EnrollmentDate = User.EnrollmentDate
            };
            DBContext.Users.Add(entity);
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.Created;
        }


        [HttpGet("GetUserById")]
        public async Task<ActionResult<UserDTO>> GetUserById(int Id)
        {
            UserDTO User = await DBContext.Users.Select(s => new UserDTO
            {
                Id = s.Id,
                Firstname = s.Firstname,
                Lastname = s.Lastname,
                Userame = s.Userame,
                Password = s.Password,
                EnrollmentDate = s.EnrollmentDate
            }).FirstOrDefaultAsync(s => s.Id == Id);
            if (User == null)
            {
                return NotFound();
            }
            else
            {
                return User;
            }
        }



        [HttpGet("GetUserByLastname")]
        public async Task<ActionResult<UserDTO>> GetUserByLastname(string lastname)
        {
            UserDTO User = await DBContext.Users.Select(s => new UserDTO
            {
                Id = s.Id,
                Firstname = s.Firstname,
                Lastname = s.Lastname,
                Userame = s.Userame,
                Password = s.Password,
                EnrollmentDate = s.EnrollmentDate
            }).FirstOrDefaultAsync(s => s.Lastname == lastname);
            if (User == null)
            {
                return NotFound();
            }
            else
            {
                return User;
            }
        }


        [HttpPut("UpdateUser")]
        public async Task<HttpStatusCode> UpdateUser(UserDTO User)
        {
            var entity = await DBContext.Users.FirstOrDefaultAsync(s => s.Id == User.Id);
            entity.Firstname = User.Firstname;
            entity.Lastname = User.Lastname;
            entity.Userame = User.Userame;
            entity.Password = User.Password;
            entity.EnrollmentDate = User.EnrollmentDate;
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }


        [HttpDelete("DeleteUser/{Id}")]
        public async Task<HttpStatusCode> DeleteUser(int Id)
        {
            var entity = new User()
            {
                Id = Id
            };
            DBContext.Users.Attach(entity);
            DBContext.Users.Remove(entity);
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}
