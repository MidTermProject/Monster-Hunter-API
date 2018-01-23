using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonsterHunterAPI.Models
{
    public class OneLocation : Location
    {
        public int DropRate { get; set; }
        public string Action { get; set; }
    }
}
