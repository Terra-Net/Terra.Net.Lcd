using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Terra.Net.Lcd.Objects.Requests
{
    /// <summary>
    /// BroadcastTxRequest is the request type for the Service.BroadcastTxRequest
    /// RPC method.
    /// </summary>
    public class BroadcastTxRequest
    {
        /// <summary>
        /// the raw transaction.
        /// </summary>
        [JsonProperty("tx_bytes")]
        public string TxBytes { get; set; }

        /// <summary>
        /// BroadcastMode specifies the broadcast mode for the TxService.Broadcast RPC method.   - BROADCAST_MODE_UNSPECIFIED: zero-value for mode ordering  - BROADCAST_MODE_BLOCK: BROADCAST_MODE_BLOCK defines a tx broadcasting mode where the client waits for the tx to be committed in a block.  - BROADCAST_MODE_SYNC: BROADCAST_MODE_SYNC defines a tx broadcasting mode where the client waits for a CheckTx execution response only.  - BROADCAST_MODE_ASYNC: BROADCAST_MODE_ASYNC defines a tx broadcasting mode where the client returns immediately.
        /// </summary>
        [JsonProperty("mode")]
        public BroadcastMode Mode { get; set; }
    }

    public class BroadcastTxRequestOld
    {
        /// <summary>
        /// request tx must be signed
        /// </summary>
        [JsonProperty("tx")]
        public TxValuePostBodyOld Tx { get; set; }

        /// <summary>
        /// broadcast mode
        /// </summary>
        [JsonProperty("mode")]
        public BroadcastMode Mode { get; set; }
    }

    /// <summary>
    /// BroadcastMode specifies the broadcast mode for the TxService.Broadcast RPC method.   - BROADCAST_MODE_UNSPECIFIED: zero-value for mode ordering  - BROADCAST_MODE_BLOCK: BROADCAST_MODE_BLOCK defines a tx broadcasting mode where the client waits for the tx to be committed in a block.  - BROADCAST_MODE_SYNC: BROADCAST_MODE_SYNC defines a tx broadcasting mode where the client waits for a CheckTx execution response only.  - BROADCAST_MODE_ASYNC: BROADCAST_MODE_ASYNC defines a tx broadcasting mode where the client returns immediately.
    /// </summary>
    /// <value>BroadcastMode specifies the broadcast mode for the TxService.Broadcast RPC method.   - BROADCAST_MODE_UNSPECIFIED: zero-value for mode ordering  - BROADCAST_MODE_BLOCK: BROADCAST_MODE_BLOCK defines a tx broadcasting mode where the client waits for the tx to be committed in a block.  - BROADCAST_MODE_SYNC: BROADCAST_MODE_SYNC defines a tx broadcasting mode where the client waits for a CheckTx execution response only.  - BROADCAST_MODE_ASYNC: BROADCAST_MODE_ASYNC defines a tx broadcasting mode where the client returns immediately.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BroadcastMode
    {

        /// <summary>
        /// Enum UNSPECIFIED for value: BROADCAST_MODE_UNSPECIFIED
        /// </summary>
        [EnumMember(Value = "BROADCAST_MODE_UNSPECIFIED")]
        Unspecified,

        /// <summary>
        /// Enum BLOCK for value: BROADCAST_MODE_BLOCK
        /// </summary>
        [EnumMember(Value = "BROADCAST_MODE_BLOCK")]
        Block,

        /// <summary>
        /// Enum SYNC for value: BROADCAST_MODE_SYNC
        /// </summary>
        [EnumMember(Value = "BROADCAST_MODE_SYNC")]
        Sync,

        /// <summary>
        /// Enum ASYNC for value: BROADCAST_MODE_ASYNC
        /// </summary>
        [EnumMember(Value = "BROADCAST_MODE_ASYNC")]
        Async
    }
}