using System.Collections.Generic;

namespace AllegroApi.Domain.AllegroProduct
{
    public class Parameter
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<string> ValuesLabels { get; set; }
        public List<string> Values { get; set; }
        public string Unit { get; set; }
        public Options Options { get; set; }
    }
}