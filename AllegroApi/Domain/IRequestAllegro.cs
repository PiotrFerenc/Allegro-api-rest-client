using System;
using RestSharp;

namespace AllegroApi.Domain
{
    public interface IRequestAllegro
    {
        Uri Uri { get; set; }
        string Authorization { get; set; }
        Method Method { get; set; }
    }
}