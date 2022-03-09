#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoApi.Db;
using DemoApi.Models;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DemoDbContext _context;

        public UsersController(DemoDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.User.Include(x=>x.Address).ToListAsync();
        }
       
        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> AddUserWithAddress(User user)
        {
            user.Id=Guid.NewGuid();

            user.Address.Id=Guid.NewGuid();//pk

            user.Address.UserId = user.Id;

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

       

      
    }
}
