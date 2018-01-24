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
                ID = 2,
                Parent = parentblade,
                WeaponClass = "Long Sword",
                Name = "Muramasa",
                ImgUrl = "https://everyrecordtellsastory.files.wordpress.com/2014/04/toothpick-held-in-hand.jpg",
                Description = "A totally rad sword built OP as all heck for testing purposes.",
                RawDamage = 10,
                ElementType = "Awesome",
                ElementDamage = 200,
                Affinity = 2,
                Rarity = 100,
                Sharpness = "Green",
                Slots = 4,
                HasChild = false,
                Defense = 10,
                Materials = new List<string>() { "Cheese:5", "Unobtanium:10" }
            };
        }

        [Fact]
        public void Get()
        {
            
        }
    }
}
