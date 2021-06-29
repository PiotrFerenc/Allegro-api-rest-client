using System;
using System.Collections.Generic;

namespace AllegroApi.Domain
{
    public class Validation
    {
        public List<object> Errors { get; set; }
        public List<object> Warnings { get; set; }
        public DateTime ValidatedAt { get; set; }
    }
}