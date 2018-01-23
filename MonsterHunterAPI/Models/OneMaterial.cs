using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonsterHunterAPI.Models
{
    public class OneMaterial : Material
    {
        public int Quantity { get; set; }
        public List <OneLocation> Locations { get; set; }
    }
}
