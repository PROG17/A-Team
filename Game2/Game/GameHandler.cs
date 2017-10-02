using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class GameHandler
    {
       
        MapHandler Map = new MapHandler();
        List<string> inventory = new List<string>();
        ItemHandler Items = new ItemHandler();
        RoomHandler rooms = new RoomHandler();
       
        List<string> tempItems = new List<string>();
        private int[] mapCords = new []{0,0};
        private int[,] map = new int[3, 3];
        private int[] end = new[] { 2, 2 };

        ///<summary>
        ///Startar stelet
        ///</summary>
        ///<remarks>
        /// Startar spelet
        ///</remarks>

        public void NoCommand()
        {
            Console.SetCursorPosition(35, 26);
            Console.WriteLine("Det komandot finns inte");
        }
       
        public void StartGame()
        {
            
           ShowRoom();
            Map.ShowPossition(mapCords);


        }

        public string UseItemOnItem(string item1,string item2)
        {
           string newItemName = Items.UseItemOnItem(item1, item2);
            return newItemName;
        }
        public string OpenDoor(string input,string requriedItem)
        {
            if (Items.DoIhaveThisItem(requriedItem))
            {
              string doorOpen =  rooms.OpenDoor(mapCords, input, requriedItem);
                
                return doorOpen;
            }
            else
            {
                Console.SetCursorPosition(0, 2);
                Console.WriteLine("Du har inte rätt sak");
                return null;
            }
            
        }
        ///<summary>
        ///Visar Rummet
        ///</summary>
        ///<remarks>
        ///rooms.AddRooms(); Lägger till alla rum vi gjort
        /// rooms.FindRoom(mapCords); Hittar rätt run som vi är på
        ///</remarks>
        public void ShowRoom()
        {
           
            
            rooms.ShowRoom(mapCords);
        }

        ///<summary>
        ///Uppdaterar Kartan (behövs?)
        ///</summary>
        public void UpdateMap()
        {
            ShowRoom();         
            
            Map.ShowPossition(mapCords);
        }

        ///<summary>
        ///Flyttar spelarn gör kontroll om man kan flytta och skickar tebax cords
        ///</summary>
        ///<remarks>
        ///Hanterar om man kan flytta dit man vill och hanterar kartan
        ///</remarks>
        public bool MoveToNewRoom(string InputFromPlayer)
        {

            mapCords = Map.MapMovement(InputFromPlayer,map,mapCords,rooms );
            Map.ShowPossition(mapCords);
            if (mapCords.SequenceEqual(end))
            {
                return false;
            }
            return true;
        }

        ///<summary>
        /// Visar Tillängliga Items WIP
        ///</summary>
        ///<remarks>
        ///Ska kolla mot map cords och se om man är i ett rum items i 
        ///</remarks>
        public void ShowItems()
        {

            tempItems.Clear();
            tempItems = Items.ShowInventory();
            ;
            try
            {
                Console.SetCursorPosition(0,20);
                Console.WriteLine("Inventory");
                foreach (var value in tempItems)
                {
                    Console.WriteLine(value);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public void DropItem(string name)
        {
            
            tempItems.Clear();
            tempItems = Items.ShowInventory();

            
            
            
            foreach (var value in tempItems)
            {
               if (value == name)
               {
                    Items.DropItem(name);
                    rooms.DropItem(name,mapCords);
                    
                }
                    
            }
        }
       
        public void CloseInspect(string name)
        {
           string closeinspect = Items.closeInspect(name);
            Console.SetCursorPosition(10,10);
            Console.WriteLine(closeinspect);
        }

        public string PickUpItem(string itemName)
        {


           string itemToInv=rooms.PickupItem(itemName, mapCords);
             Items.AddItem(itemToInv);
            return itemToInv;
        }

      
    }
}
