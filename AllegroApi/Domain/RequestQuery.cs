using System;

namespace AllegroApi.Domain
{
    public class RequestQuery
    {
        public Uri Uri { get; init; }
        public string Authorization { get; init; }
        public string Method { get; init; }
    }
}