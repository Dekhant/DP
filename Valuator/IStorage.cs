﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Valuator
{
    public interface IStorage
    {
        void Store(string key, string value);

        string Load(string key);

        List<string> GetKeys();
    }
}
