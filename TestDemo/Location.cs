using System;
using System.Collections.Generic;
using System.Text;

namespace TestDemo
{
    public class Location : GameObject, IHaveInventory
    {

		private List<Path> pathList = new List<Path>();
		Inventory _inventory;
		public Location(string[] ids, string name, string desc) : base(ids, name, desc)
		{
			_inventory = new Inventory();
		}
		public GameObject Locate(string id)
		{
			if (this.AreYou(id))
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
			{return _inventory;}		
			
		}

		public override string LongDescription
		{
			get
			{
				return ("In location: " + this.Name + " you can see" + _inventory.ItemList);
			}
		}
		public List<Path> Paths
		{
			get
			{
				return pathList;
			}
		}

		public void AddPath(Path path)
		{
			pathList.Add(path);
		}

		public Path GetPath(string id)
		{
			foreach (Path path in pathList)
			{
				if (path.AreYou(id))
					return path;
			}
			return null;
		}


	}
}
