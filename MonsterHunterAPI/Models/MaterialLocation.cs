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
        public Material Material { get; set; }
        public Location Location { get; set; }
        [Required]
        public string Action { get; set; }
        [Required]
        public int DropRate { get; set; }
    }
}
