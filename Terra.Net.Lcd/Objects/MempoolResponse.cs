using Newtonsoft.Json;

namespace Terra.Net.Lcd.Objects
{
    public class MempoolResponse
    {
        [JsonProperty("txs")]
        public List<Tx> Txs { get; set; }
    }

}
