using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Room : Rooms
    {
        public Room(string _name, string _description)
        {
            name = _name;
            description = _description;
        }
    }
}
