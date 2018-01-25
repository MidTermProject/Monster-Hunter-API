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
        HunterDbContext _context;

        public ControllerLocationTest()
        {
            DbContextOptions<HunterDbContext> options = new DbContextOptionsBuilder<HunterDbContext>()

                .UseInMemoryDatabase(Guid.NewGuid().ToString())

                .Options;

            _context = new HunterDbContext(options);

        }

        /////////////////
        /// Get Tests ///
        /////////////////

        [Fact]
        public void TestGet()
        {

            LocationController controller = new LocationController(_context);

            int tableCount = controller.Get().Count();

            Assert.Equal(0, tableCount);
        }

        [Fact]
        public async void TestLocation()
        {

            LocationController controller = new LocationController(_context);

            Location loc = new Location()
            {
                Name = "The Forrest",
                Area = 1
            };

            await controller.Post(loc);

            Location location = controller.Location(1);

            Assert.Equal("The Forrest",location.Name);
        }

        [Fact]
        public async void TestPostAsync()
        {

            LocationController controller = new LocationController(_context);

            Location loc = new Location()
            {
                Name = "The Forrest",
                Area = 1
            };
            
            await controller.Post(loc);

            int tableCount = controller.Get().Count();

            Assert.Equal(1,tableCount);
        }
    }
}
