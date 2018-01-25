using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using MonsterHunterAPI.Data;
using MonsterHunterAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MonsterHunterAPI.Controllers
{
    [Route("api/[controller]")]
    public class MaterialController : Controller
    {
        private readonly HunterDbContext _context;

        public MaterialController(HunterDbContext context)
        {
            _context = context;
        }

        // GET: api/material
        [HttpGet]
        public IEnumerable<Material> Get() => _context.Materials; // Return all materials

        // GET api/material/:id
        [HttpGet("{id:int}")]
        public List<Material> GetMaterialBy(int id)
        {
            // This is a list of materials that has only one material
            // This Action is returning a List of one item to make it easy for the Front-End to Parse data
            List<Material> listOfOneMaterial = new List<Material>();

            // check if Id exists in the Database
            if (!_context.Locations.Any(l => l.ID == id))
                return listOfOneMaterial;

            // Get material by specified ID
            Material material = _context.Materials.FirstOrDefault(m => m.ID == id);

            // Get all material locations objects - different locations for single material
            List<MaterialLocation> materialLocations = _context.MaterialsLocations.Where(m => m.Material.ID == material.ID).ToList();
            
            List<Location> locations = new List<Location>();
            foreach (var ml in materialLocations)
            {
                // Getting location for material from different maps
                Location location = _context.Locations.SingleOrDefault(l => l.ID == ml.LocationID);
                if (location != null)
                {
                    // sets values from Material
                    location.DropRate = ml.DropRate;
                    location.Action = ml.Action;
                    locations.Add(location);
                }
            }

            if (material != null)
            {
                material.Locations = new List<Location>();
                material.Locations = locations;

                listOfOneMaterial.Add(material);
            }

            return listOfOneMaterial;
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Material material)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            // adding the material to generate the ID
            await _context.Materials.AddAsync(material);
            await _context.SaveChangesAsync();

            MaterialLocation ml = new MaterialLocation();

            // Grabbing the last material added to use its ID for the ML table
            Material newMaterial = _context.Materials.Last();

            // For every location the user sent, get its ID, DropRate, Action and save them into the MaterialLocations Table
            foreach (Location loc in material.Locations)
            {
                ml.Material = newMaterial;
                ml.DropRate = loc.DropRate;
                ml.Action = loc.Action;

                Location relatedLocation = _context.Locations.FirstOrDefault(x => x.Name == loc.Name);
                if (relatedLocation != null) ml.LocationID = relatedLocation.ID;
                await _context.MaterialsLocations.AddAsync(ml);
                await _context.SaveChangesAsync();
            }
            return CreatedAtAction("GetMaterialBy", material.ID);
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
