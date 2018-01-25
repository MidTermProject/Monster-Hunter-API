using System;
using MonsterHunterAPI.Models;
using MonsterHunterAPI.Controllers;
using Xunit;
using System.Collections.Generic;
using MonsterHunterAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace XUnitTestAPI
{
    public class ModelMaterialLocationTest
    {
        HunterDbContext _context;

        public ModelMaterialLocationTest()
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
        public void GetId()
        {
            MaterialLocation testmateriallocation = new MaterialLocation()
            {
                ID = 2
            };

            Assert.Equal(2, testmateriallocation.ID);
        }

        [Fact]
        public void GetDropRate()
        {
            MaterialLocation testmateriallocation = new MaterialLocation()
            {
                DropRate = 10
            };

            Assert.Equal(10, testmateriallocation.DropRate);
        }

        [Fact]
        public void GetAction()
        {
            MaterialLocation testmateriallocation = new MaterialLocation()
            {
                Action = "Mining"
            };

            Assert.Matches("Mining", testmateriallocation.Action);
        }

        [Fact]
        public void GetMaterial()
        {
            MaterialLocation testmateriallocation = new MaterialLocation()
            {
                Material = new Material()
            };

            Assert.IsType<Material>(testmateriallocation.Material);
        }

        [Fact]
        public void GetLocation()
        {
            MaterialLocation testmateriallocation = new MaterialLocation()
            {
                Location = new Location()
            };

            Assert.IsType<Location>(testmateriallocation.Location);
        }

        /////////////////
        /// Get Tests ///
        /////////////////

        [Fact]
        public void SetId()
        {
            MaterialLocation testmateriallocation = new MaterialLocation()
            {
                ID = 2
            };
            testmateriallocation.ID = 4;

            Assert.Equal(4, testmateriallocation.ID);
        }

      [Fact]
        public void SetDropRate()
        {
            MaterialLocation testmateriallocation = new MaterialLocation()
            {
                DropRate = 10
            };
            testmateriallocation.DropRate = 15;

            Assert.Equal(15, testmateriallocation.DropRate);
        }

        [Fact]
        public void SetAction()
        {
            MaterialLocation testmateriallocation = new MaterialLocation()
            {
                Action = "Mining"
            };
            testmateriallocation.Action = "Explosives";

            Assert.Matches("Explosives", testmateriallocation.Action);
        }

        [Fact]
        public void SetMaterial()
        {
            MaterialLocation testmateriallocation = new MaterialLocation();
            testmateriallocation.Material = new Material();

            Assert.IsType<Material>(testmateriallocation.Material);
        }

        [Fact]
        public void SetLocation()
        {
            MaterialLocation testmateriallocation = new MaterialLocation();
            testmateriallocation.Location = new Location();

            Assert.IsType<Location>(testmateriallocation.Location);
        }
    }
}
