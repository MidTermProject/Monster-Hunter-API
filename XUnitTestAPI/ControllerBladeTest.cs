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
                List<Material> testMaterials = GetTestMaterials();
                foreach (Material x in testMaterials)
                {
                    _context.Materials.Add(x);
                }
                _context.SaveChangesAsync();

                List<Blade> testBlades = GetTestBlades();
                foreach (Blade x in testBlades)
                {
                    _context.Blades.Add(x);
                }
                _context.SaveChangesAsync();

                // Arrange
                BladeController controller = new BladeController(_context);
                // Act
                IEnumerable<Blade> result = controller.Get();
                List<Blade> resultList = result.ToList();
                // Assert
                Assert.Equal(testBlades.Count, resultList.Count);
            }
        }

        private List<Blade> GetTestBlades()
        {
            var testBlades = new List<Blade>
            {
                new Blade
                {
                    ID = 1,
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
                    Materials = new List<string> {"Iron Ore:4"}
                },
                new Blade
                {
                    ID = 2,
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
                    Materials = new List<string> {"Iron Ore:4"}
                }
            };

            return testBlades;
        }

        private List<Material> GetTestMaterials()
        {
            var testMaterials = new List<Material>
            {
                new Material
                {
                    ID = 1,
                    Name = "Iron Ore",
                    Rarity = 4,
                    Description = "Its an ore... of iron...",
                },
            };

            return testMaterials;
        }
    }
}
