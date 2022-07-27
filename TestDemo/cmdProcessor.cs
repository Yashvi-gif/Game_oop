using System;
using System.Collections.Generic;
using System.Text;

namespace TestDemo
{
    public class cmdProcessor : Command
    {
        private List<Command> _commands;
        public cmdProcessor() : base(new string[] { "command" })
        {
            _commands = new List<Command>();
        }

        public override string Execute(Player player, string[] text)
        {
            foreach (Command cmd in _commands)
            {
                if (cmd.AreYou(text[0]))
                {
                    return cmd.Execute(player, text);
                }
            }
            return "Error is present";
        }

        public void AddComm(Command comm)
        {
            _commands.Add(comm);
        }


    }
}

