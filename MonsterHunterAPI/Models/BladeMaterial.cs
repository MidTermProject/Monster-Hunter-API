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
        [Key]
        [ForeignKey("Blade")]
        public int BladeID { get; set; }
        [Key]
        [ForeignKey("Material")]
        public int MaterialID { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
