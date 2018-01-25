using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MonsterHunterAPI.Models;
using MonsterHunterAPI.Data;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MonsterHunterAPI.Controllers
{
    [Route("api/[controller]")]
    public class BladeController : Controller
    {
        private readonly HunterDbContext _context;

        public BladeController(HunterDbContext context)
        {
            _context = context;
        }

        // GET ALL BLADES
        // GET: api/blade
        [HttpGet]
        public IEnumerable<Blade> Get() => _context.Blades;

        //GET ONE BLADE BY ID
        // GET api/blade/:id
        [HttpGet("{id:int}")]
        public List<Blade> Blade(int id)
        {
            List<Blade> newBladeList = new List<Blade>();
            if (!_context.Blades.Any(l => l.ID == id))
                return newBladeList;
            Blade newBlade = _context.Blades.FirstOrDefault(b => b.ID == id);
            if (newBlade != null)
            {
                newBlade.Materials = new List<string>();
                List<BladeMaterial> newBladeMaterials = _context.BladesMaterials.Where(y => y.Blade.ID == id).ToList();
                foreach (var x in newBladeMaterials)
                {
                    List<Material> materials = _context.Materials.Where(m => m.ID == x.MaterialID).ToList();

                    foreach (var y in materials)
                        newBlade.Materials.Add(y.Name + ":" + x.Quantity);
                }
                newBladeList.Add(newBlade);
            }
            return newBladeList;
        }

        // GET SEVERAL BLADES BY FILTERS
        // GET api/filterBy/:weaponClass/:element/:rarity
        [HttpGet("{weaponClass}/{element?}/{rarity:int?}")]
        public List<Blade> FilterBy(string weaponClass, string element, int? rarity)
        {
            List<Blade> bladesToReturn = _context.Blades.ToList();

            if (!String.IsNullOrEmpty(weaponClass))
                bladesToReturn = bladesToReturn.Where(b => b.WeaponClass == weaponClass).ToList();

            if (!String.IsNullOrEmpty(element))
                bladesToReturn = bladesToReturn.Where(b => b.ElementType == element).ToList();

            if (rarity.HasValue)
                bladesToReturn = bladesToReturn.Where(b => b.Rarity == rarity).ToList();

            return bladesToReturn;
        }

        // POST A NEW BLADE
        // POST: api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Blade value)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            // add new blade to table
            await _context.Blades.AddAsync(value);
            await _context.SaveChangesAsync();

            // Prep to populate BladeMaterial relation:
            // New blade was added to table, need to retrieve to get the ID of it to use in BladeMaterial relation.
            BladeMaterial newBMrelation = new BladeMaterial();
            Blade newBlade = _context.Blades.Last();

            // Parsing materials and quantities from passed in Blade as array of 2 strings, to update BladeMaterial table
            string[] values = new string[2];
            foreach (string s in value.Materials)
            {
                // This property is actually of type Blade, not int, so can't just pass in the ID of the blade
                newBMrelation.Blade = newBlade;
                values = s.Split(':');
                // Finding ID of material based on its Name
                Material relatedMaterial = _context.Materials.FirstOrDefault(x => x.Name == values[0]);
                if (relatedMaterial != null) newBMrelation.MaterialID = relatedMaterial.ID;
                newBMrelation.Quantity = Int32.Parse(values[1]);
                await _context.BladesMaterials.AddAsync(newBMrelation);
            }

            await _context.SaveChangesAsync();

            return StatusCode(201);
        }

        // EDIT A BLADE BY ID
        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Blade value)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            if (!(_context.Blades.Any(b => b.Name.ToLower() == value.Name.ToLower())))
            {
                return BadRequest();
            }

            _context.Blades.Update(value);
            // Remove prior entries in BladesMaterial for blade being updated:
            // for each name in oldBlade's material list, find ID in BladeMaterial table
            List<BladeMaterial> oldBladeMaterials = _context.BladesMaterials.Where(y => y.Blade.ID == id).ToList();
            foreach (var x in oldBladeMaterials)
            {
                _context.BladesMaterials.Remove(x);
            }
            await _context.SaveChangesAsync();
            // Parse materials and quantities as list of strings, to update BladeMaterial table
            // Get blade from table
            Blade newBlade = _context.Blades.FirstOrDefault(b => b.ID == id);
            // Create new instance of blade material pairing
            BladeMaterial newBMrelation = new BladeMaterial();
            // used to store name and quantity for .Split in foreach loop
            string[] values = new string[2];
            // for each material:quantity string in blade's List<material> property...
            foreach (string s in value.Materials)
            {
                values = s.Split(':');
                // Get Material instance that matches name in current string in Blade's list of materials
                Material relatedMaterial = _context.Materials.FirstOrDefault(x => x.Name == values[0]);
                // Save Blade ID, Material ID, and Quantity to relation instance
                newBMrelation = new BladeMaterial();
                newBMrelation.Blade = newBlade;
                newBMrelation.MaterialID = relatedMaterial.ID;
                newBMrelation.Quantity = Int32.Parse(values[1]);
                // add new row to BladeMaterial table
                await _context.BladesMaterials.AddAsync(newBMrelation);
            }
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE A BLADE BY ID
        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!(await _context.Blades.AnyAsync(b => b.ID == id)))
            {
                return BadRequest();
            }

            // Remove entries in BladesMaterial for blade being deleted:
            // Check first if this blade has materials associated with it
            if (await _context.BladesMaterials.AnyAsync(z => z.Blade.ID == id))
            {
                // for each name in Blade's material list, find ID in BladeMaterial table
                List<BladeMaterial> BladeMaterials = _context.BladesMaterials.Where(y => y.Blade.ID == id).ToList();
                // Remove every instance in BladeMaterial that is related to blade being deleted
                foreach (var x in BladeMaterials)
                {
                    _context.BladesMaterials.Remove(x);
                }
                await _context.SaveChangesAsync();
            }

            // Get blade from table and remove
            Blade bladeToDelete = await _context.Blades.FirstAsync(b => b.ID == id);
            _context.Blades.Remove(bladeToDelete);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
