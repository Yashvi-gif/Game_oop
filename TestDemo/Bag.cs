using System;
using System.Collections.Generic;
using System.Text;

namespace TestDemo
{
    public class Bag : Item, IHaveInventory
    {
        private Inventory _inventory;

        public Bag(string[] ids, string name, string desc) :
            base(ids, name, desc)
        {
            _inventory = new Inventory();
        }
        public override string LongDescription
        {
            get
            {
                return "In the " + this.Name + " you can see that you owe:" + _inventory.ItemList;
            }
        }
        public GameObject Locate(string id)
        {
            if (AreYou(id) == true)
            {
                return this;
            }
            else
            {
                return _inventory.Fetch(id);
            }

        }
        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
    }
}
