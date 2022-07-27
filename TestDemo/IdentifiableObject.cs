using System;
using System.Collections.Generic;
using System.Text;
using TestDemo;

namespace TestDemo
{
    public class IdentifiableObject
    {
        
      
        private List<string> _identifiers;
        public IdentifiableObject(string[] idents)
        {
            _identifiers = new List<string>();
            foreach (string id in idents)
            {
                _identifiers.Add(id.ToLower());
            }
        }
        public bool AreYou(string id)
        {
            if (_identifiers.Contains(id.ToLower()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string FirstId()
        {return _identifiers[0];}
        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }


    }
}
