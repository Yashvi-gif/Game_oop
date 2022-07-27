using System;
using System.Collections.Generic;
using System.Text;

namespace TestDemo
{
    public class Inventory
    {
        private List<Item> _items;
        public Inventory()
        {
            _items = new List<Item>();
        }
        public bool HasItem(string id)
        {
            foreach ( Item c in _items)
            {
                if (c.AreYou(id)== true)
                {
                    return true;
                }
            }
            return false;
        }
        public void Put(Item itm)
        {
            _items.Add(itm);
        }
        public Item Take(string id)
        {
            foreach(Item c in _items)
            {
                if (c.AreYou(id) == true)
                {
                    _items.Remove(c);
                    return c;
                }
            }
            return null;
           
        }
        public Item Fetch(string id)
        {
         foreach(Item c in _items)
            {
                if (c.AreYou(id) == true)
                {
                    return c;
                }
              /*  else
                {
                    return null;
                }*/
            }
            return null;
            
        }
        public string ItemList
        {
            get
            {
                string result = "";
                foreach (Item itm in _items)
                {
                    result += "\n" + itm.ShortDescription;
                }
                return result;
            }
        }
    }
    
}
