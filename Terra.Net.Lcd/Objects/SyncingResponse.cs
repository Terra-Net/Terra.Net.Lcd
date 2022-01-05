using Newtonsoft.Json;

namespace Terra.Net.Lcd.Objects
{
    /// <summary>
    /// The response type for the Query/GetSyncing RPC method.
    /// </summary>
    public class SyncingResponse
    {
        [JsonProperty("syncing")]
        public bool IsSyncing { get; set; }
    }

}
