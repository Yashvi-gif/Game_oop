using System;
using System.Collections.Generic;
using System.Text;

namespace TestDemo
{
    public abstract class Command : IdentifiableObject
    {
        public Command(string[] ids) : base(ids)
        { 

        }

        public abstract string Execute(Player _player, string[] text);
    }
}
