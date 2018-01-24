using System;
using MonsterHunterAPI.Models;
using MonsterHunterAPI.Controllers;
using Xunit;
using System.Collections.Generic;
using MonsterHunterAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace XUnitTestAPI
{
    public class ModelBladeTest
    {
        HunterDbContext _context;

        public ModelBladeTest()
        {
            DbContextOptions<HunterDbContext> options = new DbContextOptionsBuilder<HunterDbContext>()

                .UseInMemoryDatabase(Guid.NewGuid().ToString())

                .Options;

            _context = new HunterDbContext(options);

        }

        [Fact]
        public void GetName()
        {
            Blade testblade = new Blade()
            {
                Name = "Muramasa"
            };

            Assert.Matches("Muramasa", testblade.Name);
        }

        [Fact]
        public void GetId()
        {
            Blade testblade = new Blade()
            {
                ID = 2
            };

            Assert.Equal(2, testblade.ID);
        }

        [Fact]
        public void GetDmg()
        {
            Blade testblade = new Blade()
            {
                RawDamage = 10
            };

            Assert.Equal(10, testblade.RawDamage);
        }

        [Fact]
        public void GetEleDmg()
        {
            Blade testblade = new Blade()
            {
                ElementDamage = 200
            };

            Assert.Equal(200, testblade.ElementDamage);
        }

        [Fact]
        public void GetAffinity()
        {
            Blade testblade = new Blade()
            {
                Affinity = 2
            };

            Assert.Equal(2, testblade.Affinity);
        }

        [Fact]
        public void GetRarity()
        {
            Blade testblade = new Blade()
            {
                Rarity = 100
            };

            Assert.Equal(100, testblade.Rarity);
        }

        [Fact]
        public void GetSlots()
        {
            Blade testblade = new Blade()
            {
                Slots = 4
            };

            Assert.Equal(4, testblade.Slots);
        }

        [Fact]
        public void GetDef()
        {
            Blade testblade = new Blade()
            {
                Defense = 10
            };

            Assert.Equal(10, testblade.Defense);
        }

        [Fact]
        public void GetClass()
        {
            Blade testblade = new Blade()
            {
                WeaponClass = "Long Sword"
            };

            Assert.Matches("Long Sword", testblade.WeaponClass);
        }

        [Fact]
        public void GetParent()
        {
            Blade parentblade = new Blade()
            {
                ID = 1,
                WeaponClass = "Long Sword",
                Name = "Stabbathy",
                ImgUrl = "https://everyrecordtellsastory.files.wordpress.com/2014/04/toothpick-held-in-hand.jpg",
                Description = "A sword literally only existing to become another sword.",
                RawDamage = 8,
                ElementType = "Awesome",
                ElementDamage = 180,
                Affinity = 1,
                Rarity = 80,
                Sharpness = "Green",
                Slots = 3,
                HasChild = true,
                Defense = 8,
                Materials = new List<string>()
            };

            Blade testblade = new Blade()
            {
                Parent = parentblade
            };

            Assert.IsType<Blade>(testblade.Parent);
        }

        [Fact]
        public void GetImg()
        {
            Blade testblade = new Blade()
            {
                ImgUrl = "https://everyrecordtellsastory.files.wordpress.com/2014/04/toothpick-held-in-hand.jpg"
            };

            Assert.Matches("https://everyrecordtellsastory.files.wordpress.com/2014/04/toothpick-held-in-hand.jpg", testblade.ImgUrl);
        }

        [Fact]
        public void GetDesc()
        {
            Blade testblade = new Blade()
            {
                Description = "A totally rad sword built OP as all heck for testing purposes."
            };

            Assert.Matches("A totally rad sword built OP as all heck for testing purposes.", testblade.Description);
        }

        [Fact]
        public void GetElem()
        {
            Blade testblade = new Blade()
            {
                ElementType = "Awesome"
            };

            Assert.Matches("Awesome", testblade.ElementType);
        }

        [Fact]
        public void GetSharp()
        {
            Blade testblade = new Blade()
            {
                Sharpness = "Green"
            };

            Assert.Matches("Green", testblade.Sharpness);
        }

        [Fact]
        public void HasChild()
        {
            Blade testblade = new Blade()
            {
                HasChild = false
            };

            Assert.False(testblade.HasChild);
        }
    }
}
