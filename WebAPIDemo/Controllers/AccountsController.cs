using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAPIDemo.Entities;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ApidemoContext _context;

        public AccountsController(ApidemoContext context)
        {
            _context = context;
        }
        [HttpGet("GetAccounts")]
        public async Task<ActionResult<List<Accounts>>> Get()
        {
            var x = await _context.Accounts.ToListAsync();
            return x;
        }
        [HttpPost("InsertUser")]
        public async Task<HttpStatusCode> InsertRecord(Accounts a)
        {
            var check = _context.Accounts.FirstOrDefault(x => x.Username == a.Username);
            if (check != null)
            {
                //return HttpStatusCode.BadRequest;
                throw new Exception("Duplicate Record");
            }
            else
            {
                _context.Accounts.Add(a);
                await _context.SaveChangesAsync();
                return HttpStatusCode.OK;
            }
        }
    }
}
