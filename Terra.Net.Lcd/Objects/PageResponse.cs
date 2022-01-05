using Newtonsoft.Json;

namespace Terra.Net.Lcd.Objects
{
    public class PageResponse
    {
        /// <summary>
        /// next_key is the key to be passed to PageRequest.Key to query the next page most efficiently
        /// </summary>
        [JsonProperty("next_key")]
        public string NextKey { get; set; }

        /// <summary>
        /// total is total number of results available if PageRequest.CountTotal was set, its value is undefined otherwise
        /// </summary>
        [JsonProperty("total")]
        public long Total { get; set; }
    }
}