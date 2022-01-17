
using Newtonsoft.Json;

namespace Terra.Net.Lcd.Objects
{
    public class TxsListResponseOld : MempoolResponse
    {
        [JsonProperty("limit")]
        public long Limit { get; set; }

        [JsonProperty("next")]
        public long Next { get; set; }

    }
}