using System;
using System.Collections.Generic;

namespace AllegroApi.Domain
{
    public class RequestQuery
    {
        public Uri Uri { get; init; }
        public string Authorization { get; init; }
        public string Method { get; init; }
        public Dictionary<string,object> Params { get; set; }
    }
}