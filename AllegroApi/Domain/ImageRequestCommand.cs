using System;
using RestSharp;

namespace AllegroApi.Domain
{
    
    public class ImageRequestCommand : IRequestAllegro
    {
        public Uri Uri { get; set; }
        public string Authorization { get; set; }
        public Method Method { get; set; }
        public byte[] Image { get; set; }
    }
}