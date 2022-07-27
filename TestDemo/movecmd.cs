using System;
using System.Collections.Generic;
using System.Text;

namespace TestDemo
{
    public class movecmd : Command
    {
        Path getPath;
        Location presentLocatn;
        public movecmd() : base(new string[] {"move", "go", "head", "leave" })
        {
        }
         public override string Execute(Player _player, string[] text)
        {
            if (text[0] != "move" && text[0] != "go" && text[0] != "head" && text[0] != "leave")
            {
                return "Pls enter correct move cmd";
            }
            presentLocatn = _player.Locatn;
            getPath = presentLocatn.GetPath(text[2]);

            if (getPath != null)
            {              
                getPath.Playermove(_player);
                return _player.Locatn.LongDescription;                
            }
            else
            {
                return "The move cmd is invalid";
            }
        }
    }
}
