using System;
using System.Collections.Generic;
using System.Text;

namespace TestDemo
{
    public class TakeCmd : Command
    {
        public TakeCmd() : base(new string[] { "take", "pickup" })
        {

        }

        public override string Execute(Player _player, string[] text)
        {
            Item item1;
            IHaveInventory inv;
            if (text.Length == 2)
            {
                inv = _player.Locatn;
                item1 = inv.Inventory.Take(text[1]);

                if (item1 == null)
                {
                    return ("I cannot find the item - " + text[1]);
                }
                else
                {
                    _player.Inventory.Put(item1);
                    return ("Successful taken! Now you have " + item1.Name + " from the " + inv.Name);
                }
            }

            else if (text.Length == 4)
            {
                inv = FetchContainer(_player, text[3]);
                if (inv == null)
                {
                    return ("I cant find the inventory : " + text[3]);
                }
                else
                {
                    item1 = inv.Inventory.Take(text[1]);
                    if (item1 == null)
                    {
                        return ("I cannot find the item: " + text[1] + " in the " + text[3]);
                    }
                    else
                    {
                        _player.Inventory.Put(item1);
                        return ("Successful take! You have now taken the " + item1.Name + " from the " + inv.Name);
                    }
                }
            }
            else
            {
                return ("I dont know how to take liek that.");
            }
        }

        private IHaveInventory FetchContainer(Player _player, string contId)
        {
            return _player.Locate(contId) as IHaveInventory;
        }
    }
}
