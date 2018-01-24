using System;
using MonsterHunterAPI.Models;
using MonsterHunterAPI.Controllers;
using Xunit;
using System.Collections.Generic;
using MonsterHunterAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace XUnitTestAPI
{
    public class UnitTest1
    {
        HunterDbContext _context;

        public UnitTest1()
        {
            DbContextOptions<HunterDbContext> options = new DbContextOptionsBuilder<HunterDbContext>()

                .UseInMemoryDatabase(Guid.NewGuid().ToString())

                .Options;

            _context = new HunterDbContext(options);
        }

        ///
        /// TEST MODELS
        ///

        [Fact]
        public void CheckBladeModel()
        {
            Blade blade = new Blade() {
                WeaponClass = "Long Sword",
                Name = "Muramasa",
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
                Materials = new List<string>()
            };
            Assert.Empty(blade.Materials);
            Assert.IsType<List<string>>(blade.Materials);

            blade.Materials.Add("Wood:2");
            blade.Materials.Add("Iron Ore:2");
            blade.Materials.Add("Glass:6");
            Assert.NotEmpty(blade.Materials);

            Assert.Matches("Muramasa", blade.Name);

            blade.Name = "Zatoichi";
            blade.Description = "The sword of a legendary blind Samurai.";
            Assert.Matches("Zatoichi", blade.Name);

        }

        ///
        /// TEST CONTROLLERS
        ///

        [Fact]
        public void CheckGet()
        {
            BladeController _controller = new BladeController(_context);
            // GetBladeFilteredBy doesn't function here despite the correct using directory. Maybe routes don't work this way?
            var blades = _controller.Get();
            // Should be empty because we havn't added anything yet. Will add some values and test for the 2nd or 3rd value once post is working.
            Assert.IsType<Microsoft.EntityFrameworkCore.Internal.InternalDbSet<Blade>>(blades);
        }

        //public void CheckGetBladeById()
        //{
        //    BladeController _controller = new BladeController(_context);
        //    // GetBladeFilteredBy doesn't function here despite the correct using directory. Maybe routes don't work this way?
        //    string type = _controller.GetBladeById(1).GetType().ToString();
        //    // Should be empty because we havn't added anything yet. Will add some values and test for the 2nd or 3rd value once post is working.
        //    Assert.Equal("Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1[MonsterHunterAPI.Models.Blade]", type);
        //}

        //[Fact]
        //public void CheckGetBladeFilteredByElement(0,"Long Sword")
        //{
        //    // GetBladeFilteredBy doesn't function here despite the correct using directory. Maybe routes don't work this way?
        //    List<Blade> blades = GetBladeFilteredBy();
        //    // Should be empty because we havn't added anything yet. Will add some values and test for the 2nd or 3rd value once post is working.
        //    Assert.Equal(blades, new List<Blade>);
        //}
    }
}
