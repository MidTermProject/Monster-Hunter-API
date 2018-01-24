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

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Blade> Get() => _context.Blades;

        // GET api/<controller>/{id}
        [HttpGet("{id:int}")]
        public Blade GetBy(int id)
        {
            Blade newBlade = _context.Blades.FirstOrDefault(b => b.ID == id);
            newBlade.Materials = new List<string>();
            List<BladeMaterial> newBladeMaterials = _context.BladesMaterials.Where(y => y.Blade.ID == id).ToList();
            foreach(var x in newBladeMaterials)
            {
                List<Material> materials = _context.Materials.Where(m => m.ID == x.MaterialID).ToList();
                
                foreach (var y in materials)
                {
                    newBlade.Materials.Add(y.Name + ":" + x.Quantity);
                }
            }
            return newBlade;
        }

        // GET api/<controller>/weaponClass?element=string&rarity=1
        [HttpGet("{weaponClass}/{element?}/{rarity:int?}")]
        public List<Blade> GetBladeFilteredByType(string weaponClass, string element, int? rarity)
        {
            List<Blade> bladesToReturn = new List<Blade>();
            bladesToReturn = _context.Blades.ToList();

            if (!String.IsNullOrEmpty(weaponClass))
            {
                bladesToReturn = bladesToReturn.Where(b => b.WeaponClass == weaponClass).ToList();
            }

            if (!String.IsNullOrEmpty(element))
            {
                bladesToReturn = bladesToReturn.Where(b => b.ElementType == element).ToList();
            }

            if (rarity.HasValue)
            {
                bladesToReturn = bladesToReturn.Where(b => b.Rarity == rarity).ToList();
            }

            return bladesToReturn;
        }

        // POST: api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Blade value)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            // Look value.materials list
            string mName = "";
            string mQuantity = "";
            foreach(string s in value.Materials)
            {
                //s.
            }
            await _context.Blades.AddAsync(value);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get", new { value.ID }, value);
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
