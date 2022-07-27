// Put class


using System;
using System.Collections.Generic;
using System.Text;

namespace TestDemo
{
    public class PutCommand : Command
    {
        public PutCommand() : base(new string[] { "put", "drop" })
        {

        }
        public override string Execute(Player _player, string[] text)
        {
            Item item;
            IHaveInventory inv;

            if (text.Length == 2)
            {
                inv = _player.Locatn;
                item = _player.Inventory.Take(text[1]);

                if (item == null)
                {
                    return ("I cannot find the item - " + text[1]);
                }
                else
                {
                    inv.Inventory.Put(item);
                    return ("Successfully put! You have now dropped " + item.Name + " in the " + inv.Name);
                }

            }
            else if (text.Length == 4)
            {
                item = _player.Inventory.Take(text[1]);
                inv = FetchContainer(_player, text[3]);
                if (inv == null)
                {
                    return ("I cannot find the inventory - " + text[3]);
                }
                else
                {
                    if (item == null)
                    {
                        return ("I cannot find the item: " + text[1] + " in the " + text[3]);
                    }
                    else
                    {
                        inv.Inventory.Put(item);
                        return ("Successful put! You have now dropped the " + item.Name + " in the " + inv.Name);
                    }
                }
            }
            else
            {
                return "I dont know how to put like that!";
            }

        }

        private IHaveInventory FetchContainer(Player _player, string contId)
        {
            return _player.Locate(contId) as IHaveInventory;
        }
    }
}

// Take Class
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

