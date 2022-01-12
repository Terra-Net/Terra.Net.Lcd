
using Newtonsoft.Json;

namespace Terra.Net.Lcd.Objects
{
    public class TxsEventResponse
    {
        /// <summary>
        /// the list of queried transactions
        /// </summary>
        [JsonProperty("txs")]
        public List<Tx> Txs { get; set; }

        /// <summary>
        /// the list of queried TxResponses
        /// </summary>
        [JsonProperty("tx_responses")]
        public List<TxResponse> TxResponses { get; set; }

        [JsonProperty("pagination")]
        public PageResponse Pagination { get; set; }
    }

    /// <summary>
    ///  TxResponse defines a structure containing relevant tx data and metadata.The
    /// tags are stringified and the log is JSON decoded.
    /// </summary>
    public partial class TxResponse
    {
        /// <summary>
        /// The block height
        /// </summary>
        [JsonProperty("height")]
        public ulong Height { get; set; }

        /// <summary>
        /// The transaction hash.
        /// </summary>
        [JsonProperty("txhash")]
        public string Txhash { get; set; }

        /// <summary>
        /// Namespace for the Code
        /// </summary>
        [JsonProperty("codespace")]
        public string Codespace { get; set; }

        /// <summary>
        /// Response code.
        /// </summary>
        [JsonProperty("code")]
        public long Code { get; set; }

        /// <summary>
        /// Result bytes, if any.
        /// </summary>
        [JsonProperty("data")]
        public string Data { get; set; }

        /// <summary>
        /// The output of the application's logger (raw string). May be
        /// non-deterministic.
        /// </summary>
        [JsonProperty("raw_log")]
        public string RawLog { get; set; }

        /// <summary>
        /// The output of the application's logger (typed). May be non-deterministic.
        /// </summary>
        [JsonProperty("logs")]
        public List<ABCIMessageLog> Logs { get; set; }

        /// <summary>
        /// Additional information. May be non-deterministic.
        /// </summary>
        [JsonProperty("info")]
        public string Info { get; set; }

        /// <summary>
        /// Amount of gas requested for transaction.
        /// </summary>
        [JsonProperty("gas_wanted")]
        public ulong GasWanted { get; set; }

        /// <summary>
        /// Amount of gas consumed by transaction.
        /// </summary>
        [JsonProperty("gas_used")]
        public ulong GasUsed { get; set; }

        [JsonProperty("tx")]
        public ExtensionOption Tx { get; set; }

        /// <summary>
        /// "Time of the previous block. For heights > 1, it's the weighted median of
        /// the timestamps of the valid votes in the block.LastCommit. For height == 1,
        /// it's genesis time."
        /// </summary>
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
    }

    /// <summary>
    /// defines a structure containing an indexed tx ABCI message log.
    /// </summary>
    public class ABCIMessageLog
    {
        /// <summary>
        /// Gets or Sets MsgIndex
        /// </summary>
        [JsonProperty("msg_index")]
        public long? MsgIndex { get; set; }

        /// <summary>
        /// Gets or Sets Log
        /// </summary>
        [JsonProperty("log")]
        public string Log { get; set; }

        /// <summary>
        /// Events contains a slice of Event objects that were emitted during some execution.
        /// </summary>
        [JsonProperty("events")]
        public List<Event> Events { get; set; }
    }
}