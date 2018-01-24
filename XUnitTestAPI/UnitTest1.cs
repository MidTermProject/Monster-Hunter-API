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

        DbContextOptions<HunterDbContext> options = new DbContextOptionsBuilder<HunterDbContext>()

        .UseInMemoryDatabase(Guid.NewGuid().ToString())

        .Options;

        [Fact]
        public void CheckGetBladeFilteredBy()
        {
            using (_context = new HunterDbContext(options))
            {
                // GetBladeFilteredBy doesn't function here despite the correct using directory. Maybe routes don't work this way?
                List<Blade> blades = GetBladeFilteredBy();
            }
            // Should be empty because we havn't added anything yet. Will add some values and test for the 2nd or 3rd value once post is working.
            Assert.Equal(blades,new List<Blade>);
        }

        [Fact]
        public void CheckGetBladeFilteredByID(2)
        {
            using (_context = new HunterDbContext(options))
            {
                // GetBladeFilteredBy doesn't function here despite the correct using directory. Maybe routes don't work this way?
                List<Blade> blades = GetBladeFilteredBy();
            }
            // Should be empty because we havn't added anything yet. Will add some values and test for the 2nd or 3rd value once post is working.
            Assert.Equal(blades, new List<Blade>);
        }

        [Fact]
        public void CheckGetBladeFilteredByElement(0,"Long Sword")
        {
            using (_context = new HunterDbContext(options))
            {
                // GetBladeFilteredBy doesn't function here despite the correct using directory. Maybe routes don't work this way?
                List<Blade> blades = GetBladeFilteredBy();
            }
            // Should be empty because we havn't added anything yet. Will add some values and test for the 2nd or 3rd value once post is working.
            Assert.Equal(blades, new List<Blade>);
        }
    }
}
