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
        [Key]
        [ForeignKey("Material")]
        public int MaterialID { get; set; }
        [Key]
        [ForeignKey("Location")]
        public int LocationID { get; set; }
        [Required]
        public string Action { get; set; }
        [Required]
        public int DropRate { get; set; }
    }
}
