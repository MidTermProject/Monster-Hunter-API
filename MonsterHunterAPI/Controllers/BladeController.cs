using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MonsterHunterAPI.Models;
using MonsterHunterAPI.Data;

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
        public IEnumerable<Blade> Get()
        {
            return _context.Blades;
        }


        // GET api/<controller>/5
        [HttpGet("{id:int}")]
        public List<Blade> GetBladeFilteredBy(int id, string weaponClass, string element, int rarity)
        {
            // Grab one Blade from the Blades table
            List<Blade> bladesToReturn = new List<Blade>();
            Blade blade = new Blade();

            bladesToReturn = _context.Blades.ToList();

            if (id != 0)
            {
                blade = bladesToReturn.FirstOrDefault(b => b.ID == id);
                bladesToReturn.Add(blade);
                return bladesToReturn;
            }

            if (!String.IsNullOrEmpty(weaponClass))
            {
                bladesToReturn = bladesToReturn.Where(b => b.WeaponClass == weaponClass).ToList();
            }

            if (!String.IsNullOrEmpty(element))
            {
                bladesToReturn = bladesToReturn.Where(b => b.ElementType == element).ToList();
            }

            if (rarity != 0)
            {
                bladesToReturn = bladesToReturn.Where(b => b.Rarity == rarity).ToList();
            }

            return bladesToReturn;
        }


        [HttpGet]
        public void GetSwordsBy(string elemenet)
        {
            
        }

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
