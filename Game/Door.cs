using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
   public class Door
    {
       public  string name { get; set; }
        
        public string keyRecurement { get; set; }
        public string description { get; set; }
        public int [] mapCords { get; set; }
        public List<string> open { get; set; }
        // public Door(string name, List<bool> open, string keyRecurement, string description, int[] mapCords)
        // {
        //     this.name = name;
        //     this.open = open;
        //     this.keyRecurement = keyRecurement;
        //     this.description = description;
        //     this.mapCords = mapCords;
        //     this. Doors = new List<Door>();
        // }

    }
}
