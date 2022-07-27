using System;
using System.Collections.Generic;
using System.Text;

namespace TestDemo
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look" }) { }

        public override string Execute(Player _player, string[] text)
        {
           // IHaveInventory container;
            if (text.Length != 3 && text.Length != 5)
            {
                return "I dont know how you expect me to look like that !";
            }
            
            if (text[0] != "look")
            {
                return "Oops ! error in look input";
            }
            if (text[1] != "at")
            {
                return _player + " what do you want to look at ?";
            }

            if (text.Length == 3)
            {
                if (LookAtIn(text[2], _player as IHaveInventory) == null)
                {
                    return LookAtIn(text[2], _player.Locatn);
                }
                

                return LookAtIn(text[2], _player as IHaveInventory);

            }
            if (text.Length == 5)
            {
                 if (text[3].ToLower() != "in")
                 {
                      return "what do you want to look in?";
                 }
                 IHaveInventory container = FetchContainer(_player, text[4]);                      
                 if(container is null)
                 {
                     return $"I cant find {text[4]}";
                 }
                 return LookAtIn(text[2], container);

            }
            return null;


        }
        private IHaveInventory FetchContainer(Player _player, string containerId)
        {
             return _player.Locate(containerId) as IHaveInventory;
        }

        private string LookAtIn(string thingid, IHaveInventory container)
        {

            GameObject Mycontainer = container.Locate(thingid);
            if (Mycontainer != null)
            {
                return Mycontainer.LongDescription;
            }
            else
            {
                return "I cannot find the " + thingid;
            }

        }
    }
}

