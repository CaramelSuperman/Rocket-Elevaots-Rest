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
    public class ColumnsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ColumnsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Columns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Column>>> Getcolumns()
        {
            return await _context.columns.ToListAsync();
        }

        // GET: api/Columns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Column>> GetColumn(long id)
        {
            var column = await _context.columns.FindAsync(id);

            if (column == null)
            {
                return NotFound();
            }

            return column;
        }
        [HttpGet("List/{id}")]
        public async Task<ActionResult<IEnumerable<Column>>> ListColumns(long id)
        {
            long ID = id;
            await _context.columns.ToListAsync();
            List<Column> columns = await _context.columns.ToListAsync();
            List<Column> columnsList = new List<Column>();
            
           
            foreach (Column d in columns ){
                if(d.battery_id == ID){
                    columnsList.Add(d);}
           }

           
            
            return columnsList;
        }

        // PUT: api/Columns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColumn(long id, Column column)
        {
            if (id != column.Id)
            {
                return BadRequest();
            }

            _context.Entry(column).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColumnExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Columns
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Column>> PostColumn(Column column)
        {
            _context.columns.Add(column);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColumn", new { id = column.Id }, column);
        }

        // GET: api/columns/status/5
        [HttpGet("status/{id}")]
        public async Task<ActionResult<String>> GetColumnStatus(long id)
        {
            var column = await _context.columns.FindAsync(id);

            if (column == null)
            {
                return NotFound();
            }

            return column.status;
        }

        // PUT: api/columns/Status/1?status=offline
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("status/{id}")]
        public async Task<ActionResult<Column>> ChangeColumnStatus(long id, string status)
        {

            var column = await _context.columns.FindAsync(id);
            if (column == null)
            {
                return NotFound();
            }            
            column.status = status;
            await _context.SaveChangesAsync();
            return column;
        }


        // DELETE: api/Columns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColumn(long id)
        {
            var column = await _context.columns.FindAsync(id);
            if (column == null)
            {
                return NotFound();
            }

            _context.columns.Remove(column);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ColumnExists(long id)
        {
            return _context.columns.Any(e => e.Id == id);
        }
    }
}
