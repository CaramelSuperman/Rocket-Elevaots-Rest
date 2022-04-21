#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RocketElevatorsApi.Data;
using RocketElevatorsApi.Models;

namespace RocketElevatorsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

         // GET: api/elevators/status/5
        
        // POST: api/elevators/Status/1?status=offline
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("status/{email}")]
        public async Task<ActionResult<User>> ChangeElevatorStatus(string email)
        {
            string Email = email;
            var user = await _context.users.FindAsync(email);
            if (user == null)
            {
                return NotFound();
            }            
            user.email = "";
            await _context.SaveChangesAsync();
            return user ;
        }
        
        

        private bool UserExists(long id)
        {
            return _context.users.Any(e => e.Id == id);
        }
    }
}