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
    public class InterventionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InterventionsController(ApplicationDbContext context)
        {
            _context = context;
        }

         // GET: api/elevators/status
        [HttpGet("status")]
        public async Task<ActionResult<IEnumerable<Intervention>>> GetInterventionsStatus()
        {
            await _context.interventions.ToListAsync();
            List<Intervention> interventions = await _context.interventions.ToListAsync();
            List<Intervention> pendingInterventions = new List<Intervention>();
           
           foreach (Intervention b in interventions)
           {
              if (b.status == "Pending")
                {
                    pendingInterventions.Add(b);
                }

           
            } 
            return pendingInterventions;
        }

        // POST: api/elevators/Status/1?status=offline
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("ChangeStatusToInProgress/{id}")]
        public async Task<ActionResult<Intervention>> ChangeInterventionStatusToInProgress(long id)
        {

            var intervention = await _context.interventions.FindAsync(id);
            
                       
            intervention.status = "InProgress";
            intervention.start_intervention = DateTime.Now;
            await _context.SaveChangesAsync();
             

             return intervention;
        }

         // GET: api/elevators/offline
         [HttpPut("ChangeStatusToCompleted/{id}")]
        public async Task<ActionResult<Intervention>> ChangeInterventionStatusToCompleted(long id)
        {

            var intervention = await _context.interventions.FindAsync(id);
            
                       
            intervention.status = "Completed";
            intervention.end_intervention = DateTime.Now;
            await _context.SaveChangesAsync();
            
            return intervention;
        }

        private bool ElevatorExists(long id)
        {
            return _context.elevators.Any(e => e.Id == id);
        }
    }
}
