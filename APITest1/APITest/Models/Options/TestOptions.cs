﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITest.Models.Options
{
    public class TestOptions
    {
        public string opt_key1 { set; get; }
        public SubTestOption opt_key2 { set; get; }
    }
    public class SubTestOption
    {
        public string k1 { set; get; }
        public string k2 { set; get; }
    }
}
