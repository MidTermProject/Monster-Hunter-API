using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MonsterHunterAPI.Models;

namespace MonsterHunterAPI.Data
{
    public class HunterDbContext : DbContext
    {
        public HunterDbContext(DbContextOptions<HunterDbContext> options) : base(options)
        {

        }

        public DbSet<Blade> Blades { get; set; }
        public DbSet<BladeMaterial> BladesMaterials { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialLocation> MaterialsLocations { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}
