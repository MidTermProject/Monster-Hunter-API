using System;
using MonsterHunterAPI.Models;
using MonsterHunterAPI.Controllers;
using Xunit;
using System.Collections.Generic;
using MonsterHunterAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace XUnitTestAPI
{
    public class ControllerMaterialTest
    {
        DbContextOptions<HunterDbContext> options = new DbContextOptionsBuilder<HunterDbContext>()

            .UseInMemoryDatabase(Guid.NewGuid().ToString())

            .Options;

        [Fact]
        public void TestGet()
        {
            using (HunterDbContext _context = new HunterDbContext(options))
            {

                MaterialController controller = new MaterialController(_context);

                int tableCount = controller.Get().Count();

                Assert.Equal(0, tableCount);

            }
        }

        [Fact]
        public async void TestGetMaterialByAsync()
        {
            using (HunterDbContext _context = new HunterDbContext(options))
            {
                MaterialController controller = new MaterialController(_context);

                Material mat = new Material()
                {
                    ID = 1,
                    Name = "Unobtanium",
                    Rarity = 1
                };

                _context.Materials.Add(mat);
                await _context.SaveChangesAsync();

                Material newMat = await _context.Materials.FirstOrDefaultAsync(x => x.Name == "Unobtanium");
                int MatId = newMat.ID;

                Material material = controller.GetMaterialBy(MatId)[0];

                Assert.Equal("Unobtanium", material.Name);
            }
        }

        [Fact]
        public async void TestPost()
        {
            using (HunterDbContext _context = new HunterDbContext(options))
            {

                MaterialController controller = new MaterialController(_context);

                Material mat = new Material()
                {
                    Name = "Unobtanium",
                    Rarity = 1
                };

                await controller.Post(mat);

                int tableCount = controller.Get().Count();

                Assert.Equal(1, tableCount);

            }
        }

        [Fact]
        public async void TestPut()
        {
            using (HunterDbContext _context = new HunterDbContext(options))
            {

                MaterialController controller = new MaterialController(_context);

                Material mat = new Material()
                {
                    Name = "Unobtanium",
                    Rarity = 1
                };

                await controller.Post(mat);

                mat = controller.Get().FirstOrDefault<Material>(l => l.Name == "Unobtanium");

                mat.Name = "Vibranium";

                await controller.Put(mat.ID, mat);

                Material material = controller.GetMaterialBy(mat.ID)[0];

                Assert.Equal("Vibranium", material.Name);

            }
        }

        [Fact]
        public async void TestDeleteAsync()
        {
            using (HunterDbContext _context = new HunterDbContext(options))
            {

                MaterialController controller = new MaterialController(_context);

                Material mat = new Material()
                {
                    Name = "Unobtanium",
                    Rarity = 1,
                    Description = "Derpadoo",
                    Locations = new List<Location>
                    {
                        new Location {
                            Name = "The Forrest",
                            Area = 1
                        }
                    }
                };

                await controller.Post(mat);

                int tableCount1 = controller.Get().Count();

                int MatId = controller.Get().FirstOrDefault<Material>(l => l.Name == "Unobtanium").ID;

                await controller.Delete(MatId);

                int tableCount2 = controller.Get().Count();

                Assert.Equal(1, tableCount1 - tableCount2);

            }
        }
    }
}
