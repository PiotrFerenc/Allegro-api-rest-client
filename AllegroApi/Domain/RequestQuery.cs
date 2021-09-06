using System;
using RestSharp;

namespace AllegroApi.Domain
{
    public class RequestQuery : IRequestAllegro
    {
        public Uri Uri { get; set; }
        public string Authorization { get; set; }
        public Method Method { get; set; }
    }
}