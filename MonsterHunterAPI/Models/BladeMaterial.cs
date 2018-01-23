using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonsterHunterAPI.Models
{
    public class BladeMaterial
    {
        public int ID { get; set; }
        public Blade BladeID { get; set; }
        public Material MaterialID { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
