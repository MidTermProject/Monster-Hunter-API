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
        public OneBlade GetOneBlade(int id)
        {
            // Grab one Blade from the Blades table
            OneBlade oneBlade = new OneBlade();
            Blade blade = new Blade();

            blade = _context.Blades.FirstOrDefault(b => b.ID == id);
            oneBlade.ID = blade.ID;
            oneBlade.Affinity = blade.Affinity;
            oneBlade.Defense = blade.Defense;
            oneBlade.Description = blade.Description;
            oneBlade.ElementDamage = blade.ElementDamage;
            oneBlade.ElementType = blade.ElementType;
            oneBlade.HasChild = blade.HasChild;
            oneBlade.Name = blade.Name;
            oneBlade.Parent = blade.Parent;


            List<BladeMaterial> bladeMaterials = new List<BladeMaterial>();
            bladeMaterials = _context.BladesMaterials.Where(vm => vm.Blade.ID == id).ToList();
            
            BladeMaterial test = new BladeMaterial();

            // Go through each of the tiems in the BladeMaterials
            // Quiery the Materials Table
            // convert all Materials from Materials Table to a list<Materials>
            // set that list to oneBlade.Materials

            var materials = _context.Materials;

            foreach (var item in bladeMaterials)
            {
            }
            string a = "";
            //OneMaterial oneMaterial = new OneMaterial();
            //List<OneMaterial> materials = new List<OneMaterial>();

            //OneLocation oneLocation = new OneLocation();
            //List<OneLocation> locations = new List<OneLocation>();
            //locations = _context.Locations.Where(l => l.).ToList();



            //OneBlade oneBlade = new OneBlade();
            //oneBlade.Materials = materials;
            return oneBlade;
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
