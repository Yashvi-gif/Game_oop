using System;
using System.Collections.Generic;
using System.Text;

namespace TestDemo
{
    public class Path : IdentifiableObject
    {

        private Location _from = null;
        private Location _to = null;

        public Path(string[] idents, Location from, Location To) : base(idents)
        {
            _from = from;
            _to = To;
        }


        public Location From
        {
            get
            {
                return _from;
            }
            set
            {
                _from = value;
            }
        }

        public Location To
        {
            get
            {
                return _to;
            }
            set
            {
                _to = value;
            }
        }

        public void Playermove(Player _player)
        {
            _player.Locatn = To;
        }
    }
}
