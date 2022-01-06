using System.Collections.Generic;


namespace AllegroApi.Domain.Auth
{
    public class Token
    {
        public int exp { get; set; }
        public string user_name { get; set; }
        public string jti { get; set; }
        public string client_id { get; set; }
        public List<string> scope { get; set; }
        public bool allegro_api { get; set; }
    }
}
