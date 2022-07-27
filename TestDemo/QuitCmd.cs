using System;
using System.Collections.Generic;
using System.Text;

namespace TestDemo
{
    public class QuitCmd : Command
    {
        public QuitCmd() : base(new string[] { "quit" })
        {
        }

        public override string Execute(Player _player, string[] text)
        {
            if (text[0] == "quit")
            {
                return ("goodBye");
            }
            return null;
        }
    }
}
