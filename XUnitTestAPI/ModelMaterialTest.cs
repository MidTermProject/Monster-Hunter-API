using System;
using MonsterHunterAPI.Models;
using MonsterHunterAPI.Controllers;
using Xunit;
using System.Collections.Generic;
using MonsterHunterAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace XUnitTestAPI
{
    public class ModelMaterialTest
    {
        HunterDbContext _context;

        public ModelMaterialTest()
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
            Material testmaterial = new Material()
            {
                Name = "Unobtanium"
            };

            Assert.Matches("Unobtanium", testmaterial.Name);
        }

        [Fact]
        public void GetId()
        {
            Material testmaterial = new Material()
            {
                ID = 2
            };

            Assert.Equal(2, testmaterial.ID);
        }

        [Fact]
        public void GetQuantity()
        {
            Material testmaterial = new Material()
            {
                Quantity = 2
            };

            Assert.Equal(2, testmaterial.Quantity);
        }

        [Fact]
        public void GetRarity()
        {
            Material testmaterial = new Material()
            {
                Rarity = 100
            };

            Assert.Equal(100, testmaterial.Rarity);
        }

        [Fact]
        public void GetDesc()
        {
            Material testmaterial = new Material()
            {
                Description = "A metal made from the moon."
            };

            Assert.Matches("A metal made from the moon.", testmaterial.Description);
        }

        /////////////////
        /// Get Tests ///
        /////////////////

        [Fact]
        public void SetName()
        {
            Material testmaterial = new Material()
            {
                Name = "Unobtanium"
            };
            testmaterial.Name = "Cheese";

            Assert.Matches("Cheese", testmaterial.Name);
        }

        [Fact]
        public void SetId()
        {
            Material testmaterial = new Material()
            {
                ID = 2
            };
            testmaterial.ID = 4;

            Assert.Equal(4, testmaterial.ID);
        }

        [Fact]
        public void SetRarity()
        {
            Material testmaterial = new Material()
            {
                Rarity = 100
            };
            testmaterial.Rarity = 10;

            Assert.Equal(10, testmaterial.Rarity);
        }

        [Fact]
        public void SetQuantity()
        {
            Material testmaterial = new Material()
            {
                Quantity = 100
            };
            testmaterial.Quantity = 10;

            Assert.Equal(10, testmaterial.Quantity);
        }

        [Fact]
        public void SetDesc()
        {
            Material testmaterial = new Material()
            {
                Description = "A metal made from the moon."
            };
            testmaterial.Description = "Woops it's just cheese";

            Assert.Matches("Woops it's just cheese", testmaterial.Description);
        }
    }
}
