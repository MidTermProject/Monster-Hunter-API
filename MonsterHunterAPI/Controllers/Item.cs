using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonsterHunterAPI.Controllers
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> Materials { get; set; }
        public string FoundAt { get; set; }

    }

    public class Weapon : Item
    {
        public string WeaponType { get; set; }
        public int Attack { get; set; }
        public string Element { get; set; }
        public int ElementAttack { get; set; }
        public int UpgradesFrom { get; set; }
        // public int UpgradesTo { get; set; }
        public List<int> Materials{ get; set; }
    }

    public class Armor : Item
    {
        public string ArmorSlot { get; set; }
        public string Defence { get; set; }
        public int Rarity { get; set; }
        public int ElementAttack { get; set; }
        public int UpgradesFrom { get; set; }
        // public int UpgradesTo { get; set; }
        public List<int> Materials { get; set; }
    }
}
