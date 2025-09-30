using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelRequests.Domain.Entities;
using TravelRequests.Infrastructure.Persistence;

namespace Prueba_Tecnica_net.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] 
    public class TravelRequestsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TravelRequestsController(AppDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var requests = await _context.TravelRequests
                .Include(r => r.User)
                .ToListAsync();
            return Ok(requests);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var request = await _context.TravelRequests
                .Include(r => r.User)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (request == null)
                return NotFound();

            return Ok(request);
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TravelRequest travelRequest)
        {
            _context.TravelRequests.Add(travelRequest);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = travelRequest.Id }, travelRequest);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TravelRequest travelRequest)
        {
            if (id != travelRequest.Id)
                return BadRequest();

            _context.Entry(travelRequest).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var request = await _context.TravelRequests.FindAsync(id);
            if (request == null)
                return NotFound();

            _context.TravelRequests.Remove(request);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

