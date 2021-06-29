﻿using System.Collections.Generic;

namespace AllegroApi.Domain
{
    public class Parameter
    {
        public string Id { get; set; }
        public List<string> ValuesIds { get; set; }
        public List<string> Values { get; set; }
        public object RangeValue { get; set; }
    }
}