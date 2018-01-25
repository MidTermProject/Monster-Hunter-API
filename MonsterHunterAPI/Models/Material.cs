using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonsterHunterAPI.Models
{
    public class Material
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Rarity { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public int Quantity { get; set; }
    }
}
