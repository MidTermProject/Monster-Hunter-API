using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MonsterHunterAPI.Data;
using MonsterHunterAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MonsterHunterAPI.Controllers
{
    [Route("api/[controller]")]
    public class LocationController : Controller
    {
        private readonly HunterDbContext _context;

        public LocationController(HunterDbContext hunterDbContext)
        {
            _context = hunterDbContext;
        }

        // GET: api/Location/locations/
        [HttpGet]
        public IEnumerable<Location> Get() => _context.Locations;

        // GET api/Location/:locationId
        [HttpGet("{locationId:int}")]
        public Location Location(int locationId) => _context.Locations.FirstOrDefault(l => l.ID == locationId);

        // POST api/Location
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Location location)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_context.Locations.Any(l => l.Name == location.Name))
            {
                await _context.Locations.AddAsync(location);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("Location", location);
        }

        // PUT api/Location/:id/
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Location location)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // Get location with Id
            Location result = _context.Locations.FirstOrDefault(x => x.ID == id);

            if (result != null)
            {
                result.Name = location.Name;
                result.Area = location.Area;
                result.DropRate = location.DropRate;
                result.Action = location.Action;

                _context.Update(result);
                await _context.SaveChangesAsync();
            }

            return Ok();
        }

        // DELETE api/Location/:id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // check if Id exists in database
            if (!_context.Locations.Any(l => l.ID == id)) return BadRequest();

            Location result = _context.Locations.FirstOrDefault(l => l.ID == id);

            // check if result has a location
            if (result == null) return BadRequest();

            _context.Remove(result);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
