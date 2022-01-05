using Newtonsoft.Json;

namespace Terra.Net.Lcd.Objects
{
    public class ValidatorSetResponse
    {
        [JsonProperty("block_height")]
        public ulong BlockHeight { get; set; }

        [JsonProperty("validators")]
        public List<TendermintValidator> Validators { get; set; }

        [JsonProperty("pagination")]
        public PageResponse Pagination { get; set; }
    }
}