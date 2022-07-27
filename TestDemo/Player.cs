using System;
using System.Collections.Generic;
using System.Text;

namespace TestDemo
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Location _locatn;
        
        
        public Player (string name, string desc) :
            base (new string[] {"me", "inventory"} , name, desc)
        {
            _inventory = new Inventory();
        }
        public override string LongDescription
        {
            get
            {
                return this.Name + ", you owe these items :" + _inventory.ItemList;
            }
        }
        public Location Locatn
        {
            get
            {
                return _locatn;
            }
            set
            {
                
                _locatn = value;
            } 
        }
        public Inventory Inventory
        {
           get
            {
                return _inventory;
            }
        }
        public GameObject Locate(string id)
        {
            if (AreYou(id))            
                return this;
            
            else
            {
                if (_locatn != null)
                {
                    _locatn.Locate(id);
                }
                return _inventory.Fetch(id);
            }
        }


    }

    
}
