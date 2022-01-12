using Newtonsoft.Json;

namespace Terra.Net.Lcd.Objects
{
    public class MempoolResponse
    {
        [JsonProperty("txs")]
        public List<TxOld> Txs { get; set; }
    }

}
