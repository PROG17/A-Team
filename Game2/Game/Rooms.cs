using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public  class Rooms 
    {
        //ska in en items handler här som man kan anropa items i rummet. om inte room handler
        public string name { get; set; }
        public string description { get; set; }
        
        public string itemRequrements { get; set; }
        public  int [] exits { get; set; }
        public int [] roomPlacement { get; set; }
        public string [] doors { get; set; }
        public List<string> items2 { get; set; }





    }

}

