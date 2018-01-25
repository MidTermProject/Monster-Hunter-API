using System;
using MonsterHunterAPI.Models;
using MonsterHunterAPI.Controllers;
using Xunit;
using System.Collections.Generic;
using MonsterHunterAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace XUnitTestAPI
{
    public class ModelLocationTest
    {
        HunterDbContext _context;

        public ModelLocationTest()
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
        public void GetName()
        {
            Location testlocation = new Location()
            {
                Name = "Muramasa"
            };

            Assert.Matches("Muramasa", testlocation.Name);
        }

        [Fact]
        public void GetId()
        {
            Location testlocation = new Location()
            {
                ID = 2
            };

            Assert.Equal(2, testlocation.ID);
        }

        [Fact]
        public void GetArea()
        {
            Location testlocation = new Location()
            {
                Area = 10
            };

            Assert.Equal(10, testlocation.Area);
        }

        [Fact]
        public void GetDropRate()
        {
            Location testlocation = new Location()
            {
                DropRate = 200
            };

            Assert.Equal(200, testlocation.DropRate);
        }

        [Fact]
        public void GetAction()
        {
            Location testlocation = new Location()
            {
                Action = "Mining"
            };

            Assert.Matches("Mining", testlocation.Action);
        }

        /////////////////
        /// Get Tests ///
        /////////////////

        [Fact]
        public void SetName()
        {
            Location testlocation = new Location()
            {
                Name = "Muramasa"
            };
            testlocation.Name = "Musashi";

            Assert.Matches("Musashi", testlocation.Name);
        }

        [Fact]
        public void SetId()
        {
            Location testlocation = new Location()
            {
                ID = 2
            };
            testlocation.ID = 4;

            Assert.Equal(4, testlocation.ID);
        }

        [Fact]
        public void SetArea()
        {
            Location testlocation = new Location()
            {
                Area = 10
            };
            testlocation.Area = 12;

            Assert.Equal(12, testlocation.Area);
        }

        [Fact]
        public void SetDropRate()
        {
            Location testlocation = new Location()
            {
                DropRate = 200
            };
            testlocation.DropRate = 220;

            Assert.Equal(220, testlocation.DropRate);
        }

        [Fact]
        public void SetAction()
        {
            Location testlocation = new Location()
            {
                Action = "Mining"
            };
            testlocation.Action = "Explosives";

            Assert.Matches("Explosives", testlocation.Action);
        }
    }
}
