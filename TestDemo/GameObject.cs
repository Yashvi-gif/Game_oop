using System;
using System.Collections.Generic;
using System.Text;

namespace TestDemo
{
    public abstract class GameObject : IdentifiableObject
    {
        private string _desc;
        private string _name;
        public GameObject(string[] ids, string name, string desc) : base(ids)
        {
            _name = name;
            _desc = desc;
        }
        public string Name
        {
            get { return _name; }
           set { _name = value; }
        }
        public virtual string LongDescription
        {
            get
            {
                return _desc;
            }
            set { _desc = value; }
        }
        public string ShortDescription
        {
            get
            {
                return "a " +_name  + " " + (FirstId()) ;
            }
        }
    }
}
