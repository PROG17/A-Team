using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class ItemHandler
    {
        ///<summary>
        ///List<item>Items Lista med alla items 
        /// List<string> itemsInventory är sakerna man har
        ///</summary>
        List<item>itemsInventoryList = new List<item>();
        List<string> tempItems = new List<string>();
        // sånt som ska skickas tillbaka till gamehandler

        ///<summary>
        /// AddItems() Lägger till items i item listan
        ///</summary>
        public void AddItems()
        {

            itemsInventoryList.Add(new item(){itemName = "nyckel",have = false, closeInspection = "En gyllene nyckel",description = "Du ser hur den glimmar i ljuset kanske ett steg närmre till frihet"});
            itemsInventoryList.Add(new item(){itemName = "flaska", have=false, closeInspection = "Inne i flaskan hör du något som skrammlar", description = "En grön flaska", useWith = "korkskruv", afterUseGet = "nyckel"});
            itemsInventoryList.Add(new item() { itemName = "korkskruv", have = false, closeInspection = "En helt vanlig korkskruv", description = "En korkskruv undra vad man annvänder den till" });

            itemsInventoryList.Add(new item() { itemName = "aphuvud", have = false, closeInspection = "När du tittar närmre så ser du att det är något gult vid örat.", description = "Ett ap huvud. Alltid kanske bra till något",useWith = "tops",afterUseGet = "grönnyckel" });
            itemsInventoryList.Add(new item() { itemName = "tops", have = false, closeInspection = "ett tops som är vit med lite gult på spätsen ucsh", description = "hmm ett tops .. vad ska vi ha den till" });
            itemsInventoryList.Add(new item() { itemName = "grönnyckel", have = false, closeInspection = "En grön nyckel .. hhmm undra vad man annvänder nycklar till", description = "Ap huvudet öppnar sig och ut trillar en grön nyckel" });

        }
        public bool DoIhaveThisItem(string item)
        {
            foreach (var value in itemsInventoryList)
            {
                if (value.itemName == item)
                {
                    if (value.have == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        ///<summary>
        /// ListAllItems() Visar alla items i itemlistan
        ///</summary>

        // hmm ska ändra så man inte  lägget till
        public List<string> ShowInventory()
        {
            PopulateItemList();
            tempItems.Clear();
            //ska läggas in en koll på om saken redan finns                 
            
            foreach (var value in itemsInventoryList)
            {
                if (value.have)
                {
                    tempItems.Add(value.itemName);
                    
                    
                }
               
            }
            return tempItems;
        }

        public string UseItemOnItem(string item1,string item2)
        {
            bool haveItem1 = false;
            bool haveItem2 = false;
            foreach (var value in itemsInventoryList)
            {
                if (value.itemName == item1)
                {
                    if (value.have)
                    {
                        haveItem1 = true;
                    }
                }
                if (value.itemName == item2)
                {
                    if (value.have)
                    {
                        haveItem2 = true;
                    }
                }

            }
            if (haveItem1 && haveItem2)
            {
                int index = ItemListIndex(item2);
               string itemToGet = itemsInventoryList[index].afterUseGet;
                int index2 = ItemListIndex(itemToGet);
                itemsInventoryList[index2].have = true;
                return itemToGet;
            }
            return null;
        }
        //lägger till item till inventory
        public void AddItem(string name)
        {
            PopulateItemList();
            foreach (var value in itemsInventoryList)
            {
                if (value.itemName == name)
                {
                    value.have = true;
                }
            }
        }

       
        public void DropItem(string name)
        {
            PopulateItemList();
            foreach (var value in itemsInventoryList)
            {
                if (value.itemName == name)
                {
                    value.have = false;
                }
            }
        }

        public bool UseItem(string itemName)
        {
            int index = ItemListIndex(itemName);

            if (itemsInventoryList[index].have)
            {
                return true;
                //lägga in used item ?
            }
            else
            {
                return false;
            }

        }

        public string closeInspect(string name)
        {
            foreach (var value in itemsInventoryList)
            {
                if (value.itemName == name)
                {
                    return value.closeInspection;
                }
            }
            return null;
        }
        //Hämtar var itemet finns på för index.
        private int ItemListIndex(string itemName)
        {
            int index = 0;
            int count = 0;
            foreach (var value in itemsInventoryList)
            {
                if (value.itemName == itemName)
                {
                    index = count;
                }
                count++;
            }
            return index;
        }

        private void PopulateItemList()
        {
            if (itemsInventoryList.Count == 0)
            {
                AddItems();
            }
        }

    }
}
