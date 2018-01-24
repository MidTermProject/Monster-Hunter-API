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
        public IEnumerable<Location> Locations() => _context.Locations;

        // GET api/Location/:locationId
        [HttpGet("{id}")]
        public Location GetLocation(int locationId) => _context.Locations.FirstOrDefault(l => l.ID == locationId);

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
