using System;
using MonsterHunterAPI.Models;
using MonsterHunterAPI.Controllers;
using Xunit;
using System.Collections.Generic;
using MonsterHunterAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace XUnitTestAPI
{
    public class ModelBladeMaterialTest
    {
        HunterDbContext _context;

        public ModelBladeMaterialTest()
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
            BladeMaterial testbladematerial = new BladeMaterial()
            {
                ID = 2
            };

            Assert.Equal(2, testbladematerial.ID);
        }

        [Fact]
        public void GetMatID()
        {
            BladeMaterial testbladematerial = new BladeMaterial()
            {
                MaterialID = 10
            };

            Assert.Equal(10, testbladematerial.MaterialID);
        }

        [Fact]
        public void GetQuantity()
        {
            BladeMaterial testbladematerial = new BladeMaterial()
            {
                Quantity = 5
            };

            Assert.Equal(5, testbladematerial.Quantity);
        }

        [Fact]
        public void GetBlade()
        {
            BladeMaterial testbladematerial = new BladeMaterial()
            {
                Blade = new Blade()
            };

            Assert.IsType<Blade>(testbladematerial.Blade);
        }

        [Fact]
        public void GetMaterial()
        {
            BladeMaterial testbladematerial = new BladeMaterial()
            {
                Material = new Material()
            };

            Assert.IsType<Material>(testbladematerial.Material);
        }

        /////////////////
        /// Get Tests ///
        /////////////////

        [Fact]
        public void SetId()
        {
            BladeMaterial testbladematerial = new BladeMaterial()
            {
                ID = 2
            };
            testbladematerial.ID = 4;

            Assert.Equal(4, testbladematerial.ID);
        }

        [Fact]
        public void SetMatID()
        {
            BladeMaterial testbladematerial = new BladeMaterial()
            {
                MaterialID = 10
            };
            testbladematerial.MaterialID = 12;

            Assert.Equal(12, testbladematerial.MaterialID);
        }

        [Fact]
        public void SetQuantity()
        {
            BladeMaterial testbladematerial = new BladeMaterial()
            {
                Quantity = 5
            };
            testbladematerial.Quantity = 6;

            Assert.Equal(6, testbladematerial.Quantity);
        }

        [Fact]
        public void SetBlade()
        {
            BladeMaterial testbladematerial = new BladeMaterial();
            testbladematerial.Blade = new Blade();

            Assert.IsType<Blade>(testbladematerial.Blade);
        }

        [Fact]
        public void SetMaterial()
        {
            BladeMaterial testbladematerial = new BladeMaterial();
            testbladematerial.Material = new Material();

            Assert.IsType<Material>(testbladematerial.Material);
        }


    }
}
