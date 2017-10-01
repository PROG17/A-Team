using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class item  
    {
        public string itemName { get; set; }
        public string itemDescription { get; set; }
        public string closeInspection { get; set; }
        public string useWith { get; set; }
        public bool have { get; set; }
        public bool  used { get; set; }
        public string description { get; set; }
        public string useWithItem { get; set; }
        public string afterUseGet { get; set; }
    }
}
