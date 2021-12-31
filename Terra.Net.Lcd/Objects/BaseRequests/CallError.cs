using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terra.Net.Lcd.Objects
{   
    public  class CallError
    {
        [JsonProperty("code")]
        public int? Code { get; set; }

        [JsonProperty("message")]
        public string? Message { get; set; }

        [JsonProperty("details")]
        public List<string>? Details { get; set; }

        [JsonProperty("error")]
        public string? ErrorMessage { get; set; }
    }
}
