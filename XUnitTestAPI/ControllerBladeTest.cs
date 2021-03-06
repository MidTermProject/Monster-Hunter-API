﻿using System;
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

        [Fact]
        public void TestGetAllBlades()
        {
            HunterDbContext _context;

            DbContextOptions<HunterDbContext> options = new DbContextOptionsBuilder<HunterDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

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

        [Fact]
        public void TestGetOneBlade()
        {
            HunterDbContext _context;

            DbContextOptions<HunterDbContext> options = new DbContextOptionsBuilder<HunterDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

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
                IEnumerable<Blade> result = controller.Blade(2);
                List<Blade> resultList = result.ToList();
                // Assert
                Assert.Equal(testBlades[1], resultList[0]);
            }
        }

        [Fact]
        public void TestGetFilteredBlades()
        {
            HunterDbContext _context;

            DbContextOptions<HunterDbContext> options = new DbContextOptionsBuilder<HunterDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

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
                IEnumerable<Blade> result1 = controller.FilterBy("Long Sword", null, null);
                List<Blade> resultList1 = result1.ToList();
                IEnumerable<Blade> result2 = controller.FilterBy("Great Sword", "Fire", null);
                List<Blade> resultList2 = result2.ToList();
                IEnumerable<Blade> result3 = controller.FilterBy("Great Sword", null, 2);
                List<Blade> resultList3 = result3.ToList();
                // Assert
                Assert.Single(resultList1);
                Assert.Single(resultList2);
                Assert.Single(resultList3);
            }
        }

        [Fact]
        public async Task TestPostBladeAsync()
        {
            HunterDbContext _context;

            DbContextOptions<HunterDbContext> options = new DbContextOptionsBuilder<HunterDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (_context = new HunterDbContext(options))
            {
                List<Material> testMaterials = GetTestMaterials();
                foreach (Material x in testMaterials)
                {
                    _context.Materials.Add(x);
                }
                await _context.SaveChangesAsync();

                // Arrange
                BladeController controller = new BladeController(_context);

                // Act
                List<Blade> testBlades = GetTestBlades();
                foreach (Blade x in testBlades)
                {
                    await controller.Post(x);
                }

                int tableCount = _context.Blades.Count();

                // Assert
                Assert.Equal(2, tableCount);
            }
        }

        [Fact]
        public async Task TestBladeMaterialRelationAsync()
        {
            HunterDbContext _context;

            DbContextOptions<HunterDbContext> options = new DbContextOptionsBuilder<HunterDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (_context = new HunterDbContext(options))
            {
                List<Material> testMaterials = GetTestMaterials();
                foreach (Material x in testMaterials)
                {
                    _context.Materials.Add(x);
                }
                await _context.SaveChangesAsync();

                // Arrange
                BladeController controller = new BladeController(_context);
                
                // Act
                List<Blade> testBlades = GetTestBlades();
                foreach (Blade x in testBlades)
                {
                    await controller.Post(x);
                }

                Blade newBlade = new Blade();
                newBlade = await _context.Blades.FirstAsync();
                List<BladeMaterial> bladeMaterials = _context.BladesMaterials.Where(x => x.Blade.ID == newBlade.ID).ToList();
                
                // Assert
                Assert.Equal(newBlade.Materials.Count, bladeMaterials.Count);
            }
        }

        [Fact]
        public async Task TestPutBladeAsync()
        {
            HunterDbContext _context;

            DbContextOptions<HunterDbContext> options = new DbContextOptionsBuilder<HunterDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (_context = new HunterDbContext(options))
            {
                List<Material> testMaterials = GetTestMaterials();
                foreach (Material x in testMaterials)
                {
                    _context.Materials.Add(x);
                }
                await _context.SaveChangesAsync();

                // Arrange
                BladeController controller = new BladeController(_context);

                // Act
                List<Blade> testBlades = GetTestBlades();
                foreach (Blade x in testBlades)
                {
                    await controller.Post(x);
                }

                Blade alteredBlade = controller.Get().FirstOrDefault(b => b.Name == "Iron Katana 1");

                alteredBlade.Name = "Sharp Katana 1";

                await controller.Put(alteredBlade.ID, alteredBlade);

                Blade alteredBladedReturned = controller.Blade(alteredBlade.ID)[0];

                Assert.Equal("Sharp Katana 1", alteredBladedReturned.Name);
            }
        }

        [Fact]
        public async Task TestDeleteBladeAsync()
        {
            HunterDbContext _context;

            DbContextOptions<HunterDbContext> options = new DbContextOptionsBuilder<HunterDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (_context = new HunterDbContext(options))
            {
                List<Material> testMaterials = GetTestMaterials();
                foreach (Material x in testMaterials)
                {
                    _context.Materials.Add(x);
                }
                await _context.SaveChangesAsync();

                // Arrange
                BladeController controller = new BladeController(_context);

                // Act
                List<Blade> testBlades = GetTestBlades();
                foreach (Blade x in testBlades)
                {
                    await controller.Post(x);
                }
                int tableCount1 = _context.Blades.Count();

                Blade bladeToDelete = controller.Get().FirstOrDefault(b => b.Name == "Iron Katana 1");

                await controller.Delete(bladeToDelete.ID);
                int tableCount2 = _context.Blades.Count();

                Assert.Equal(1, tableCount1 - tableCount2);
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
                    Materials = new List<string> {"Iron Ore:4", "Wood:2"}
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
                    ElementType = "Fire",
                    ElementDamage = 0,
                    Sharpness = "Yellow",
                    Rarity = 2,
                    Affinity = 0,
                    Slots = 0,
                    Defense = 0,
                    ImgUrl = null,
                    Materials = new List<string> {"Wood:6", "Iron Ore:4"}
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
                new Material
                {
                    ID = 2,
                    Name = "Wood",
                    Rarity = 1,
                    Description = "The stuff trees are made of...",
                },
            };

            return testMaterials;
        }
    }
}
