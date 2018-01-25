using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonsterHunterAPI.Models
{
    public class MaterialLocation
    {
        public int ID { get; set; }
        public virtual Material Material { get; set; }
        public string Action { get; set; }
        public int DropRate { get; set; }
        public virtual Location Location { get; set; }
        public int LocationID { get; set; }
    }
}
