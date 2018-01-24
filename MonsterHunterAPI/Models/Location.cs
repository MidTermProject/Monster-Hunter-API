using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonsterHunterAPI.Models
{
    public class Location
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Area { get; set; }
        [NotMapped]
        public int DropRate { get; set; }
        [NotMapped]
        public string Action { get; set; }
    }
}
