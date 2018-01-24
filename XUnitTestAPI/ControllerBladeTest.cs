using System;
using MonsterHunterAPI.Models;
using MonsterHunterAPI.Controllers;
using Xunit;
using System.Collections.Generic;
using MonsterHunterAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace XUnitTestAPI
{
    public class ControllerBladeTest
    {
        HunterDbContext _context;

        DbContextOptions<HunterDbContext> options = new DbContextOptionsBuilder<HunterDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

        [Fact]
        public void GetAllBlades()
        {
            using (_context = new HunterDbContext(options))
            {

            }
        }

        private List<Blade> GetTestBlades()
        {
            var testBlades = new List<Blade>
            {
                new Blade
                {
                    Parent = null,
                    HasChild = true,
                    WeaponClass = "Long Sword",
                    Name = "Iron Katana 1",
                    Description = "A Long Sword forged with Eastern methods. Durable and resilient, but requires regular upkeep.",
                    RawDamage = 80,
                    ElementType = null,
                    ElementDamage = 0,
                    Sharpness = "Green",
                    Rarity = 1,
                    Affinity = 0,
                    Slots = 0,
                    Defense = 0,
                    ImgUrl = null,
                    Materials = {"Iron Ore:4"},
                },
                new Blade
                {
                    Parent = null,
                    HasChild = true,
                    WeaponClass = "Great Sword",
                    Name = "Steel Blade 1",
                    Description = "A Great Sword forged with Western methods. Durable and resilient, but requires regular upkeep.",
                    RawDamage = 100,
                    ElementType = null,
                    ElementDamage = 0,
                    Sharpness = "Yellow",
                    Rarity = 1,
                    Affinity = 0,
                    Slots = 0,
                    Defense = 0,
                    ImgUrl = null,
                    Materials = {"Iron Ore:4"},
                },
            };

            return testBlades;
        }

        private List<Material> GetTestMaterials()
        {
            var testMaterials = new List<Material>
            {
                new Material
                {
                    Name = "Iron Ore",
                    Rarity = 4,
                    Description = "Its an ore... of iron...",
                },
            };

            return testMaterials;
        }
    }
}
