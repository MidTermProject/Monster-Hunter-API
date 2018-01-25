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

        // POST api/material
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Material material)
        {
            // checking if the Models state is invalid - Aka form is not in the right format
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            // Checking if the Material (by Name) already exists in the Database
            if (_context.Materials.Any(m => m.Name == material.Name)) return StatusCode(409);

            // adding the material to generate the ID
            await _context.Materials.AddAsync(material);
            await _context.SaveChangesAsync();

            // Grabbing the last material added to use its ID for the ML table
            Material newMaterial = _context.Materials.Last();

            // For every location the user sent, get its ID, DropRate, Action and save them into the MaterialLocations Table
            foreach (Location loc in material.Locations)
            {
                // Assigning the Material Location with necessary properties
                MaterialLocation ml = new MaterialLocation
                {
                    Material = newMaterial,
                    DropRate = loc.DropRate,
                    Action = loc.Action
                };

                // Getting related Location object with ID sent by User
                Location relatedLocation = _context.Locations.FirstOrDefault(x => x.ID == loc.ID);

                // Assigning the Material Location object with the ID of the related Location
                if (relatedLocation != null) ml.LocationID = relatedLocation.ID;

                // Adding the Material Location object to the context to be saved
                await _context.MaterialsLocations.AddAsync(ml);
            }
            await _context.SaveChangesAsync();

            // return code 201 for creation completed
            return StatusCode(201);
        }

        // PUT api/material/:id
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Material material)
        {
            if (!ModelState.IsValid) return BadRequest();

            // if ID doesn't exist in materials table
            if(!_context.Materials.Any(m => m.ID == id)) return StatusCode(409);
            
            // Update the Material with the new material
            _context.Materials.Update(material);

            // Remove prior rows from material location table to insert the new locations
            List<MaterialLocation> oldMaterialLocations =
                _context.MaterialsLocations.Where(ml => ml.Material.ID == id).ToList();

            // Remove every old material location objects in the table
            foreach (var ml in oldMaterialLocations)
                _context.MaterialsLocations.Remove(ml);
            
            await _context.SaveChangesAsync();

            // Get the current material requested
            Material currentMaterial = await _context.Materials.FirstOrDefaultAsync(m => m.ID == id);

            // for every location in that material create a new Material location object with necessary
            // properties and add it to the database
            foreach (var location in material.Locations)
            {
                Location relatedLocation = await _context.Locations.FirstOrDefaultAsync(l => l.ID == location.ID);
                MaterialLocation newMaterialLocation = new MaterialLocation();
                newMaterialLocation.LocationID = relatedLocation.ID;
                newMaterialLocation.Material = currentMaterial;
                newMaterialLocation.Action = location.Action;
                newMaterialLocation.DropRate = location.DropRate;

                await _context.MaterialsLocations.AddAsync(newMaterialLocation);
            }
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
