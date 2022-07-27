﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TestDemo
{
    public interface IHaveInventory
    {
        GameObject Locate(string id);

        string Name { get; }
        Inventory Inventory
        {
            get;
        }

    }
}