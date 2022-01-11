using Newtonsoft.Json;

namespace Terra.Net.Lcd.Objects.Requests
{
    public class BasePaginationRequest
    {
        [JsonProperty("offset")]
        public virtual ulong? Offset { get; set; }
        
        [JsonProperty("limit")]
        public virtual ulong? Limit { get; set; }
    }
}
