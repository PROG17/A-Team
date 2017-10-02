using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game
{
    class RoomHandler
    {
        ///<summary>
        ///List<Rooms> rooms
        ///</summary>
        ///<remarks>
        /// Detta är en lista med alla rummen som vi ska göra
        ///</remarks>
       public List<Rooms> rooms = new List<Rooms>();
       public List<Door> doors = new List<Door>();
        
        //List<item> items = new List<item>();
        // int[,] map = new int[3, 3];
        //int[] mapCord = new[] { 0, 0 };


        //Rooms segment
        
        private void AddRooms()
        {

            rooms.Add(new Rooms() { name = "Hallen", exits = new[] { 0, 0, 1, 2 }, items2 = new List<string> {  }, doors = new[] { "en vägg", "door3", "en vägg", "door1" }, roomPlacement = new[] { 0, 0 },description = "En stor hall, Det är dammit och det ser inte ut som någon varit här på länge" });
            rooms.Add(new Rooms() { name = "Köket", exits = new[] { 0, 0, 0, 0 }, items2 = new List<string> { "korkskruv" }, doors = new[] { "en vägg", "door4", "door1", "door2" }, roomPlacement = new[] { 0, 1 } , description = "Detta set ut som ett kök, saker ligger huller om buller"});
            rooms.Add(new Rooms() { name = "Skafferiet", exits = new[] { 0, 0, 0, 0 }, items2 = new List<string> { "flaska" },  doors = new[] { "en vägg", "door5", "door2", "en vägg" }, roomPlacement = new[] { 0, 2 } , description = "Du kom in i ett skafferi, Det är för det mesta tomt utom några sager"});

            rooms.Add(new Rooms() { name = "Badrummet", exits = new[] { 0, 0, 0, 0 }, items2 = new List<string> { "tops" }, itemRequrements = "key", doors = new[] { "door3", "door8", "en vägg", "door6" },  roomPlacement = new[] { 1, 0 }, description = "Du kommer in i ett badrum . Det har inte annvänds på länge och det känns på luckten" });
            rooms.Add(new Rooms() { name = "Trofe Rum", exits = new[] { 0, 0, 0, 0 }, items2 = new List<string> { "aphuvud" },  doors = new[] { "door4", "door9", "door6", "door7" }, roomPlacement = new[] { 1, 1 }, description = "Du kommer in i ett troffe rum. På väggen hänger massa djurhuvuden. Vissa är täckta av spindelnär" });
            rooms.Add(new Rooms() { name = "Hallen", exits = new[] { 0, 0, 0, 0 }, items2 = new List<string> {  },  doors = new[] { "door5", "door10", "door7", "en vägg" }, roomPlacement = new[] { 1, 2 }, description = "En stor hall sträcker sig ut framför dig. På väggarna hänger tavlor" });

            rooms.Add(new Rooms() { name = "Oragngeri", exits = new[] { 0, 0, 0, 0 }, items2 = new List<string> {  }, itemRequrements = "key", doors = new[] { "door8", "en vägg", "en vägg", "door11" },  roomPlacement = new[] { 2, 0 }, description = "Du känner nästan friheten . Du försöker krossa en ruta men det går inte." });
            rooms.Add(new Rooms() { name = "Trädgården", exits = new[] { 0, 0, 0, 0 }, items2 = new List<string> { },  doors = new[] { "door9", "en vägg", "door11", "door12" }, roomPlacement = new[] { 2, 1 }, description = "En vildvuxen trädgård sträcker sig ut framför dig. Du bryr dig inte och vill bara öppna sista görren" });
            rooms.Add(new Rooms() { name = "END", exits = new[] { 0, 0, 0, 0 }, items2 = new List<string> {  },  doors = new[] { "door10", "en vägg", "door12", "en vägg" }, roomPlacement = new[] { 2, 2 }, description = "Du kom ut" });

        }

       

        private void AddDoors()
        {
            doors.Add(new Door() { name = "door1", open = new List<string> { "true" }, description = "", keyRecurement = "" });
            doors.Add(new Door() { name = "door2", open = new List<string> { "true" }, description = "", keyRecurement = "" });

            doors.Add(new Door() { name = "door3", open = new List<string> { "false" }, description = "I vägen för dig står en massiv dörr. Den verkar låst.", keyRecurement = "nyckel", });
            doors.Add(new Door() { name = "door4", open = new List<string> { "false" }, description = "Hmm den verkar låst. Kanske hitta något att öppna den med", keyRecurement = "nyckel" });
            doors.Add(new Door() { name = "door5", open = new List<string> { "false" }, description = "En låst dörr. Undra varför allt verkar låst här", keyRecurement = "nyckel" });

            doors.Add(new Door() { name = "door6", open = new List<string> { "true" }, description = "", keyRecurement = "" });
            doors.Add(new Door() { name = "door7", open = new List<string> { "true" }, description = ".", keyRecurement = "" });

            doors.Add(new Door() { name = "door8", open = new List<string> { "false" }, description = "Boom du gick rakt in i en låst dörr. hmm man kan tro dom gillar låsta dörrar", keyRecurement = "grönnyckel" });
            doors.Add(new Door() { name = "door9", open = new List<string> { "false" }, description = "Suck en till låst dörr. Kommer vi aldrig ut här", keyRecurement = "grönnyckel" });
            doors.Add(new Door() { name = "door10", open = new List<string> { "false" }, description = "Överaskning !! En öppen dörr... nee trodde du verkligen det?", keyRecurement = "grönnyckel" });

            doors.Add(new Door() { name = "door11", open = new List<string> { "true" }, description = "", keyRecurement = "" });
            doors.Add(new Door() { name = "door12", open = new List<string> { "true" }, description = "", keyRecurement = "" });
        }
        public  void PopulateListRooms()
        {
            if (rooms.Count == 0)
            {
                AddRooms();
            }
        }

       
        public void ShowRoom(int[] mapCord)
        {

            PopulateListRooms();
            int count = 0;
            int index = 0;
            //ska byta till indexOf men funkar inte
            foreach (var value in rooms)
            {
                //letar efter samma rum
                if (value.roomPlacement.SequenceEqual(mapCord))
                {
                   
                    index = count;
                }
                count++;
            }
            Console.WriteLine("Rum Namn");
            Console.WriteLine(rooms[index].name);
            Console.WriteLine();
            Console.WriteLine("Beskrivning");
            Console.WriteLine(rooms[index].description);
            Console.WriteLine();
            Console.WriteLine("Saker i rummet");
            foreach (var value2 in rooms[index].items2)
            {
                Console.WriteLine(value2);
            }
            Console.WriteLine("Dom utgångar du ser är ");
            Console.WriteLine("norr: " +rooms[index].doors[0]);
            Console.WriteLine("söder: " + rooms[index].doors[1]);
            Console.WriteLine("väster: " + rooms[index].doors[2]);
            Console.WriteLine("öster: " + rooms[index].doors[3]);

        }

        public int[] ExitsThereIsInRoom(int[] mapCord)
        {
            
            foreach (var value in rooms)
            {
                if (value.roomPlacement.SequenceEqual(mapCord))
                {
                    return value.exits;
                }

            }
            return null;
        }

        public string[] GetDoorsNameForRoom(int[] mapCord)
        {
            PopulateListRooms();
            foreach (var value in rooms)
            {
                if (value.roomPlacement.SequenceEqual(mapCord))
                {
                    return value.doors;
                }
            }
            return null;
        }
      //  static List<string> DropItem2()
      //  {
      //      List<string> listRange = new List<string>();
      //      listRange.Add("q");
      //      listRange.Add("s");
      //
      //      return listRange;
      //  }
        public void DropItem(string name,int[]mapCord)
        {
            int count = 0;
            foreach (var value in rooms)
            {

                if (value.roomPlacement.SequenceEqual(mapCord))
                {
                    string tempString = rooms[count].items2.ToString();
                   
                        
                        rooms[count].items2.Add(name);
                    
                   
                }
                count++;
            }
            
        }

       // Doors Segment
        

        public string OpenDoor(int[] mapcords, string doorNameInput,string requredItem)
        {
            PopulateDoorList();
            string anwserMessage ="något gick fel";
            bool canOpenDoor = false;
            foreach (var value in rooms)
            {

                if (value.roomPlacement.SequenceEqual(mapcords))
                {
                    foreach (var value2 in doors)
                    {
                        
                    
                        if (doorNameInput == value2.name)
                        {
                            canOpenDoor = true;
                        }
                    }

                }
            }
            
            if (canOpenDoor)
            {
                int count = 0;
                foreach (var door in doors )
                 {
                     if (door.name == doorNameInput)
                     {
                         if (door.keyRecurement == requredItem)
                         {
                             doors[count].open.Remove("false");
                             doors[count].open.Add("true");
                            // rooms[index].items2.Remove(itemName);
                             anwserMessage = "Du lyckades öppna dörren";
                         }
                         else
                         {
                              anwserMessage = "Det gick inte att öppna";
                         }
                     }
                     count++;
                 }
            }
            return anwserMessage;
        }

        public void PopulateDoorList()
        {
            if (doors.Count == 0)
            {
                AddDoors();
            }
        }

        public bool CanweWalkThru(string door)
        {
            int count = 0;
           // PopulateDoorList();
            foreach (var value in doors)
            {
                if (value.name == door)
                {
                    if (value.open[0].Equals("true"))
                    {
                        bool test = true;
                        return test;
                    }

                    count++;
                }
            }
            return false;
        }

        public int FindIdexDoorName(string doorName)
        {
            int count = 0;
            int index = -1;
            foreach (var value in rooms)
            {
                foreach (var value2 in value.doors)
                {
                    if (value2 == doorName)
                    {
                        index = count;

                    }
                }

                count++;

            }
            return index;
        }







        //Items Segment

        public string PickupItem(string itemName, int[] mapCords)
        {
            int index = FindIdexItemName(itemName);

            if (rooms[index].roomPlacement.SequenceEqual(mapCords))
            {
                                
                        if (rooms[index].items2.Contains(itemName))
                        {
                            

                            rooms[index].items2.Remove(itemName);

                            //om föremålet finns
                            return itemName;
                        }
                        else
                        {
                            
                            return null;
                        }
                
            
            
        }
            return null;

            //om inte ska läggas till

        }
       
        public string ReturnItemRequrements(int[] mapCord)
        {
            foreach (var value in rooms)
            {
                if (value.roomPlacement.SequenceEqual(mapCord))
                {
                    return value.itemRequrements;
                }

            }
            return "none";
        }
        private int FindIdexItemName(string itemName)
        {
            int count = 0;
            int index = 0;
            foreach (var value in rooms)
            {
                foreach (var value2 in value.items2)
                {
                    if (value2 == itemName)
                    {
                        index = count;

                    }
                }
                
                count++;

            }
            return index;
        }

    }

}
