
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
    /// the response type for the Service.BroadcastTx method.
    /// </summary>
    public class BroadcastTxResponse
    {
        [JsonProperty("tx_response")]
        public TxResponse TxResponse { get; set; }
    }

    /// <summary>
    /// GetTxResponse is the response type for the Service.GetTx method.
    /// </summary>
    public class GetTxResponse
    {
        [JsonProperty("tx")]
        public Tx Tx { get; set; }

        [JsonProperty("tx_response")]
        public TxResponse TxResponse { get; set; }
    }

    /// <summary>
    ///  TxResponse defines a structure containing relevant tx data and metadata.The
    /// tags are stringified and the log is JSON decoded.
    /// </summary>
    public partial class TxResponse : GasInfo
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

        [JsonProperty("tx")]
        public ProtoBufMessage Tx { get; set; }

        /// <summary>
        /// "Time of the previous block. For heights > 1, it's the weighted median of
        /// the timestamps of the valid votes in the block.LastCommit. For height == 1,
        /// it's genesis time."
        /// </summary>
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
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

    public class BroadcastTxResponseOld
    {
        /// <summary>
        /// Tx hash
        /// </summary>
        [JsonProperty("hash")]
        public string Hash { get; set; }

        /// <summary>
        /// Block height
        /// </summary>
        [JsonProperty("height")]
        public ulong Height { get; set; }
        
        /// <summary>
        /// tx info
        /// </summary>
        [JsonProperty("check_tx")]
        public BroadcastedTxOld CheckTx { get; set; }

        /// <summary>
        /// tx info
        /// </summary>
        [JsonProperty("deliver_tx")]
        public BroadcastedTxOld DeliverTx { get; set; }
    }

    public class BroadcastedTxOld : GasInfo
    {
        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("log")]
        public string Log { get; set; }

        [JsonProperty("info")]
        public string Info { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }
}