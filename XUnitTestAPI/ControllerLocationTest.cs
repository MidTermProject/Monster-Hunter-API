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
    public class ControllerLocationTest
    {
        DbContextOptions<HunterDbContext> options = new DbContextOptionsBuilder<HunterDbContext>()

            .UseInMemoryDatabase(Guid.NewGuid().ToString())

            .Options;

        [Fact]
        public void TestGet()
        {
            using (HunterDbContext _context = new HunterDbContext(options))
            {

                LocationController controller = new LocationController(_context);

                int tableCount = controller.Get().Count();

                Assert.Equal(0, tableCount);

            }
        }

        [Fact]
        public async void TestLocationAsync()
        {
            using (HunterDbContext _context = new HunterDbContext(options))
            {
               
                LocationController controller = new LocationController(_context);

                Location loc = new Location()
                {
                    Name = "The Forrest",
                    Area = 1
                };

                await controller.Post(loc);

               // int LocId = controller.Get().FirstOrDefault<Location>(l => l.Name == "The Forrest").ID;


                Location location = controller.Location(1);

                Assert.Equal("The Forrest", location.Name);

            }
        }

        [Fact]
        public async void TestPostAsync()
        {
            using (HunterDbContext _context = new HunterDbContext(options))
            {

                LocationController controller = new LocationController(_context);

                Location loc = new Location()
                {
                    Name = "The Forrest",
                    Area = 1
                };

                await controller.Post(loc);

                int tableCount = controller.Get().Count();

                Assert.Equal(1, tableCount);

            }
        }

        [Fact]
        public async void TestPut()
        {
            using (HunterDbContext _context = new HunterDbContext(options))
            {

                LocationController controller = new LocationController(_context);

                Location loc = new Location()
                {
                    Name = "The Forrest",
                    Area = 1
                };

                await controller.Post(loc);

                int LocId = controller.Get().FirstOrDefault<Location>(l => l.Name == "The Forrest").ID;

                loc = new Location()
                {
                    Name = "The Forest",
                    Area = 1
                };

                await controller.Put(LocId, loc);

                Location location = controller.Location(LocId);

                Assert.Equal("The Forest", location.Name);

            }
        }

        [Fact]
        public async void TestDeleteAsync()
        {
            using (HunterDbContext _context = new HunterDbContext(options))
            {

                LocationController controller = new LocationController(_context);

                Location loc = new Location()
                {
                    Name = "The Forrest",
                    Area = 1
                };

                await controller.Post(loc);

                int tableCount1 = controller.Get().Count();

                int LocId = controller.Get().FirstOrDefault<Location>(l => l.Name == "The Forrest").ID;

                await controller.Delete(LocId);

                int tableCount2 = controller.Get().Count();

                Assert.Equal(1, tableCount1 - tableCount2);

            }
        }
    }
}
