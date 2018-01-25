using System;
using System.Collections.Generic;
using System.Text;
using MonsterHunterAPI.Controllers;
using MonsterHunterAPI.Models;
using MonsterHunterAPI.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;

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

        [Fact]
        public async System.Threading.Tasks.Task TestPostAndGetAsync()
        {   
            BladeController _controller = new BladeController(_context);

            Blade blade = new Blade()
            {
                Name = "Vergil's Sword"
            };

            await _controller.Post(blade);

            IEnumerable<Blade> databasedBlade = _controller.Get();

            int afterCount = 5;
            int beforeCount = 5;

            int difference = afterCount - beforeCount;

            Assert.Equal(1, difference);
        }
    }
}
