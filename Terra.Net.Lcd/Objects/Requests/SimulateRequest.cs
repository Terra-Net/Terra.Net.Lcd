using Newtonsoft.Json;

namespace Terra.Net.Lcd.Objects.Requests
{
    /// <summary>
    /// SimulateRequest is the request type for the TerraLcdClient.Simulate method.
    /// </summary>
    public class SimulateRequest
    {
        /// <summary>
        /// Tx is the standard type used for broadcasting transactions.
        /// Deprecated. Send raw tx bytes instead.
        /// </summary>
        [JsonProperty("tx")]
        public Tx Tx { get; set; }

        /// <summary>
        /// is the raw transaction.
        /// </summary>
        [JsonProperty("tx_bytes")]
        public string TxBytes { get; set; }
    }
}